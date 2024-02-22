using Castle.DynamicProxy;

namespace Architecture.Core.Utilities.Interceptors;

public abstract class MethodInterception : MethodInterceptionBaseAttribute
{
    protected virtual void OnBefore(IInvocation invocation)
    {
    }

    protected virtual void OnAfter(IInvocation invocation)
    {
    }

    protected virtual void OnException(IInvocation invocation, Exception exceptionMessage)
    {
    }

    protected virtual void OnSuccess(IInvocation invocation)
    {
    }


    public override void Intercept(IInvocation invocation)
    {
        var isSuccess = true;
        OnBefore(invocation);
        try
        {
            invocation.Proceed();
            var result = invocation.ReturnValue as Task;
            result?.Wait();
        }
        catch (Exception ex)
        {
            isSuccess = false;
            OnException(invocation, ex);
            throw;
        }
        finally
        {
            if (isSuccess)
            {
                OnSuccess(invocation);
            }
        }

        OnAfter(invocation);

    }
}