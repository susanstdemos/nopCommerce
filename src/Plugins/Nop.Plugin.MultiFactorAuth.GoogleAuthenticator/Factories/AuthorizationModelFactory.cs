using System;
using Nop.Core;
using Nop.Plugin.MultiFactorAuth.GoogleAuthenticator.Models;
using Nop.Plugin.MultiFactorAuth.GoogleAuthenticator.Services;

namespace Nop.Plugin.MultiFactorAuth.GoogleAuthenticator.Factories
{
    public class AuthorizationModelFactory
    {
        #region Fields

        private readonly IWorkContext _workContext;
        private readonly GoogleAuthenticatorService _googleAuthenticatorService;

        #endregion

        #region Ctor

        public AuthorizationModelFactory(GoogleAuthenticatorService googleAuthenticatorService,
            IWorkContext workContext)
        {
            _googleAuthenticatorService = googleAuthenticatorService;
            _workContext = workContext;
        }

        #endregion
        
        #region Methods

        public AuthModel PrepareAuthModel(AuthModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            var secretkey = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10);
            var setupInfo = _googleAuthenticatorService.GenerateSetupCode(secretkey);

            model.SecretKey = secretkey;
            model.Account = $"nopCommerce ({_workContext.CurrentCustomer.Email})";
            model.ManualEntryQrCode = setupInfo.ManualEntryKey;
            model.QrCodeImageUrl = setupInfo.QrCodeSetupImageUrl;

            return model;
        }

        #endregion
    }
}
