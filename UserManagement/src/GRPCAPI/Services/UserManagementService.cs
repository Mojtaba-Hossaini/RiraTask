using Application.Commands;
using Application.Queries;
using AutoMapper;
using Grpc.Core;
using MediatR;
using UserManagementGRPC;

namespace UserManagement.Services
{
    public class UserManagementService : ManageUser.ManageUserBase
    {
        public UserManagementService(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public override async Task<User> CreateUser(CreateUserRequest request, ServerCallContext context)
        {
            var command = mapper.Map<CreateUserCommand>(request);
            var user = await mediator.Send(command, context.CancellationToken);
            return mapper.Map<User>(user);
        }

        public async override Task<User> GetUser(UserId request, ServerCallContext context)
        {
            var user = await mediator.Send(new GetUserQuery { Id = request.Id });
            return mapper.Map<User>(user);
        }

        public override async Task<User> UpdateUser(User request, ServerCallContext context)
        {
            var updatedUser = await mediator.Send(mapper.Map<UpdateUserCommand>(request));
            return mapper.Map<User>(updatedUser);
        }

        public override async Task<ConfirmResponse> DeleteUser(UserId request, ServerCallContext context)
        {
            var confirm = await mediator.Send(new DeleteUserCommand { Id = request.Id });
            return new ConfirmResponse { Done = confirm };
        }
    }

}
