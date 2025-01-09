using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.Music.Dtos;

public class DtoInputMusic
{
    [StringLength(100, MinimumLength = 2)]
    [Required]
    public string Title { get; set; }
    [StringLength(100, MinimumLength = 2)]
    [Required]
    public string Author { get; set; }
    [StringLength(50, MinimumLength = 2)]
    [Required]
    public string Type { get; set; }
    [RegularExpression(@"^(https?\:\/\/)?(www\.youtube\.com|youtu\.be)\/.+$")]
    [Required]
    [StringLength(500)]
    public string YoutubeUrl { get; set; }
    [Required]
    public int UserId { get; set; }
}