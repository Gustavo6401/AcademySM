namespace Groups.Domain.Models.SqlServerModels.Aggregations
{
    public class ConversationsUsers
    {
        public int Id { get; set; }
        public string? ConversationRole { get; set; }

        public Guid UserId { get; set; }
        public int ConversationId { get; set; }

        public ApplicationUser? User { get; set; }
        public Conversation? Conversation { get; set; }
    }
}
