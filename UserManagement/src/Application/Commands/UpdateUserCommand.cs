using Core.DTOs;
using MediatR;

namespace Application.Commands;

public class UpdateUserCommand : IRequest<UserDto>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Family { get; set; }
    public string NationalCode { get; set; }
    public DateTime Birthday { get; set; }
}
