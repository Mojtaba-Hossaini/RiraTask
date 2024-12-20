using Application.Commands;
using AutoMapper;
using Core.Contracts;
using MediatR;

namespace Application.Handlers;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
{
    private readonly IUserRepository userRepository;
    private readonly IMapper mapper;

    public DeleteUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        this.userRepository = userRepository;
        this.mapper = mapper;
    }
    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        return await userRepository.DeleteUserAsync(request.Id);
    }
}
