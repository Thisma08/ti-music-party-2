using Application.UseCases.Music.Dtos;
using Application.UseCases.Utils;
using AutoMapper;
using Infrastructure.Repositories;

namespace Application.UseCases.Music;

public class UseCaseFetchTop10Musics : IUseCaseQuery<IEnumerable<DtoOutputMusic>>
{
    private readonly IMusicRepository _musicRepository;
    private readonly IMapper _mapper;

    public UseCaseFetchTop10Musics(IMusicRepository musicRepository, IMapper mapper)
    {
        _musicRepository = musicRepository;
        _mapper = mapper;
    }

    public IEnumerable<DtoOutputMusic> Execute()
    {
        var musics = _musicRepository.FetchTop10Musics();
        return _mapper.Map<IEnumerable<DtoOutputMusic>>(musics);
    }
}