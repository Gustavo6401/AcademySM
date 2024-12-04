using Amazon.SecurityToken.Model.Internal.MarshallTransformations;
using CadastroUsuario.Domain.Interfaces.Services;
using CadastroUsuario.Domain.Models;
using CadastroUsuario.Domain.Services.Strategy.PasswordValidation.AllCharTypes;
using CadastroUsuario.Domain.Services.Strategy.PasswordValidation.AllCharTypes.Strategy;
using CadastroUsuario.Domain.Services.Strategy.PasswordValidation.MaximumFiveCharacters;
using CadastroUsuario.Domain.Services.Strategy.PasswordValidation.MaximumFiveCharacters.Classes;
using Microsoft.AspNetCore.Identity;

namespace CadastroUsuario.Domain.Services
{
    public class UserServices : IUserServices
    {
        private readonly List<IAllTypesCharactersStrategy> strategy;
        private readonly Dictionary<string, IFiveCharacterStrategy> _characterStrategies = new Dictionary<string, IFiveCharacterStrategy>
        {
            { "Lower", new LowerStrategy() },
            { "Upper", new UpperStrategy() },
            { "Number", new NumberStrategy() },
            { "Symbol", new SymbolsStrategy() }
        };
        public UserServices()
        {
            strategy = new List<IAllTypesCharactersStrategy>()
            {
                new HasLowerCaseValidationStrategy(),
                new HasUppercaseValidationStrategy(),
                new HasNumberValidationStrategy(),
                new HasSymbolValidationStrategy()
            };
        }
        string IUserServices.ContainsAllCharacterTypes(string password)
        {
            var validator = new ValidatePassword(strategy);

            return validator.Validate(password);
        }

        bool IUserServices.ContainsAtLeastEightCharacters(string password)
        {
            if(password.Length < 8)
            {
                return false;
            }

            return true;
        }

        bool IUserServices.ContainsMaximumFiveCharactersOfTheSameTypeInASequence(string password)
        {
            string tipo = "";

            // Variável que vai guardar quantos caracteres do mesmo tipo estão em sequência.
            int qtd = 0;

            // Vai percorrer todos os elementos da senha.
            foreach (char letters in password)
            {
                foreach (var strategy in _characterStrategies)
                {
                    // Utiliza o pattern strategy para limpar o código do tanto de else e ifs.
                    if (strategy.Value.CharacterValid(letters))
                    {
                        if (tipo == strategy.Key)
                        {
                            qtd++;

                            if (qtd == 5)
                            {
                                return false;
                            }
                        }
                        else
                        {
                            tipo = strategy.Key;
                            qtd = 1;
                        }
                        break;
                    }
                }
            }

            return true;
        }

        public bool IsBlocked(ApplicationUser user)
        {
            if(user.PasswordErrors >= 10)
            {
                return true;
            }

            return false;
        }

        public bool ShouldBlockUser(int errosSenha)
        {
            if(errosSenha >= 10)
            {
                return true;
            }

            return false;
        }

        bool IUserServices.ValidateActualCourse(string course)
        {
            if(string.IsNullOrWhiteSpace(course))
            {
                throw new ArgumentException("Nome do Curso Inválido!");
            }

            return true;
        }

        bool IUserServices.ValidateBirthDate(DateTime date)
        {
            TimeSpan idadeTotal = DateTime.Now - date;

            if(idadeTotal.TotalDays / 365 < 13)
            {
                throw new ArgumentException("É necessário ser maior de 13 anos para se cadastrar!");
            }

            return true;
        }

        bool IUserServices.ValidateEducationDegree(string degree)
        {
            // It's better to view all of the data into a list than to seeing it into an else if.
            List<string> listaGraisAcademicos = new List<string>
            {
                "Ensino Fundamental 1",
                "Ensino Fundamental 2",
                "Ensino Médio",
                "Ensino Médio Técnico",
                "Ensino Superior",
                "Pós-Graduação",
                "Mestrado",
                "Doutorado"
            };

            if(!listaGraisAcademicos.Contains(degree))
            {
                throw new ArgumentException("Escolha uma das Opções de Formação!");
            }

            return true;
        }

        bool IUserServices.ValidateEmail(string email)
        {
            if(string.IsNullOrWhiteSpace(email)
               || !email.Contains('@'))
            {
                throw new ArgumentException("E-Mail Inválido!");
            }

            return true;
        }

        bool IUserServices.ValidateFullName(string name)
        {
            if(string.IsNullOrWhiteSpace(name)
               || !name.Contains(' '))
            {
                throw new ArgumentException("Nome Completo Inválido!");
            }

            return true;
        }

        bool IUserServices.ValidatePassword(string password)
        {
            IUserServices services = new UserServices();

            string containsAllCharacterTypes = services.ContainsAllCharacterTypes(password);

            if (containsAllCharacterTypes != "Senha Válida!")
            {
                throw new ArgumentException(containsAllCharacterTypes);
            }

            if(services.ContainsAtLeastEightCharacters(password) != true)
            {
                throw new ArgumentException("Crie uma Senha de ao Menos 8 Caracteres!");
            }

            return true;
        }

        bool IUserServices.ValidatePhoneNumber(string phoneNumer)
        {
            if(string.IsNullOrWhiteSpace(phoneNumer))
            {
                throw new ArgumentException("Número de Telefone Inválido!");
            }

            return true;
        }

        public bool ValidateUserOnCreate(ApplicationUser user)
        {
            IUserServices services = new UserServices();

            // services.ValidateActualCourse(user.ActualCourse!);
            services.ValidateBirthDate(user.BirthDate);
            // services.ValidateEducationDegree(user.EducationalDegree!);
            services.ValidateEmail(user.EMail!);
            services.ValidateFullName(user.FullName!);
            services.ValidatePassword(user.Password!);
            // services.ValidatePhoneNumber(user.Phone!);

            return true;
        }
    }
}
