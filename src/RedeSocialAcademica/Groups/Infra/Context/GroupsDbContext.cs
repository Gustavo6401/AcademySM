using Groups.Domain.Models.SqlServerModels;
using Groups.Domain.Models.SqlServerModels.Aggregations;
using Microsoft.EntityFrameworkCore;

namespace Groups.Infra.Context
{
    public class GroupsDbContext : DbContext
    {
        public GroupsDbContext(DbContextOptions<GroupsDbContext> options) : base(options) { }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ApplicationUser> User { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Article> Article { get; set; }
        public DbSet<Doubt> Doubts { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Conversation> Conversation { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<PostVote> PostVote { get; set; }
        public DbSet<CategoryGroups> CategoryGroups { get; set; }
        public DbSet<GroupsUsers> GroupsUsers { get; set; }
        public DbSet<AssignmentSent> AssignmentsSents { get; set; }
        public DbSet<Answer> Answer { get; set; }
        public DbSet<DoubtVote> DoubtVote { get; set; }
        public DbSet<PostFile> PostFile { get; set; }
        public DbSet<ConversationsUsers> ConversationsUsers { get; set; }
        public DbSet<AssignmentFile> AssignmentFile { get; set; }
        public DbSet<DoubtFile> DoubtFiles { get; set; }
        public DbSet<AnswerVote> AnswerVote { get; set; }
        public DbSet<AnswerComment> AnswerComment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Category>()
                .Property(c => c.Name)
                    .IsRequired()
                        .HasMaxLength(50);

            modelBuilder.Entity<Category>()
                .Property(c => c.MainCategory)
                    .IsRequired()
                        .HasMaxLength(100);

            modelBuilder.Entity<Category>()
                .Property(c => c.Icon)
                    .IsRequired()
                        .HasMaxLength(100);

            modelBuilder.Entity<Courses>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Courses>()
                .Property(c => c.Name)
                    .IsRequired()
                        .HasMaxLength(200);

            modelBuilder.Entity<Courses>()
                .Property(c => c.IsPublic)
                    .IsRequired();

            modelBuilder.Entity<ApplicationUser>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<ApplicationUser>()
                .Property(u => u.Id)
                    .ValueGeneratedNever();

            modelBuilder.Entity<ApplicationUser>()
                .Property(u => u.Name)
                    .IsRequired()
                        .HasMaxLength(100);

            modelBuilder.Entity<ApplicationUser>()
                .Property(u => u.EducationalBackground)                    
                        .HasMaxLength(30);

            modelBuilder.Entity<ApplicationUser>()
                .Property(u => u.Institution)
                        .HasMaxLength(100);

            modelBuilder.Entity<ApplicationUser>()
                .Property(u => u.CourseName)
                        .HasMaxLength(100);

            modelBuilder.Entity<ApplicationUser>()
                .Property(u => u.ProfilePicFilePath)
                    .HasMaxLength(300);

            modelBuilder.Entity<Announcement>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Announcement>()
                .Property(a => a.AnnouncementText)
                    .IsRequired()
                        .HasMaxLength(5000);

            modelBuilder.Entity<Announcement>()
                .Property(a => a.DateAnnouncement)
                    .IsRequired();

            modelBuilder.Entity<Article>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Article>()
                .Property(a => a.Title)
                    .IsRequired()
                        .HasMaxLength(200);

            modelBuilder.Entity<Article>()
                .Property(a => a.FilePath)
                    .IsRequired()
                        .HasMaxLength(200);

            modelBuilder.Entity<Article>()
                .Property(a => a.DateCreation)
                    .IsRequired();

            modelBuilder.Entity<Doubt>()
                .HasKey(d => d.Id);

            modelBuilder.Entity<Doubt>()
                .Property(d => d.Title)
                    .IsRequired()
                        .HasMaxLength(250);

            modelBuilder.Entity<Doubt>()
                .Property(d => d.Content)
                    .IsRequired()
                        .HasMaxLength(10000);

            modelBuilder.Entity<Post>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Post>()
                .Property(p => p.Title)
                    .IsRequired()
                        .HasMaxLength(250);

            modelBuilder.Entity<Post>()
                .Property(p => p.DateCreation)
                    .IsRequired();

            modelBuilder.Entity<Post>()
                .Property(p => p.Content)
                    .IsRequired()
                        .HasMaxLength(10000);

            modelBuilder.Entity<Conversation>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Conversation>()
                .Property(c => c.Title)
                    .IsRequired()
                        .HasMaxLength(250);

            modelBuilder.Entity<Message>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<Message>()
                .Property(m => m.Content)
                    .IsRequired()
                        .HasMaxLength(5000);

            modelBuilder.Entity<Comment>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Comment>()
                .Property(c => c.Content)
                    .IsRequired()
                        .HasMaxLength(5000);

            modelBuilder.Entity<Comment>()
                .Property(c => c.DateCreation)
                    .IsRequired();

            modelBuilder.Entity<PostVote>()
                .HasKey(pv => pv.Id);

            modelBuilder.Entity<PostVote>()
                .Property(pv => pv.Vote)
                    .IsRequired()
                        .HasMaxLength(4);

            modelBuilder.Entity<PostVote>()
                .Property(pv => pv.VoteDate)
                    .IsRequired();

            modelBuilder.Entity<GroupsUsers>()
                .HasKey(gu => gu.Id);

            modelBuilder.Entity<GroupsUsers>()
                .Property(gu => gu.Role)
                    .IsRequired()
                        .HasMaxLength(15);

            modelBuilder.Entity<AssignmentSent>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<AssignmentSent>()
                .Property(a => a.FilePath)
                    .IsRequired()
                        .HasMaxLength(250);

            modelBuilder.Entity<Answer>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Answer>()
                .Property(a => a.Title)
                    .IsRequired()
                        .HasMaxLength(250);

            modelBuilder.Entity<Answer>()
                .Property(a => a.Content)
                    .IsRequired()
                        .HasMaxLength(10000);

            modelBuilder.Entity<Answer>()
                .Property(a => a.DateCreation)
                    .IsRequired();

            modelBuilder.Entity<DoubtVote>()
                .HasKey(dv => dv.Id);

            modelBuilder.Entity<DoubtVote>()
                .Property(dv => dv.Vote)
                    .IsRequired()
                        .HasMaxLength(4);

            modelBuilder.Entity<DoubtVote>()
                .Property(dv => dv.DateVote)
                    .IsRequired();

            modelBuilder.Entity<PostFile>()
                .HasKey(pf => pf.Id);

            modelBuilder.Entity<PostFile>()
                .Property(pf => pf.RelativePath)
                    .IsRequired()
                        .HasMaxLength(250);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Groups)
                    .WithMany(g => g.Categories)
                        .UsingEntity<CategoryGroups>();

            modelBuilder.Entity<Courses>()
                .HasMany(c => c.Users)
                    .WithMany(u => u.Groups)
                        .UsingEntity<GroupsUsers>();

            modelBuilder.Entity<Courses>()
                .HasMany(c => c.Announcements)
                    .WithOne(a => a.Group)
                        .HasForeignKey(a => a.GroupId)
                            .IsRequired()
                                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Courses>()
                .HasMany(c => c.Articles)
                    .WithOne(a => a.Group)
                        .HasForeignKey(a => a.GroupId)
                            .IsRequired()
                                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(c => c.Articles)
                    .WithOne(a => a.User)
                        .HasForeignKey(a => a.UserId)
                            .IsRequired()
                                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Courses>()
                .HasMany(c => c.Doubts)
                    .WithOne(d => d.Group)
                        .HasForeignKey(a => a.GroupId)
                            .IsRequired()
                                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Courses>()
                .HasMany(c => c.Assignments)
                    .WithOne(d => d.Group)
                        .HasForeignKey(a => a.GroupId)
                            .IsRequired()
                                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(c => c.Doubts)
                    .WithOne(d => d.User)
                        .HasForeignKey(a => a.UserId)
                            .IsRequired()
                                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Courses>()
                .HasMany(c => c.Posts)
                    .WithOne(p => p.Group)
                        .HasForeignKey(a => a.GroupId)
                            .IsRequired()
                                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Posts)
                    .WithOne(p => p.User)
                        .HasForeignKey(a => a.UserId)
                            .IsRequired()
                                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Conversations)
                    .WithMany(c => c.Users)
                        .UsingEntity<ConversationsUsers>();

