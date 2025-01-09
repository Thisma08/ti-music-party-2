using Infrastructure.DbEntities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class MusicRepository : IMusicRepository
{
    private readonly AppDbContext _context;

    public MusicRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<DbMusic> FetchAll()
    {
        return _context.Musics.ToList();
    }
    
    public IEnumerable<DbMusic> FetchTop10Musics()
    {
        var top10Musics = _context.Musics
            .Select(music => new 
            {
                Music = music,
                VoteCount = _context.Votes.Count(vote => vote.MusicId == music.Id)
            })
            .OrderByDescending(m => m.VoteCount)
            .Take(10)
            .Select(m => m.Music)
            .ToList();

        return top10Musics;
    }
    
    public DbMusic? FetchByTitleAndAuthor(string title, string author)
    {
        return _context.Musics.FirstOrDefault(m => m.Title == title && m.Author == author);
    }

    public DbMusic Create(string title, string author, string type, string youtubeUrl, int userId)
    {
        var music = new DbMusic
        {
            Title = title,
            Author = author,
            Type = type,
            YoutubeUrl = youtubeUrl,
            UserId = userId
        };
        
        _context.Musics.Add(music); 
        _context.SaveChanges();

        return music;
    }

    public bool Delete(int id)
    {
        var music = _context.Musics.FirstOrDefault(m => m.Id == id);

        if (music == null)
        {
            return false;
        }
        
        _context.Musics.Remove(music);
        _context.SaveChanges();
        return true;
    }
}