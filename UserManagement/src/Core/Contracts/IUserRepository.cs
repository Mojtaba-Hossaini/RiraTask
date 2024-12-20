using Core.DTOs;
using Core.Entities;

namespace Core.Contracts;

public interface IUserRepository
{
    Task<User> CreateUserAsync(User user, CancellationToken cancellationToken);
    Task<bool> DeleteUserAsync(int id);
    Task<User> GetUserByIdAsync(int id, CancellationToken cancellationToken);
    Task<User> UpdateUserAsync(UserDto request);
}