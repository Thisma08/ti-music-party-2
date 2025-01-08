namespace Infrastructure.DbEntities;

public partial class DbVote
{
    public int UserId { get; set; }

    public int MusicId { get; set; }
    
    public virtual DbMusic DbMusic { get; set; } = null!;

    public virtual DbUser DbUser { get; set; } = null!;
}
