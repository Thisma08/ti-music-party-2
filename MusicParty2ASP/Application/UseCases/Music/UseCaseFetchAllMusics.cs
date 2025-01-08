using Application.UseCases.Song.Dtos;
using Application.UseCases.Utils;
using AutoMapper;
using Infrastructure.Repositories;

namespace Application.UseCases.Music;

public class UseCaseFetchAllMusics : IUseCaseQuery<IEnumerable<DtoOutputMusic>>
{
    private readonly IMusicRepository _musicRepository;
    private readonly IMapper _mapper;

    public UseCaseFetchAllMusics(IMusicRepository musicRepository, IMapper mapper)
    {
        _musicRepository = musicRepository;
        _mapper = mapper;
    }

    public IEnumerable<DtoOutputMusic> Execute()
    {
        var musics = _musicRepository.FetchAll();
        return _mapper.Map<IEnumerable<DtoOutputMusic>>(musics);
    }
}