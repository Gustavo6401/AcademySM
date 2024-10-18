using Groups.Domain.Interfaces.Repositories.SqlServer.Base;
using Groups.Domain.Models.SqlServerModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Groups.Domain.Interfaces.Repositories.SqlServer
{
    public interface IDoubtVoteRepository : ISqlServerRepositoryBase<DoubtVote>
    {
        Task<List<DoubtVote>> GetAllVotes(int doubtId);
    }
}
