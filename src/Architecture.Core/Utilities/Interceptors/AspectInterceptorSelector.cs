using System.Reflection;
using Castle.DynamicProxy;

namespace Architecture.Core.Utilities.Interceptors;

public class AspectInterceptorSelector : IInterceptorSelector
{
    public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
    {
        var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();

        var methodAttributes = type.GetMethods()?.Where(x => x.Name == method.Name).FirstOrDefault()!
            .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);


        if (methodAttributes is not null)
        {
            classAttributes.AddRange(methodAttributes);
        }
        return classAttributes.OrderBy(x => x.Priority).ToArray();
    }
}