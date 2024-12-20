using Core.DTOs;
using MediatR;

namespace Application.Commands;

public class CreateUserCommand : IRequest<UserDto>
{
    public string Name { get; set; }
    public string Family { get; set; }
    public string NationalCode { get; set; }
    public DateTime Birthday { get; set; }
}