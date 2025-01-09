namespace Infrastructure.DbEntities;

public partial class DbMusic
{ 
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Author { get; set; } = null!;

    public string Type { get; set; } = null!;
    public string YoutubeUrl { get; set; } = null!;
    public int UserId { get; set; }

    public virtual DbUser DbUser { get; set; } = null!;

    public virtual ICollection<DbVote> Votes { get; set; } = new List<DbVote>();
}
