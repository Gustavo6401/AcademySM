namespace Groups.Domain.Models.SqlServerModels
{
    public class Message
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public DateTime DateSent { get; set; }

        public ApplicationUser? User { get; set; }
        public Guid UserId { get; set; }

        public Conversation? Conversation { get; set; }
        public int ConversationId { get; set; }
    }
}
