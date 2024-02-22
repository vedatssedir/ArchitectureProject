using Architecture.Core.CrossCuttingConcerns.Logging;
using Architecture.Core.CrossCuttingConcerns.Logging.Configuration;
using Architecture.Core.Utilities.Interceptors;
using Castle.DynamicProxy;
using Newtonsoft.Json;

namespace Architecture.Core.Aspects;

public class LogAspect : MethodInterception
{
    private readonly LoggerServiceBase? _loggerServiceBase;
    private Guid CorrelationId { get; }

    public LogAspect(Type loggerService)
    {
        if (loggerService.BaseType != typeof(LoggerServiceBase))
        {
            throw new ArgumentException("");
        }
        _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService)!;
        CorrelationId = CorrelationIdGenerator.CorrelationIdGeneratorInstance.GetCorrelationId();
    }
    protected override void OnBefore(IInvocation invocation)
    {
        _loggerServiceBase?.Info(GetLogDetail(invocation, "Request"));
    }

    protected override void OnSuccess(IInvocation invocation)
    {
        _loggerServiceBase?.Info(GetLogDetail(invocation, "Response"));
    }

    private string GetLogDetail(IInvocation invocation, string direction)
    {
        var logParameters = invocation.Arguments.Select((t, i) => new LogParameter()
        {
            Name = invocation.GetConcreteMethod().GetParameters()[i].Name ?? string.Empty,
            Value = t,
            Type = t.GetType().Name
        }).ToList();

        var logDetail = new LogDetail
        {
            MethodName = invocation.Method.Name,
            LogParameter = logParameters,
            CorrelationId = CorrelationId.ToString(),
            Direction = direction
        };
        return JsonConvert.SerializeObject(logDetail);
    }
}