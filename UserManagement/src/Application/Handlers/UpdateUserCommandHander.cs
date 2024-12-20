using Application.Commands;
using AutoMapper;
using Core.Contracts;
using Core.DTOs;
using MediatR;

namespace Application.Handlers;

public class UpdateUserCommandHander : IRequestHandler<UpdateUserCommand, UserDto>
{
    private readonly IUserRepository userRepository;
    private readonly IMapper mapper;

    public UpdateUserCommandHander(IUserRepository userRepository, IMapper mapper)
    {
        this.userRepository = userRepository;
        this.mapper = mapper;
    }
    public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var updatedUser = await userRepository.UpdateUserAsync(mapper.Map<UserDto>(request));
        return mapper.Map<UserDto>(updatedUser);
    }
}
