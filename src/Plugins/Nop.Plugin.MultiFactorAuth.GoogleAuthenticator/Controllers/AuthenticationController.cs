using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.MultiFactorAuth.GoogleAuthenticator.Models;
using Nop.Plugin.MultiFactorAuth.GoogleAuthenticator.Services;
using Nop.Web.Framework.Controllers;

namespace Nop.Plugin.MultiFactorAuth.GoogleAuthenticator.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class AuthenticationController : BasePluginController
    {
        #region Fields

        private readonly GoogleAuthenticatorService _googleAuthenticatorService;

        #endregion

        #region Ctor
        public AuthenticationController(GoogleAuthenticatorService googleAuthenticatorService)
        {
            _googleAuthenticatorService = googleAuthenticatorService;
        }

        #endregion

        #region Methods

        [HttpPost]
        //public IActionResult RegisterGoogleAuthenticator(string verifyToken, string code)
        public IActionResult RegisterGoogleAuthenticator(AuthModel model)
        {

            return RedirectToRoute("MultiFactorAuthenticationSettings");
        }

        #endregion

    }
}
