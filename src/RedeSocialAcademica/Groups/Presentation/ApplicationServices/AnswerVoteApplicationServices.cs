using Groups.Domain.Interfaces.ApplicationServices;
using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels.Aggregations;

namespace Groups.Presentation.ApplicationServices
{
    public class AnswerVoteApplicationServices : IAnswerVoteApplicationServices
    {
        private readonly IAnswerVoteRepository _repository;
        public AnswerVoteApplicationServices(IAnswerVoteRepository repository)
        {
            _repository = repository;
        }
        public async Task Create(AnswerVote vote)
        {
            await _repository.Create(vote);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<List<AnswerVote>> GetByAnswerId(int answerId)
        {
            List<AnswerVote> list = await _repository.GetAllVotes(answerId);

            return list;
        }

        public async Task<AnswerVote> Get(int id)
        {
            AnswerVote vote = await _repository.Get(id);

            return vote;
        }

        public async Task<int> Index(int answerId)
        {
            List<AnswerVote> list = await GetByAnswerId(answerId);

            List<AnswerVote> upvotes = list.Where(av => av.Vote == "Up").ToList();
            List<AnswerVote> downvotes = list.Where(av => av.Vote == "Down").ToList();

            int total = upvotes.Count - downvotes.Count;

            return total;
        }

        public async Task Update(AnswerVote vote)
        {
            await _repository.Update(vote);
        }
    }
}
