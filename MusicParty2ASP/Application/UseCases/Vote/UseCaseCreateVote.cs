using Application.UseCases.Vote.DTOs;
using AutoMapper;
using Domain;
using Infrastructure.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Vote;

public class UseCaseCreateVote
{
    private readonly IVoteRepository _voteRepository;
    private readonly IMapper _mapper;

    public UseCaseCreateVote(IVoteRepository repository, IMapper mapper)
    {
        _voteRepository = repository;
        _mapper = mapper;
    }
    
    public async Task<DtoOutputVote> Execute(DtoInputVote input)
    {
        if (input == null)
            throw new ArgumentNullException(nameof(input));
        
        var dbUser = await _voteRepository.FetchUserById(input.UserId);
        var dbMusic = await _voteRepository.FetchMusicById(input.MusicId);
        
        var user = _mapper.Map<Domain.User>(dbUser);
        var music = _mapper.Map<Domain.Music>(dbMusic);
        
        var vote = new Domain.Vote
        {
            UserId = input.UserId,
            MusicId = input.MusicId,
            Music = music,
            User = user
        };
        
        vote.ValidateVote(user);

        try
        {
            await _voteRepository.Create(input.UserId, input.MusicId);
        }
        catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlEx && sqlEx.Number == 2627)
        {
            throw new InvalidOperationException("This vote already exists.");
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"An error occurred: {ex.Message}");
        }
        
        return new DtoOutputVote
        {
            UserId = input.UserId,
            MusicId = input.MusicId,
            Message = "Vote created successfully!"
        };
        
    }
}