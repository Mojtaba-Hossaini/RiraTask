namespace Core.Exceptions;

public class GeneralException : Exception
{
    public int StatusCode { get; }

    public GeneralException(string message, int statusCode) : base(message)
    {
        StatusCode = statusCode;
    }
}
