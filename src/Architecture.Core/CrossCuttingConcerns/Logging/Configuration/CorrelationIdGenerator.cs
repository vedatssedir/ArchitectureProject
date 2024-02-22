namespace Architecture.Core.CrossCuttingConcerns.Logging.Configuration;

public sealed class CorrelationIdGenerator
{
    private static readonly Lazy<CorrelationIdGenerator> Instance = new(() => new CorrelationIdGenerator());
    private Guid CorrelationId { get; }
    private CorrelationIdGenerator()
    {
        CorrelationId = Guid.NewGuid();
    }
    public static CorrelationIdGenerator CorrelationIdGeneratorInstance => Instance.Value;
    public Guid GetCorrelationId() => CorrelationId;
}