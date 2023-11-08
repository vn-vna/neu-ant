using Neu.ANT.Common.Models.ApiResponse;

namespace Neu.ANT.Backend.Utilities
{
  public class ApiExecutor<T>
  {
    private readonly Func<Task<T>> _funcTarget;

    public ApiExecutor(Func<Task<T>> executor)
    {
      _funcTarget = executor;
    }

    public async Task<ApiResult<TResult>> Execute<TResult>(Func<T, TResult> mapping)
    {
      ApiResult<TResult> result = new();

      try
      {
        var ret = await _funcTarget();
        result.Success = true;
        result.Result = mapping(ret);
      }
      catch (Exception ex)
      {
        result.Success = false;
        result.Error = ex.Message;
      }

      return result;
    }
  }

  public static class ApiExecutorUtils
  {
    public static ApiExecutor<R> GetExecutor<R>(Func<Task<R>> fu)
        => new ApiExecutor<R>(fu);
  }
}
