using CadastroUsuario.Domain.Models;

namespace CadastroUsuario.Domain.Interfaces.Services
{
    public interface IEducationalBackgroundServices
    {
        /// <summary>
        /// This method is responsible for validations in the class called EducationalBackground.
        /// 
        /// This method is going to be public.
        /// </summary>
        /// <param name="educationalBackground"></param>
        /// <returns></returns>
        bool ValidateOnCreateEducationalBackground(EducationalBackground educationalBackground);
        /// <summary>
        /// This is responsible for course name validations.
        /// 
        /// Course names must have at least one letter.
        /// 
        /// This method is going to be protected <seealso cref="ValidateOnCreateEducationalBackground(EducationalBackground)"/>
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        bool ValidateCourseName(string course);
        /// <summary>
        /// Verifies wether the Institution name is not null.
        /// 
        /// This method is going to be protected.
        /// </summary>
        /// <param name="institutionName"></param>
        /// <returns></returns>
        bool ValidateInstitutionName(string institutionName);
        /// <summary>
        /// The beginning of a course must be older than <see cref="DateTime.Now"/>
        /// 
        /// This method is going to be protected.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        bool ValidateCourseBegin(DateTime begin, DateTime end);
        /// <summary>
        /// This method is only applied if the course is already ended.
        /// 
        /// This method is going to be protected.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        bool ValidateCourseEndWetherCourseIsFinished(string status, DateTime data);
        /// <summary>
        /// Validates whether the educational background is one of cited above:
        /// 
        /// 1 - Ensino Fundamental 1
        /// 2 - Ensino Fundamental 2
        /// 3 - Ensino Médio
        /// 4 - Ensino Médio Técnico
        /// 5 - Ensino Superior
        /// 6 - Pós-Graduação
        /// 7 - Mestrado
        /// 8 - Doutorado
        /// </summary>
        /// <param name="background"></param>
        /// <returns></returns>
        bool ValidateEducationalBackground(string background);
        /// <summary>
        /// The educational background must have one of the following status:
        /// 
        /// 1 - Cursando
        /// 2 - Trancado
        /// 3 - Concluído
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        bool ValidateStatus(string status);
    }
}
