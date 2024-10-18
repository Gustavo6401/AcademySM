namespace CadastroUsuario.Domain.Models
{
    public class ApplicationUser
    {
        public Guid Id { get; set; }
        public string? FullName { get; set; }
        public string? EMail { get; set; }
        public string? Password { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Phone { get; set; }
        public string? EducationalDegree { get; set; }
        public string? ActualCourse { get; set; }
        public string? Curriculum { get; set; }
        public string? Institution { get; set; }
        public int PasswordErrors { get; set; }

        public ICollection<EducationalBackground>? EducationalBackgrounds { get; set; }
        public ICollection<UserLockout>? UserLockouts { get; set; }
        public ICollection<ProfilePic>? ProfilePictures { get; set; }
    }
}
