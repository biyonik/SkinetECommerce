using SkinetECommerce.Core.Utilities.ResultInfrastructure.Abstract;

namespace SkinetECommerce.Core.Utilities.ResultInfrastructure.Concrete.DataResult;

public class DataResult<T>: Result.Result, IDataResult<T>
{
    public DataResult(T Data, bool IsSuccess) : base(IsSuccess)
    {
        this.Data = Data;
    }

    public DataResult(T Data, bool IsSuccess, string Message) : base(IsSuccess, Message)
    {
        this.Data = Data;
    }

    public T Data { get; }
}