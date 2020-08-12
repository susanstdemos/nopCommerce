using Microsoft.AspNetCore.Mvc;
using Nop.Core;
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
        private readonly IWorkContext _workContext;

        #endregion

        #region Ctor
        public AuthenticationController(GoogleAuthenticatorService googleAuthenticatorService,
            IWorkContext workContext)
        {
            _googleAuthenticatorService = googleAuthenticatorService;
            _workContext = workContext;
        }

        #endregion

        #region Methods

        [HttpPost]
        //public IActionResult RegisterGoogleAuthenticator(string verifyToken, string code)
        public IActionResult RegisterGoogleAuthenticator(AuthModel model)
        {
            var currentCustomer = _workContext.CurrentCustomer;

            var isValidToken = _googleAuthenticatorService.ValidateTwoFactorToken(model.SecretKey, model.Code);
            if (isValidToken)
            {
                //try to find config with current customer and update
                if (_googleAuthenticatorService.IsRegisteredCustomer(currentCustomer.Email))
                {
                    _googleAuthenticatorService.UpdateGoogleAuthenticatorAccount(currentCustomer.Email, model.SecretKey);
                }
                else
                {
                    _googleAuthenticatorService.AddGoogleAuthenticatorAccount(currentCustomer.Email, model.SecretKey);
                }
            }
            
            return RedirectToRoute("MultiFactorAuthenticationSettings");
        }

        #endregion

    }
}
