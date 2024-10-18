using Groups.Domain.Models.SqlServerModels.Aggregations;

namespace Groups.Domain.Models.SqlServerModels
{
    public class ApplicationUser
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? EducationalBackground { get; set; }
        public string? Institution { get; set; }
        public string? CourseName { get; set; }
        public string? ProfilePicFilePath { get; set; }

        public ICollection<Courses>? Groups { get; set; }
        public ICollection<Post>? Posts { get; set; }
        public ICollection<Doubt>? Doubts { get; set; }
        public ICollection<PostVote>? PostVotes { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<Article>? Articles { get; set; }
        public ICollection<Conversation>? Conversations { get; set; }
        public ICollection<Message>? Messages { get; set; }
        public ICollection<AssignmentSent>? Assignments { get; set; }
        public ICollection<Answer>? Answers { get; set; }
        public ICollection<DoubtVote>? DoubtVotes { get; set; }
        public ICollection<AnswerComment>? AnswerComments { get; set; }
        public ICollection<AnswerVote>? AnswerVote { get; set; }
    }
}
