namespace TBot.Core.Exceptions;

public class DiscrepancyException : BaseException
{
    public override ExceptionType ExceptionType => ExceptionType.Discrepancy;

    public DiscrepancyException(string message) : base(message)
    {
    }
}