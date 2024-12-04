namespace CadastroUsuario.Domain.Models.API
{
    public class UserPortfolio
    {
        public Guid UserId { get; set; }
        public string? UserName { get; set; }
        public string? Curriculum { get; set; }
        public string? ProfilePic { get; set; }

        public List<PortfolioCourses>? Courses { get; set; }
        public List<PortfolioLink>? Links { get; set; }
        public List<ParticipantGroup>? AcademySMGroups { get; set; }
    }
}
