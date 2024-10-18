using Groups.Domain.Interfaces.ApplicationServices;
using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels;

namespace Groups.Presentation.ApplicationServices
{
    public class DoubtVoteApplicationServices : IDoubtVoteApplicationServices
    {
        private readonly IDoubtVoteRepository _repository;
        public DoubtVoteApplicationServices(IDoubtVoteRepository repository)
        {
            _repository = repository;
        }
        public async Task Create(DoubtVote vote)
        {
            await _repository.Create(vote);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<DoubtVote> Get(int id)
        {
            DoubtVote vote = await _repository.Get(id);

            return vote;
        }

        public async Task<List<DoubtVote>> GetByDoubt(int doubtId)
        {
            List<DoubtVote> list = await _repository.GetAllVotes(doubtId);

            return list;
        }

        public async Task<int> Index(int doubtId)
        {
            List<DoubtVote> list = await GetByDoubt(doubtId);

            // Gets a list of all upvotes.
            List<DoubtVote> upvotes = list.Where(dv => dv.Vote == "Up").ToList();
            List<DoubtVote> downvotes = list.Where(dv => dv.Vote == "Down").ToList();

            // This works like Quora or Reddit upovtes, gets all of the votes and put it into a list.
            int total = upvotes.Count - downvotes.Count;

            return total;
        }

        public async Task Update(DoubtVote vote)
        {
            await _repository.Update(vote);
        }
    }
}
