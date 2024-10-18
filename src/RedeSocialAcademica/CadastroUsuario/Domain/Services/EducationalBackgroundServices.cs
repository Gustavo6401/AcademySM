using CadastroUsuario.Domain.Interfaces.Services;
using CadastroUsuario.Domain.Models;

namespace CadastroUsuario.Domain.Services
{
    public class EducationalBackgroundServices : IEducationalBackgroundServices
    {
        public bool ValidateCourseBegin(DateTime begin, DateTime end)
        {
            if (begin >= end)
                throw new ArgumentException("A data de Início do Curso deve ser menor que a data de Finalização.");

            return true;
        }

        public bool ValidateCourseEndWetherCourseIsFinished(string status, DateTime date)
        {
            if (status == "Concluído" && date > DateTime.Today)
                throw new ArgumentException("Para um Curso Estar Concluído, ele precisa que a data final seja menor que a data de hoje.");

            return true;
        }

        public bool ValidateCourseName(string course)
        {
            if (string.IsNullOrWhiteSpace(course))
                throw new ArgumentException("Nome de Curso Inválido!");

            return true;
        }

        public bool ValidateEducationalBackground(string background)
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

            if (!listaGraisAcademicos.Contains(background))
            {
                throw new ArgumentException("Escolha uma das Opções de Formação!");
            }

            return true;
        }

        public bool ValidateInstitutionName(string institutionName)
        {
            if (string.IsNullOrWhiteSpace(institutionName))
                throw new ArgumentException("Nome de Instituição Inválido");

            return true;
        }

        public bool ValidateOnCreateEducationalBackground(EducationalBackground educationalBackground)
        {
            ValidateCourseName(educationalBackground.Course!);
            ValidateEducationalBackground(educationalBackground.EducationalDegree!);
            ValidateStatus(educationalBackground.Status!);
            ValidateCourseBegin(educationalBackground.CourseBegin, educationalBackground.CourseEnd);
            ValidateCourseEndWetherCourseIsFinished(educationalBackground.Status!, educationalBackground.CourseEnd);
            ValidateInstitutionName(educationalBackground.Institution!);

            return true;
        }

        public bool ValidateStatus(string status)
        {
            List<string> listStatus = new List<string>
            {
                "Concluído",
                "Trancado",
                "Cursando"
            };

            if (!listStatus.Contains(status))
            {
                throw new ArgumentException("Escolha uma das Opções de Formação!");
            }

            return true;
        }
    }
}
