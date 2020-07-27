using Nop.Services.Plugins;

namespace Nop.Services.Authentication.MultiFactor
{
    /// <summary>
    /// Represents method for the multifactor authentication
    /// </summary>
    public partial interface IMultiFactorAuthenticationMethod : IPlugin
    {
        /// <summary>
        ///  Gets a multifactor authentication type
        /// </summary>
        MultiFactorAuthenticationType MultiFactorAuthenticationType { get; }
    }
}
