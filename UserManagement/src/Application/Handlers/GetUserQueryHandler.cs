using Application.Queries;
using AutoMapper;
using Core.Contracts;
using Core.DTOs;
using MediatR;

namespace Application.Handlers;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
{
    private readonly IUserRepository userRepository;
    private readonly IMapper mapper;

    public GetUserQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        this.userRepository = userRepository;
        this.mapper = mapper;
    }
    public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetUserByIdAsync(request.Id, cancellationToken);
        return mapper.Map<UserDto>(user);
    }
}
