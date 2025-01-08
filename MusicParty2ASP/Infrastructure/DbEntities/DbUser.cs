namespace Infrastructure.DbEntities;

public partial class DbUser
{
    public int Id { get; set; }

    public string Pseudo { get; set; } = null!;

    public virtual ICollection<DbMusic> Musics { get; set; } = new List<DbMusic>();

    public virtual ICollection<DbVote> Votes { get; set; } = new List<DbVote>();
}
