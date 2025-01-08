namespace Application.UseCases.Song.Dtos;

public class DtoOutputMusic
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Type { get; set; }
    public string YoutubeUrl { get; set; }
    public int UserId { get; set; }
    public int VoteCount { get; set; }
}