using Castle.DynamicProxy;

namespace Architecture.Core.Utilities.Interceptors;

[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
{
    public int Priority { get; set; }

    public virtual void Intercept(IInvocation invocation)
    {
    }
}