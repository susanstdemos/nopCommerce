using System;
using Google.Authenticator;
using Nop.Core;
using Nop.Plugin.MultiFactorAuth.GoogleAuthenticator.Models;

namespace Nop.Plugin.MultiFactorAuth.GoogleAuthenticator.Factories
{
    public class AuthorizationModelFactory
    {
        #region Fields

        private readonly IWorkContext _workContext;
        private TwoFactorAuthenticator _twoFactorAuthenticator;

        #endregion

        #region Ctor

        public AuthorizationModelFactory(
            IWorkContext workContext)
        {
            _workContext = workContext;            
        }

        #endregion

        #region Properties

        private TwoFactorAuthenticator TwoFactorAuthenticator
        {
            get
            {
                _twoFactorAuthenticator = new TwoFactorAuthenticator();
                return _twoFactorAuthenticator;
            }
        }

        #endregion

        #region Methods

        public AuthModel PrepareAuthModel(AuthModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            var secretkey = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10);
            var setupInfo = TwoFactorAuthenticator.GenerateSetupCode("nopCommerce", _workContext.CurrentCustomer.Email, secretkey, false, 3);

            model.SecretKey = secretkey;
            model.Account = $"nopCommerce ({_workContext.CurrentCustomer.Email})";
            model.ManualEntryQrCode = setupInfo.ManualEntryKey;
            model.QrCodeImageUrl = setupInfo.QrCodeSetupImageUrl;

            return model;
        }

        #endregion
    }
}
