using Application.UseCases.Vote;
using Application.UseCases.Vote.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace MusicParty2.Controllers;

[ApiController]
[Route("api/votes")]
public class VoteController : ControllerBase
{
    private readonly UseCaseCreateVote _useCaseCreateVote;
    private readonly UseCaseCountVotes _useCaseCountVotes;


    public VoteController(UseCaseCreateVote useCaseCreateVote, UseCaseCountVotes useCaseCountVotes)
    {
        _useCaseCreateVote = useCaseCreateVote;
        _useCaseCountVotes = useCaseCountVotes;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> CountVotes(int id)
    {
        var output = await _useCaseCountVotes.Execute(id);
        return Ok(output);
    }

    [HttpPost]
    public async Task<IActionResult> CreateVote([FromBody] DtoInputVote input)
    {
        if (input == null)
        {
            return BadRequest("Input cannot be null.");
        }
        try
        {
            var output = await _useCaseCreateVote.Execute(input);
            return Ok(output);
        }
        catch (ArgumentException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }
}
