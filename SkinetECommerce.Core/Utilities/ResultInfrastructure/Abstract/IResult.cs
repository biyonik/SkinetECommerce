namespace SkinetECommerce.Core.Utilities.ResultInfrastructure.Abstract;

public interface IResult
{
    bool IsSuccess { get; }
    string Message { get; }
}