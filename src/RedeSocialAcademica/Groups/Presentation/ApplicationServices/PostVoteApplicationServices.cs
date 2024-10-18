using Groups.Domain.Interfaces.ApplicationServices;
using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels;

namespace Groups.Presentation.ApplicationServices
{
    public class PostVoteApplicationServices : IPostVoteApplicationServices
    {
        private readonly IPostVoteRepository _repository;
        public PostVoteApplicationServices(IPostVoteRepository repository)
        {
            _repository = repository;
        }
        public async Task Create(PostVote vote)
        {
            await _repository.Create(vote);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<PostVote> Get(int id)
        {
            PostVote vote = await _repository.Get(id);

            return vote;
        }

        public async Task<List<PostVote>> GetAllPostVotes(int postId)
        {
            List<PostVote> list = await _repository.GetAllPostVotes(postId);

            return list;
        }

        public async Task<int> Index(int postId)
        {
            List<PostVote> list = await GetAllPostVotes(postId);

            List<PostVote> upvotes = list.Where(dv => dv.Vote == "Up").ToList();
            List<PostVote> downvotes = list.Where(dv => dv.Vote == "Down").ToList();

            // This works like Quora or Reddit upovtes, gets all of the votes and put it into a list.
            int total = upvotes.Count - downvotes.Count;

            return total;
        }

        public async Task Update(PostVote vote)
        {
            await _repository.Update(vote);
        }
    }
}
