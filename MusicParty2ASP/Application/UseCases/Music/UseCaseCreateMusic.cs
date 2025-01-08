using Application.UseCases.Song.Dtos;
using Application.UseCases.Utils;
using AutoMapper;
using Infrastructure.Repositories;

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
        var music = _mapper.Map<Domain.Music>(input);
        var dbMusic = _musicRepository.Create(music.Title, music.Type, music.YoutubeUrl, music.UserId);
        return _mapper.Map<DtoOutputMusic>(dbMusic);
    }
}