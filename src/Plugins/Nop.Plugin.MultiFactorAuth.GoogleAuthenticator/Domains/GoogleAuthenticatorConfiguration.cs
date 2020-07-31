using Nop.Core;

namespace Nop.Plugin.MultiFactorAuth.GoogleAuthenticator.Domains
{
    /// <summary>
    /// Represents a  Google Authenticator configuration
    /// </summary>
    public partial class GoogleAuthenticatorConfiguration : BaseEntity
    {
        /// <summary>
        /// Gets or sets a customer identifier
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets a SecretKey identifier
        /// </summary>
        public string SecretKey { get; set; }
    }
}
