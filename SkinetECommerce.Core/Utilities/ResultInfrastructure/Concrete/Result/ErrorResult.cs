namespace SkinetECommerce.Core.Utilities.ResultInfrastructure.Concrete.Result;

public class ErrorResult: Result
{
    public ErrorResult() : base(false)
    {
    }

    public ErrorResult(string Message) : base(false, Message)
    {
    }
}