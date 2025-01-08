namespace Domain;

public partial class User
{
    public int Id { get; set; }

    public string Pseudo { get; set; } = null!;

    public virtual ICollection<Music> Musics { get; set; } = new List<Music>();

    public virtual ICollection<Vote> Votes { get; set; } = new List<Vote>();
}
