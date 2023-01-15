using SkinetECommerce.Core.Utilities.ResultInfrastructure.Abstract;

namespace SkinetECommerce.Core.Utilities.ResultInfrastructure.Concrete.Result;

public class Result: IResult
{
    public bool IsSuccess { get; }
    public string Message { get; }

    public Result(bool IsSuccess)
    {
        this.IsSuccess = IsSuccess;
    }

    public Result(bool IsSuccess, string Message) : this(IsSuccess)
    {
        this.Message = Message;
    }
}