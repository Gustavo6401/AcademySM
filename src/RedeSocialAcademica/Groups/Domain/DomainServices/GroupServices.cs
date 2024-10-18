using Groups.Domain.Interfaces.DomainServices;
using Groups.Domain.Models.SqlServerModels;

namespace Groups.Domain.DomainServices
{
    public class GroupServices : IGroupServices
    {
        public bool ValidateDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Descrição do Grupo Inválida!");

            return true;
        }

        public bool ValidateLevel(string level)
        {
            List<string> dificulties = new List<string>
            {
                "Básico",
                "Intermediário",
                "Avançado"
            };

            if (!dificulties.Contains(level))
                throw new ArgumentException("Descrição do Grupo Inválida!");

            return true;
        }

        public bool ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Descrição do Grupo Inválida!");

            return true;
        }

        public bool ValidateOnCreate(Courses course)
        {
            ValidateDescription(course.Description!);
            ValidateLevel(course.Level!);
            ValidateName(course.Name!);
            ValidateTutorName(course.Tutor!);

            return true;
        }

        public bool ValidateTutorName(string tutor)
        {
            if (string.IsNullOrWhiteSpace(tutor))
                throw new ArgumentException("Descrição do Grupo Inválida!");

            return true;
        }
    }
}
