namespace SkinetECommerce.Core.Utilities.ResultInfrastructure.Concrete.DataResult;

public class SuccessDataResult<T>: DataResult<T>
{
    public SuccessDataResult(T Data) : base(Data, true)
    {
    }

    public SuccessDataResult(T Data, string Message) : base(Data, true, Message)
    {
    }

    public SuccessDataResult(string Message): base(default, true, Message)
    {
    }

    public SuccessDataResult() : base(default, true)
    {
    }
}