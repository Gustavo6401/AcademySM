namespace Groups.Domain.Models.SqlServerModels
{
    public class Conversation
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        public ICollection<ApplicationUser>? Users { get; set; }
        public ICollection<Message>? Messages { get; set; }
    }
}
