namespace Domain;

public partial class Vote
{
    public int UserId { get; set; }

    public int MusicId { get; set; }
    
    public virtual Music Music { get; set; } = null!;

    public virtual User User { get; set; } = null!;
    
    public void ValidateVote(User user)
    {
        if (Music.UserId == user.Id)
        {
            throw new InvalidOperationException("A user cannot vote for their own music.");
        }
    }
}
