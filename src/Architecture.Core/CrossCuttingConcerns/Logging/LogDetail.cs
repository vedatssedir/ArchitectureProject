namespace Architecture.Core.CrossCuttingConcerns.Logging;

public class LogDetail
{
    public string? FullName { get; set; }
    public string? MethodName { get; set; }
    public string? User { get; set; }
    public List<LogParameter> LogParameter { get; set; }
    public string CorrelationId { get; set; }
    public string Direction { get; set; }
}   