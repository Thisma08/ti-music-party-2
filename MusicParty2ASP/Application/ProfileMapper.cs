using Application.UseCases.Music.Dtos;
using Application.UseCases.User.Dtos;
using Application.UseCases.Vote.DTOs;
using AutoMapper;
using Domain;
using Infrastructure.DbEntities;

namespace Application;

public class ProfileMapper: Profile
{
    public ProfileMapper()
    {
        CreateMap<User, DtoOutputUser>();
        CreateMap<DbUser, DtoOutputUser>();
        CreateMap<DbUser, User>();
        
        CreateMap<Music, DtoOutputMusic>();
        CreateMap<DbMusic, DtoOutputMusic>();
        CreateMap<DbMusic, Music>();
        CreateMap<DtoInputMusic, Music>();
        
        CreateMap<Vote, DtoOutputVote>();
        CreateMap<DbVote, DtoOutputVote>();
        CreateMap<DbVote, Vote>();
        CreateMap<DtoInputVote, Vote>();
    }
    
}