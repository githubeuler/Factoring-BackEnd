using Microsoft.Extensions.Configuration;
using NLog;
using NLog.Config;


namespace Factoring.Domain.Util
{
    public static class LogUtil
    {
        private static readonly Logger _logger;
        private const string DefaultLogger = "TaskLogger";
        private const string DefaultEnvironment = "PRD";

        static LogUtil()
        {
            // Crear configuración desde appsettings.json o variables de entorno
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Ruta base del proyecto
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true) // Archivo de configuración
                .AddEnvironmentVariables() // Variables de entorno
                .Build();

            // Obtener el entorno desde la configuración o usar el valor predeterminado
            var environment = configuration["Log:Environment"] ?? DefaultEnvironment;

            // Obtener la ruta al archivo de configuración de NLog
            var path = Path.Combine(Directory.GetCurrentDirectory(), "ConfigLog", $"NLog.{environment}.config");

            // Verificar si el archivo de configuración existe
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"No se encontró el archivo de configuración NLog en la ruta: {path}");
            }

            // Configurar NLog con la configuración encontrada
            LogManager.Configuration = new XmlLoggingConfiguration(path);

            // Crear el logger
            _logger = LogManager.GetLogger(DefaultLogger);
        }

        public static Logger GetLogger()
        {
            return _logger;
        }


        /// <summary>
        /// Metodo escribe un mensaje el archivo LOG tipo DEBUG
        /// </summary>
        /// <param name="message">Mensaje</param>       
        public static void Debug(string message)
        {
            if (!_logger.IsDebugEnabled) return;
            _logger.Debug(message);
        }

        /// <summary>
        /// Metodo escribe un mensaje el archivo LOG tipo INFORMATIVO
        /// </summary>
        /// <param name="message">Mensaje</param>
        public static void Info(string message)
        {
            if (!_logger.IsInfoEnabled) return;
            _logger.Info(message);
        }

        /// <summary>
        /// Metodo escribe un mensaje el archivo LOG tipo ADVERTENCIA
        /// </summary>
        /// <param name="message">Mensaje</param>
        public static void Warn(string message)
        {
            if (!_logger.IsWarnEnabled) return;
            _logger.Warn(message);
        }

        /// <summary>
        /// Metodo escribe un mensaje el archivo LOG tipo ERROR, con la descripcion de error adicional
        /// </summary>
        /// <param name="error">Mensaje de error</param>
        /// <param name="exception">Exception</param>
        public static void Error(string error, Exception exception = null)
        {
            if (!_logger.IsErrorEnabled) return;
            _logger.Error(error, exception);
        }

        /// <summary>
        /// Metodo escribe un mensaje el archivo LOG tipo FATAL
        /// </summary>
        /// <param name="message">Mensaje</param>
        public static void Fatal(string message)
        {
            if (!_logger.IsFatalEnabled) return;
            _logger.Warn(message);
        }

        /// <summary>
        /// Metodo escribe un mensaje el archivo LOG tipo SEGUIMIENTO
        /// </summary>
        /// <param name="message">Mensaje</param>
        public static void Trace(string message)
        {
            if (!_logger.IsTraceEnabled) return;
            _logger.Trace(message);
        }

        public static void Trace(string message, params object[] args)
        {
            if (!_logger.IsTraceEnabled) return;
            _logger.Trace(message, args);
        }

        public static void Write(string message)
        {
            _logger.Debug(message);
        }
    }
}
