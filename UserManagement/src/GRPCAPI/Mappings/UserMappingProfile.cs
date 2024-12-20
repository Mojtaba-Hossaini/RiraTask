using Application.Commands;
using AutoMapper;
using Core.DTOs;
using UserManagementGRPC;

namespace API.Mappings;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<string, DateTime>().ConvertUsing<StringToDateTimeConverter>();
        CreateMap<CreateUserRequest, CreateUserCommand>().ReverseMap();
        CreateMap<User, CreateUserCommand>().ReverseMap();
        CreateMap<Core.Entities.User, User>().ReverseMap();
        CreateMap<UserDto, User>().ReverseMap();
        CreateMap<User, UpdateUserCommand>().ReverseMap();
    }
}
