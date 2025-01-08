using Infrastructure.DbEntities;
 using Microsoft.EntityFrameworkCore;
 
 namespace Infrastructure.Repositories;
 
 public class VoteRepository: IVoteRepository
 {
     private readonly AppDbContext _context;
 
     public VoteRepository(AppDbContext context)
     {
         _context = context;
     }
     
     public async Task<DbVote> Create(int userId, int musicId)
     {
         var vote = new DbVote
         {
             UserId = userId,
             MusicId = musicId
         };
         _context.Votes.Add(vote);
         await _context.SaveChangesAsync();
         return vote;
     }
     
     public async Task<DbUser> FetchUserById(int userId)
     {
         return await _context.Users.FindAsync(userId);
     }

     public async Task<DbMusic> FetchMusicById(int musicId)
     {
         return await _context.Musics.FindAsync(musicId);
     }
     
     public async Task<int> CountVotesForMusic(int musicId)
     {
         return await _context.Votes.CountAsync(v => v.MusicId == musicId);
     }
 }