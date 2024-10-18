using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroUsuario.Domain.Models
{
    public class EducationalBackground
    {
        public Guid Id { get; set; }
        public string? Course { get; set; }
        public string? EducationalDegree { get; set; }
        public string? Status { get; set; }
        public string? Institution { get; set; }
        public DateTime CourseBegin { get; set; }
        public DateTime CourseEnd { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }
        public Guid UserId { get; set; }
    }
}
