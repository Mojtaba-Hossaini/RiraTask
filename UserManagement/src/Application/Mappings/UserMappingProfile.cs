using AutoMapper;
using Core.DTOs;
using Core.Entities;

namespace Application.Mappings;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
}