            modelBuilder.Entity<Conversation>()
                .HasMany(c => c.Messages)
                    .WithOne(p => p.Conversation)
                        .HasForeignKey(a => a.ConversationId)
                            .IsRequired()
                                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Messages)
                    .WithOne(p => p.User)
                        .HasForeignKey(a => a.UserId)
                            .IsRequired()
                                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Post>()
                .HasMany(c => c.Files)
                    .WithOne(p => p.Post)
                        .HasForeignKey(a => a.PostId)
                            .IsRequired()
                                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Post>()
                .HasMany(c => c.Comments)
                    .WithOne(p => p.Post)
                        .HasForeignKey(a => a.PostId)
                            .IsRequired()
                                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Post>()
                .HasMany(c => c.Votes)
                    .WithOne(p => p.Post)
                        .HasForeignKey(a => a.PostId)
                            .IsRequired()
                                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Comments)
                    .WithOne(p => p.User)
                        .HasForeignKey(a => a.UserId)
                            .IsRequired()
                                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.PostVotes)
                    .WithOne(p => p.User)
                        .HasForeignKey(a => a.UserId)
                            .IsRequired()
                                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Assignment>()
                .HasMany(c => c.Sents)
                    .WithOne(p => p.Assignment)
                        .HasForeignKey(a => a.AssignmentId)
                            .IsRequired()
                                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Assignments)
                    .WithOne(p => p.User)
                        .HasForeignKey(a => a.UserId)
                            .IsRequired()
                                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Doubt>()
                .HasMany(c => c.Votes)
                    .WithOne(p => p.Doubt)
                        .HasForeignKey(a => a.DoubtId)
                            .IsRequired()
                                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Doubt>()
                .HasMany(c => c.Answers)
                    .WithOne(p => p.Doubt)
                        .HasForeignKey(a => a.DoubtId)
                            .IsRequired()
                                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Answers)
                    .WithOne(p => p.User)
                        .HasForeignKey(a => a.UserId)
                            .IsRequired()
                                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.DoubtVotes)
                    .WithOne(p => p.User)
                        .HasForeignKey(a => a.UserId)
                            .IsRequired()
                                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.AnswerComments)
                    .WithOne(ac => ac.User)
                        .HasForeignKey(ac => ac.UserId)
                            .IsRequired()
                                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.AnswerVote)
                    .WithOne(av => av.User)
                        .HasForeignKey(av => av.UserId)
                            .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
