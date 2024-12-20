using System.Net;

namespace Core.Exceptions;

public class UserNotFoundException : GeneralException
{
    public UserNotFoundException(int id) : base($"user with id {id} not found", (int)HttpStatusCode.NotFound)
    {
    }
}
