using Nop.Web.Framework.Models;

namespace Nop.Plugin.MultiFactorAuth.GoogleAuthenticator.Models
{
    public class AuthModel : BaseNopModel
    {
        public string SecretKey { get; set; }

        public string Code { get; set; }

        public string QrCodeImageUrl { get; set; }

        public string ManualEntryQrCode { get; set; }

        public string Account { get; set; }
    }
}
