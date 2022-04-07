using NLog;
namespace ArithmaticOperationTest
{
    public class Logger
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public static void Log(string message, LogType type)
        {
            switch (type)
            {
                case LogType.Info:
                    logger.Info(message);
                    break;
                case LogType.Error:
                    logger.Error(message);
                    break;
                case LogType.Warning:
                    logger.Warn(message);
                    break;
                default:
                    break;
            }
        }
    }

    public enum LogType
    {
        Info,
        Error,
        Warning
    }
}
