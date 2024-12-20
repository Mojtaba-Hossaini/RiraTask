using Core.DTOs;
using MediatR;

namespace Application.Queries;

public class GetUserQuery : IRequest<UserDto>
{
    public int Id { get; set; }
}
