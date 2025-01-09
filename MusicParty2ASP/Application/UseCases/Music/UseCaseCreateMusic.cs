using Application.UseCases.Song.Dtos;
using Application.UseCases.Utils;
using AutoMapper;
using Infrastructure.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Music;

public class UseCaseCreateMusic : IUseCaseWriter<DtoOutputMusic, DtoInputMusic>
{
    private readonly IMusicRepository _musicRepository;
    private readonly IMapper _mapper;

    public UseCaseCreateMusic(IMusicRepository musicRepository, IMapper mapper)
    {
        _musicRepository = musicRepository;
        _mapper = mapper;
    }

    public DtoOutputMusic Execute(DtoInputMusic input)
    {
        try
        {
            var music = _mapper.Map<Domain.Music>(input);
            var dbMusic = _musicRepository.Create(music.Title, music.Type, music.YoutubeUrl, music.UserId);
            return _mapper.Map<DtoOutputMusic>(dbMusic);
        }
        catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlEx && sqlEx.Number == 2627)
        {
            throw new InvalidOperationException("A music with the same title already exists.", ex);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"An error occurred: {ex.Message}");
        }
    }
}