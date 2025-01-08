namespace Domain;

public partial class Music
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string YoutubeUrl { get; set; } = null!;

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Vote> Votes { get; set; } = new List<Vote>();
}
