using Infrastructure.DbEntities;

namespace Infrastructure.Repositories;

public interface IMusicRepository
{
    IEnumerable<DbMusic> FetchAll();
    IEnumerable<DbMusic> FetchTop10Musics();
    DbMusic? FetchByTitleAndAuthor(string title, string author);
    DbMusic Create(string title, string author, string type, string youtubeUrl, int userId);
    bool Delete(int id);
}