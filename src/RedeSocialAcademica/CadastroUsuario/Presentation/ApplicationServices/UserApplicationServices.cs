using CadastroUsuario.Domain.Interfaces.ApplicationServices;
using CadastroUsuario.Domain.Interfaces.Cookies;
using CadastroUsuario.Domain.Interfaces.Repositories.MongoDB.Salts;
using CadastroUsuario.Domain.Interfaces.Repositories.MongoDB.Tokens;
using CadastroUsuario.Domain.Interfaces.Repositories.SqlServer;
using CadastroUsuario.Domain.Interfaces.Services;
using CadastroUsuario.Domain.Models;
using CadastroUsuario.Domain.Models.API;
using CadastroUsuario.Domain.Models.ControllerModels;
using CadastroUsuario.Domain.Models.MongoDBCollections.BCryptPersistence;
using CadastroUsuario.Domain.Models.MongoDBCollections.TokenPersistence;
using CadastroUsuario.Infra.API.Groups;
using CadastroUsuario.Infra.Authentication;
using CadastroUsuario.Infra.BCryptServices;
using CadastroUsuario.Infra.Tokens.MainToken;

namespace CadastroUsuario.Presentation.ApplicationServices
{
    public class UserApplicationServices : IUserApplicationServices
    {
        private readonly IUserServices _userServices;
        private readonly IUserRepository _userRepository;
        private readonly ITokenRepository _tokenRepository;
        private readonly IUserLockoutRepository _userLockoutRepository;
        private readonly IUserLockoutServices _userLockoutServices;
        private readonly ICookieConfiguration _cookieConfiguration;
        private readonly GroupsUsersAPI _groupsUserAPI;
        private readonly ISaltsRepository _saltsRepository;
        private readonly CookieAuthServices _cookieAuthServices;
        public UserApplicationServices(IUserServices services, IUserRepository repository, 
            ITokenRepository tokenRepository, IUserLockoutRepository userLockoutRepository, 
            IUserLockoutServices userLockoutServices, ICookieConfiguration cookieConfiguration,
            GroupsUsersAPI groupsUsersAPI, ISaltsRepository saltsRepository, CookieAuthServices cookieAuthServices)
        {
            _userServices = services;
            _userRepository = repository;
            _tokenRepository = tokenRepository;
            _userLockoutRepository = userLockoutRepository;
            _userLockoutServices = userLockoutServices;
            _cookieConfiguration = cookieConfiguration;
            _groupsUserAPI = groupsUsersAPI;
            _saltsRepository = saltsRepository;
            _cookieAuthServices = cookieAuthServices;
        }
        public async Task<UserCreateReturn> CreateAsync(ApplicationUser user)
        {
            // Checks wether user's e-mail already exists.
            ApplicationUser nullData = await _userRepository.GetByEmail(user.EMail!);

            // I need to implement Password Hashing, before putting it into production enviornments.

            if(nullData != null)
            {
                throw new ArgumentException("E-Mail já Existente no Banco de Dados");
            }

            string salt = PasswordHashing.GenerateSalt(15);

            // Validate user's data.
            _userServices.ValidateUserOnCreate(user);

            // Generates a new Guid.
            Guid id = Guid.NewGuid();

            // Hashes Password Using BCrypt
            user.Password = PasswordHashing.HashPassword(user.Password!, salt);
            // Inserts new Id into user.Id:
            user.Id = id;

            await _userRepository.CreateAsync(user);
            // When the user is being created, it doesn't have any groups.
            List<GroupsUsers> groupsUsers = new List<GroupsUsers>();

            string token = MainTokenService.GenerateToken(user, groupsUsers);

            // Save the Main Token in MongoDB.
            TokenData data = new TokenData
            {
                DataCriacaoToken = DateTime.Now,
                Token = token,
                UsuarioId = Convert.ToString(user.Id)
            };

            await _tokenRepository.Create(data);

            _cookieConfiguration.DeleteHttpOnlyCookie("Token");
            await _cookieAuthServices.LogoutAsync();
            await _cookieAuthServices.LoginAsync(user.Id, token, groupsUsers);

            SaltsData salts = new SaltsData
            {
                Email = user.EMail,
                Salt = salt
            };

            await _saltsRepository.Create(salts);

            return new UserCreateReturn
            {
                Message = "Usuário Cadastrado com Sucesso!",
                UserId = id
            };
        }

