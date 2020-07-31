namespace Nop.Plugin.MultiFactorAuth.GoogleAuthenticator
{
    /// <summary>
    /// Represents plugin constants
    /// </summary>
    public class GoogleAuthenticatorDefaults
    {
        /// <summary>
        /// Gets a name of the view component to display login button
        /// </summary>
        public const string VIEW_COMPONENT_NAME = "GoogleAuthenticator";

        /// <summary>
        /// Gets a plugin system name
        /// </summary>
        public static string SystemName = "MultiFactorAuth.GoogleAuthenticator";

        /// <summary>
        /// Gets the configuration route name
        /// </summary>
        public static string ConfigurationRouteName => "Plugin.MultiFactorAuth.GoogleAuthenticator.Configure";

        /// <summary>
        /// Gets a default QRPixelsPerModule
        /// </summary>
        public static int DefaultQRPixelsPerModule => 3;

        /// <summary>
        /// Gets the prefix key to clear cache
        /// </summary>
        public static string PrefixCacheKey => "Nop.Plugin.MultiFactorAuth.GoogleAuthenticator";
    }
}
