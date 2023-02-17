namespace TBot.Core.Exceptions;

public class BaseException : Exception
{
    public virtual ExceptionType ExceptionType { get; } = ExceptionType.InternalError;
    public override string Message { get; }

    public BaseException(string message)
    {
        Message = message;
    }
}