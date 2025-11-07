using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using log4net.Repository;

namespace BusinessLayer.Config
{
    public static class LoggingConfig
    {
        public static ILog Configure(string browser, string testClass)
        {
            string logDir = Path.Combine(Directory.GetCurrentDirectory(), "logs");
            Directory.CreateDirectory(logDir);

            string fileName = $"{testClass}_{browser}.log";
            string filePath = Path.Combine(logDir, fileName);

            string repoName = $"{testClass}_{browser}_{Guid.NewGuid()}";
            ILoggerRepository repo = LogManager.CreateRepository(repoName);

            var layout = new PatternLayout("%date [%thread] %-5level %logger - %message%newline");
            layout.ActivateOptions();

            var fileAppender = new FileAppender
            {
                File = filePath,
                AppendToFile = true,
                Layout = layout,
                Threshold = Level.Debug,
                LockingModel = new FileAppender.MinimalLock()
            };
            fileAppender.ActivateOptions();

            BasicConfigurator.Configure(repo, fileAppender);

            var logger = LogManager.GetLogger(repo.Name, $"{testClass}_{browser}");
            logger.Info("Test started");

            return logger;
        }
    }
}
