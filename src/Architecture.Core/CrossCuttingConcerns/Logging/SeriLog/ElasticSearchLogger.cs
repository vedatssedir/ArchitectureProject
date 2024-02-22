using Architecture.Core.CrossCuttingConcerns.Logging.ConfigurationModels;
using Architecture.Core.Utilities.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Formatting.Elasticsearch;
using Serilog.Sinks.Http.BatchFormatters;

namespace Architecture.Core.CrossCuttingConcerns.Logging.SeriLog;

public class ElasticSearchLogger : LoggerServiceBase
{
    public ElasticSearchLogger()
    {
        var seriLogConfig = new LoggerConfiguration()
            .WriteTo.DurableHttpUsingFileSizeRolledBuffers(
                requestUri: "http://localhost:9200",
                batchFormatter: new ArrayBatchFormatter(),
                textFormatter: new ElasticsearchJsonFormatter())
            .CreateLogger();
        Logger = seriLogConfig;
    }
}