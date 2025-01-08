using Application.UseCases.Vote.DTOs;
using AutoMapper;
using Infrastructure.Repositories;

namespace Application.UseCases.Vote;

public class UseCaseCountVotes
{
    private readonly IVoteRepository _voteRepository;
    private readonly IMapper _mapper;

    public UseCaseCountVotes(IVoteRepository repository, IMapper mapper)
    {
        _voteRepository = repository;
        _mapper = mapper;
    }

    public async Task<DtoOutputCountVotes> Execute(int musicId)
    {
        var voteCount = await _voteRepository.CountVotesForMusic(musicId);
        return new DtoOutputCountVotes
        {
            VoteCount = voteCount
        };
    }
}