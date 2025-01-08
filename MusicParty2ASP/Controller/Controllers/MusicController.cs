using Application.UseCases.Music;
using Application.UseCases.Song;
using Application.UseCases.Song.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MusicParty2.Controllers;

[ApiController]
[Route("api/musics")]
public class MusicController : ControllerBase
{
    private readonly UseCaseFetchAllMusics _useCaseFetchAllMusics;
    private readonly UseCaseCreateMusic _useCaseCreateMusic;
    private readonly UseCaseDeleteMusic _useCaseDeleteMusic;
    private readonly UseCaseFetchTop10Musics _useCaseFetchTop10Musics;

    public MusicController(UseCaseDeleteMusic useCaseDeleteMusic, UseCaseCreateMusic useCaseCreateMusic, UseCaseFetchAllMusics useCaseFetchAllMusics, UseCaseFetchTop10Musics useCaseFetchTop10Musics)
    {
        _useCaseDeleteMusic = useCaseDeleteMusic;
        _useCaseCreateMusic = useCaseCreateMusic;
        _useCaseFetchAllMusics = useCaseFetchAllMusics;
        _useCaseFetchTop10Musics = useCaseFetchTop10Musics;
    }

    [HttpGet]
    public ActionResult<IEnumerable<DtoOutputMusic>> FetchAll()
    {
        return Ok(_useCaseFetchAllMusics.Execute());
    }
    
    [HttpGet("top10")]
    public ActionResult<IEnumerable<DtoOutputMusic>> FetchTop10Musics()
    {
        return Ok(_useCaseFetchTop10Musics.Execute());
    }

    [HttpPost]
    public ActionResult<DtoOutputMusic> Create(DtoInputMusic input)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        try
        {
            return Ok(_useCaseCreateMusic.Execute(input));
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { message = ex.Message });
        }
    }
    
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        return Ok(_useCaseDeleteMusic.Execute(id));
    }
}