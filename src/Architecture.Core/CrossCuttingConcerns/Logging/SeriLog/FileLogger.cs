using Architecture.Core.Utilities.IoC;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Architecture.Core.CrossCuttingConcerns.Logging.SeriLog
{
    public class FileLogger : LoggerServiceBase
    {
        public FileLogger()
        {
            //var configuration = ServiceTool.ServiceProvider.GetService<IConfiguration>();

            //var logConfig = configuration.GetSection("SeriLogConfigurations:FileLogConfiguration")
            //                    .Get<FileLogConfiguration>() ??
            //                throw new Exception(SerilogMessages.NullOptionsMessage);

            var logFilePath = $"{Directory.GetCurrentDirectory() + "/logs/"}.txt";

            Logger = new LoggerConfiguration()
                .WriteTo.File(
                    logFilePath,
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: null,
                    fileSizeLimitBytes: 5000000,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message}{NewLine}{Exception}")
                .CreateLogger();
        }
    }
}
