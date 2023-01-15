using SkinetECommerce.Core.Utilities.ResultInfrastructure.Abstract;

namespace SkinetECommerce.Core.Utilities.ResultInfrastructure.Concrete.Result;

public class SuccessResult: Result
{
    public SuccessResult() : base(true)
    {
    }

    public SuccessResult(string Message) : base(true, Message)
    {
    }
}