using CadastroUsuario.Domain.Models;

namespace CadastroUsuario.Domain.Interfaces.Services
{
    // This interface contains all of the user validations, since the password, or the birth date. 
    public interface IUserServices
    {
        /// <summary>
        /// This is the sum all of the validations, for user creation, returns false wheter one condition is unsatisfied.
        /// 
        /// 1 - The user must have at least 13 years, on Brazilian Legislation;
        /// 2 - Passwords must have at least 16 characters;
        /// 3 - Passwords must have all the types of character, including lower, upper, numbers and symbols.
        /// 4 - Passwords can have maximum a sequence of 5 characters of the same type.
        /// 5 - E-Mails, Names, Phones, and other informations are going to be validated.
        /// 
        /// This is going to be a public method, used by the repository class.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool ValidateUserOnCreate(ApplicationUser user);
        /// <summary>
        /// Validate whether the user is at least 13 years old.
        /// 
        /// This is going to be a protected method, used only for another methods.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        bool ValidateBirthDate(DateTime date);
        /// <summary>
        /// This method is responsible from calling all the other methods involving password validation.
        /// 
        /// 1 - Passwords must have at least 16 characters;
        /// 2 - Passwords must have all the types of character, including lower, upper, numbers and symbols.
        /// 3 - Passwords can have maximum a sequence of 5 characters of the same type.
        /// 
        /// This is going to be a protected method, used only for the method ValidateUserOnCreate 
        /// <seealso cref="ValidateUserOnCreate(ApplicationUser)"/>
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        bool ValidatePassword(string password);
        /// <summary>
        /// When the user is going to Log into the aplication, this is going to verify whether he is blocked.
        /// If the user is blocked, the user cannot log into the application.
        /// 
        /// This method is going to be used at repository class, in the method "Login"
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool IsBlocked(ApplicationUser user);
        /// <summary>
        /// Verifies if the password has lower, upper, numbers and symbols.
        /// 
        /// This is going to be a protected method, used only for the method ValidateUserOnCreate 
        /// <seealso cref="ValidateUserOnCreate(ApplicationUser)"/>
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        string ContainsAllCharacterTypes(string password);
        /// <summary>
        /// User's passwords must have at least 16 characters.
        /// 
        /// This is going to be a protected method, used only for the method ValidateUserOnCreate 
        /// <seealso cref="ValidateUserOnCreate(ApplicationUser)"/>
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        bool ContainsAtLeastEightCharacters(string password);
        /// <summary>
        /// Verifies whether the password contains in a sequence 5 Characters of the same type.
        /// 
        /// Invalid Password ❌ - Gustavo - 6 lower letters in a sequence
        /// Valid Password ✅ - GuStAvO
        /// 
        /// This is going to be a protected method, used only for the method ValidateUserOnCreate 
        /// <seealso cref="ValidateUserOnCreate(ApplicationUser)"/>
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        bool ContainsMaximumFiveCharactersOfTheSameTypeInASequence(string password);
        /// <summary>
        /// This method is responsible to validate the user's name.
        /// 
        /// This is going to be a protected method, used only for the method ValidateUserOnCreate 
        /// <seealso cref="ValidateUserOnCreate(ApplicationUser)"/>
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        bool ValidateFullName(string name);
        /// <summary>
        /// This method is responsible to validate the user's e-mail.
        /// 
        /// This is going to be a protected method, used only for the method ValidateUserOnCreate 
        /// <seealso cref="ValidateUserOnCreate(ApplicationUser)"/>
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        bool ValidateEmail(string email);
        /// <summary>
        /// This method is responsible from phone number's validations.
        /// 
        /// This is going to be a protected method, used only for the method ValidateUserOnCreate 
        /// <seealso cref="ValidateUserOnCreate(ApplicationUser)"/>
        /// </summary>
        /// <param name="phoneNumer"></param>
        /// <returns></returns>
        bool ValidatePhoneNumber(string phoneNumer);
        /// <summary>
        /// This method is responsible from educational degree's validations.
        /// 
        /// This is going to be a protected method, used only for the method ValidateUserOnCreate 
        /// <seealso cref="ValidateUserOnCreate(ApplicationUser)"/>
        /// </summary>
        /// <param name="degree"></param>
        /// <returns></returns>
        bool ValidateEducationDegree(string degree);
        /// <summary>
        /// This method is responsible from course's validations.
        /// 
        /// This is going to be a protected method, used only for the method ValidateUserOnCreate 
        /// <seealso cref="ValidateUserOnCreate(ApplicationUser)"/>
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        bool ValidateActualCourse(string course);
        /// <summary>
        /// This method is responsible to verify whether the user must be blocked or not. The domain layer is
        /// responsible for business logic, so, using a controller I can orchestrate logics between blocking or
        /// unblocking a user.
        /// 
        /// This method is going to be public.
        /// </summary>
        /// <param name="errosSenha"></param>
        /// <returns></returns>
        bool ShouldBlockUser(int errosSenha);
    }
}
