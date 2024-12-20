using Core.Contracts;
using Core.DTOs;
using Core.Entities;
using Core.Exceptions;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DatabaseContext _context;
    private readonly ILogger<UserRepository> logger;

    public UserRepository(DatabaseContext context, ILogger<UserRepository> logger)
    {
        _context = context;
        this.logger = logger;
    }

    public async Task<User> CreateUserAsync(User user, CancellationToken cancellationToken)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync(cancellationToken);
        return user;
    }

    public async Task<User> UpdateUserAsync(UserDto request)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (user == null) throw new UserNotFoundException(request.Id);
        user.NationalCode = request.NationalCode;
        user.Birthday = request.Birthday;
        user.Family = request.Family;
        user.Name = request.Name;
        var updatedUser = _context.Update(user);

        if (await _context.SaveChangesAsync() > 0)
            return user;
        throw new GeneralException("use not updated!", (int)HttpStatusCode.InternalServerError);
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        var user = _context.Users.FirstOrDefault(x => x.Id == id);
        if (user == null) throw new UserNotFoundException(id);
        _context.Users.Remove(user);
        return await _context.SaveChangesAsync() > 0;
    }
    public async Task<User> GetUserByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Users.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }
}
