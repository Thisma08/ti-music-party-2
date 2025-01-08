using Application.UseCases.Utils;
using AutoMapper;
using Infrastructure.Repositories;

namespace Application.UseCases.Music;

public class UseCaseDeleteMusic : IUseCaseParametrizedQuery<bool, int>
{
    private readonly IMusicRepository _musicRepository;
    private readonly IMapper _mapper;

    public UseCaseDeleteMusic(IMusicRepository musicRepository, IMapper mapper)
    {
        _musicRepository = musicRepository;
        _mapper = mapper;
    }

    public bool Execute(int id)
    {
        return _musicRepository.Delete(id);
    }
}