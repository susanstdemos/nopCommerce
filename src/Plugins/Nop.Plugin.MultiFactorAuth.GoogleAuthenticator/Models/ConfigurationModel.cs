using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.MultiFactorAuth.GoogleAuthenticator.Models
{
    /// <summary>
    /// Represents plugin configuration model
    /// </summary>
    public class ConfigurationModel : BaseNopModel 
    {
        [NopResourceDisplayName("Plugins.MultiFactorAuth.GoogleAuthenticator.QRPixelsPerModule")]
        public int QRPixelsPerModule { get; set; }
    }
}
