namespace Judges.Models.Settings
{
    /// <summary>
    /// Настройки приложения.
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// Настройки сервера Kestrel.
        /// </summary>
        public KestrelSettings Kestrel { get; set; }

        /// <summary>
        /// Настройки подключения.
        /// </summary>
        public ConnectionSettings Connection { get; set; }
    }
}
