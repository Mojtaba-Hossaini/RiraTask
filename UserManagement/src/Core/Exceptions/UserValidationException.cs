namespace Core.Exceptions;

public class UserValidationException : GeneralException
{
    public List<string> Errors { get; }

    public UserValidationException(List<string> errors)
        : base("Validation failed", 400)
    {
        Errors = errors ?? new List<string>();
    }
}
