using Application.Commands;
using AutoMapper;
using Core.Contracts;
using Core.DTOs;
using Core.Entities;
using Core.Exceptions;
using MediatR;

namespace Application.Handlers;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper mapper;

    public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        this.mapper = mapper;
    }

    public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Name = request.Name,
            Family = request.Family,
            NationalCode = request.NationalCode,
            Birthday = request.Birthday
        };

        try
        {
            var userSaved = await _userRepository.CreateUserAsync(user, cancellationToken);
            return mapper.Map<UserDto>(userSaved);
        }
        catch (Exception ex)
        {
            throw new GeneralException("An error occurred while creating the user", 500);
        }
    }
}