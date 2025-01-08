using Infrastructure.DbEntities;

namespace Infrastructure.Repositories;

public interface IVoteRepository
{
    Task<DbVote> Create(int userId, int musicId);
    Task<DbUser> FetchUserById(int userId);
    Task<DbMusic> FetchMusicById(int musicId);
    Task<int> CountVotesForMusic(int musicId);
}