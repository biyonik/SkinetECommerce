namespace SkinetECommerce.Core.Utilities.ResultInfrastructure.Concrete.DataResult;

public class ErrorDataResult<T>: DataResult<T>
{
    public ErrorDataResult(T Data) : base(Data, false)
    {
    }

    public ErrorDataResult(T Data, string Message) : base(Data, false, Message)
    {
    }

    public ErrorDataResult(string Message): base(default, false, Message)
    {
    }

    public ErrorDataResult() : base(default, false)
    {
    }
}