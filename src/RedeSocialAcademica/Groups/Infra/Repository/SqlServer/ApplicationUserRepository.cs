using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.API;
using Groups.Domain.Models.SqlServerModels;
using Groups.Domain.Models.SqlServerModels.Aggregations;
using Groups.Infra.Context;
using Groups.Infra.Repository.SqlServer.Base;
using Microsoft.EntityFrameworkCore;

namespace Groups.Infra.Repository.SqlServer
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly GroupsDbContext _context;
        public ApplicationUserRepository(GroupsDbContext context)
        {
            _context = context;
        }

        public async Task Create(ApplicationUser user)
        {
            _context.User.Add(user);

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// en
        /// This method is important to LGPD law, we are looking for all user's contributions in 
        /// our website.
        /// 
        /// pt-Br
        /// Esse método é importante pela LGPD. Nós buscamos todas as contribuições do usuário no nosso site.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(Guid id)
        {
            ApplicationUser user = await Get(id);
            List<Answer>? answers = await _context.Answer.Where(a => a.UserId == id)
                .ToListAsync();
            List<Article>? articles = await _context.Article.Where(a => a.UserId == id)
                .ToListAsync();
            List<Comment>? comments = await _context.Comments.Where(c => c.UserId == id)
                .ToListAsync();
            List<Doubt>? doubts = await _context.Doubts.Where(d => d.UserId == id)
                .ToListAsync();
            List<DoubtVote>? doubtVotes = await _context.DoubtVote.Where(dv => dv.UserId == id)
                .ToListAsync();
            List<Message>? messages = await _context.Messages.Where(m => m.UserId == id)
                .ToListAsync();
            List<Post>? posts = await _context.Posts.Where(p => p.UserId == id)
                .ToListAsync();
            List<PostVote> postVotes = await _context.PostVote.Where(pv => pv.UserId == id)
                .ToListAsync();
            List<AnswerComment> answerComments = await _context.AnswerComment.Where(ac => ac.UserId == id)
                .ToListAsync();
            List<AnswerVote> answerVotes = await _context.AnswerVote.Where(av => av.UserId == id)
                .ToListAsync();
            List<AssignmentSent> assignmentSents = await _context.AssignmentsSents.Where(ass => ass.UserId == id)
                .ToListAsync();
            List<ConversationsUsers> conversationsUsers = await _context.ConversationsUsers.Where(cu => cu.UserId == id)
                .ToListAsync();
            List<GroupsUsers> groupsUsers = await _context.GroupsUsers.Where(gu => gu.UserId == id)
                .ToListAsync();

            _context.User.Remove(user);
            _context.Answer.RemoveRange(answers);
            _context.Article.RemoveRange(articles);
            _context.Comments.RemoveRange(comments);
            _context.Doubts.RemoveRange(doubts);
            _context.DoubtVote.RemoveRange(doubtVotes);
            _context.Messages.RemoveRange(messages);
            _context.Posts.RemoveRange(posts);
            _context.PostVote.RemoveRange(postVotes);
            _context.AnswerComment.RemoveRange(answerComments);
            _context.AssignmentsSents.RemoveRange(assignmentSents);
            _context.ConversationsUsers.RemoveRange(conversationsUsers);
            _context.GroupsUsers.RemoveRange(groupsUsers);

            await _context.SaveChangesAsync();
        }

        public async Task<ApplicationUser> Get(Guid id)
        {
            ApplicationUser? user = await _context.User.FindAsync(id);

            return user!;
        }
        public async Task Update(ApplicationUser user)
        {
            _context.User.Update(user);

            await _context.SaveChangesAsync();
        }
    }
}
