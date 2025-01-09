using Infrastructure.DbEntities;

namespace Infrastructure.Repositories;

public interface IMusicRepository
{
    IEnumerable<DbMusic> FetchAll();
    IEnumerable<DbMusic> FetchTop10Musics();
    DbMusic Create(string title, string author, string type, string youtubeUrl, int userId);
    bool Delete(int id);
}