        public async Task DeleteAsync(Guid id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task<LoginReturn> Login(Login login)
        {
            SaltsData salts = await _saltsRepository.GetSaltByEmail(login.Email!);

            login.Password = PasswordHashing.HashPassword(login.Password!, salts.Salt!);

            // Checks wether the user and password are correct.
            LoginInformations loginInformations = await _userRepository.Login(login.Email!, login.Password!);

            ApplicationUser user = await _userRepository.GetByEmail(login.Email!);

            if (loginInformations == null)
            {
                if (user.PasswordErrors >= 10)
                {
                    UserLockout lockout = await _userLockoutRepository.GetLastUserLockoutByUserId(user!.Id);

                    int blockTime = _userLockoutServices.TimeBlock(lockout);

                    // Creates an lockout when user.PasswordErros >= 10;
                    lockout = new UserLockout
                    {
                        LockoutDate = DateTime.Now + TimeSpan.FromMinutes(blockTime),
                        QtdMinutes = blockTime,
                        UserId = user!.Id
                    };

                    await _userLockoutRepository.CreateAsync(lockout);

                    throw new ArgumentException($"Usuário Bloqueado durante {blockTime} minutos");
                }
                user.PasswordErrors++;
                await _userRepository.UpdateAsync(user);

                throw new ArgumentException("E-Mail ou Senha Incorretos!");
            }

            List<GroupsUsers> groupsUsers = await _groupsUserAPI.GetAllGroupsUsers(loginInformations.Id);
            string token = MainTokenService.GenerateToken(user, groupsUsers);

            // Save the Main Token in an HTTPOnlyCookie.
            //_cookieConfiguration.DeleteHttpOnlyCookie("MainToken");
            await _cookieAuthServices.LoginAsync(user.Id, token, groupsUsers);

            // Save the Main Token in MongoDB.
            TokenData data = new TokenData
            {
                DataCriacaoToken = DateTime.Now,
                Token = token,
                UsuarioId = Convert.ToString(loginInformations.Id)
            };

            await _tokenRepository.Create(data);

            LoginReturn loginReturn = new LoginReturn
            {
                Id = loginInformations!.Id,
                UserFullName = loginInformations.FullName,
                UserProfilePicPath = loginInformations!.ProfilePicPathName,
                ReturnMessage = "Usuário Logado com Sucesso!"
            };

            return loginReturn;
        }

        public async Task Update(ApplicationUser user)
        {
            _userServices.ValidateUserOnCreate(user);

            // Code that validates whether the user is updating his e-mail and the e-mail already exists in the DB.
            // Checks if the e-mail that is being updated already is in the database.
            ApplicationUser? nullable = await _userRepository.GetByEmail(user.EMail!);

            if(!nullable.Id.Equals(user.Id))
            {
                throw new ArgumentException("E-Mail já Existente na Base de Dados.");
            }

            await _userRepository.UpdateAsync(user);
        }

        public async Task<ApplicationUser> GetById(Guid id)
        {
            ApplicationUser? user = await _userRepository.GetAsync(id);

            if (user == null)
                throw new ArgumentException("Usuário Não Encontrado");

            return user!;
        }

        public async Task<string> Logout()
        {
            // Gets The Main Token.
            string token = _cookieConfiguration.GetHTTPOnlyCookie("MainToken");

            TokenData data = await _tokenRepository.GetByToken(token);
            await _tokenRepository.Remove(data.Id!);

            _cookieConfiguration.DeleteHttpOnlyCookie("MainToken");
            _cookieConfiguration.DeleteHttpOnlyCookie("IntermediateToken");

            return "Usuário Deslogado Com Sucesso!";
        }

        public async Task<ApplicationUser> GetByEmail(string email)
        {
            ApplicationUser user = await _userRepository.GetByEmail(email);

            return user;
        }

        public async Task ModifyAuthCookie(Guid userId)
        {
            List<GroupsUsers> groupsUsers = await _groupsUserAPI.GetAllGroupsUsers(userId);
            ApplicationUser user = await _userRepository.GetAsync(userId);
            string token = MainTokenService.GenerateToken(user, groupsUsers);

            // Desloging user before login In Again.
            await _cookieAuthServices.LogoutAsync();

            await _cookieAuthServices.LoginAsync(userId, token, groupsUsers);
        }

        public async Task<UserDetailsReturn> UserDetails(Guid id)
        {
            UserDetailsReturn userDetails = await _userRepository.UserDetails(id);

            return userDetails;
        }

        public async Task<UserPortfolio> Portfolio(Guid id)
        {
            UserPortfolio? portfolio = await _userRepository.Portfolio(id);
            portfolio.AcademySMGroups = await _groupsUserAPI.GetParticipantGroups(id);

            return portfolio!;
        }
    }
}
