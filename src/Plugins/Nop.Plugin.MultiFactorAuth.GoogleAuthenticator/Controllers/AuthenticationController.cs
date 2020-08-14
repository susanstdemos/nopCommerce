using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Customers;
using Nop.Plugin.MultiFactorAuth.GoogleAuthenticator.Models;
using Nop.Plugin.MultiFactorAuth.GoogleAuthenticator.Services;
using Nop.Services.Customers;
using Nop.Web.Controllers;
using Nop.Web.Framework.Controllers;

namespace Nop.Plugin.MultiFactorAuth.GoogleAuthenticator.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class AuthenticationController : BasePluginController
    {
        #region Fields

        private readonly CustomerController _customerController;
        private readonly CustomerSettings _customerSettings;
        private readonly GoogleAuthenticatorService _googleAuthenticatorService;
        private readonly ICustomerService _customerService;
        private readonly IWorkContext _workContext;

        #endregion

        #region Ctor
        public AuthenticationController(CustomerController customerController,
            CustomerSettings customerSettings,
            GoogleAuthenticatorService googleAuthenticatorService,
            ICustomerService customerService,
            IWorkContext workContext)
        {
            _customerController = customerController;
            _customerSettings = customerSettings;
            _googleAuthenticatorService = googleAuthenticatorService;
            _customerService = customerService;
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

        [HttpPost]
        //public IActionResult VerifyGoogleAuthenticator(string verifyToken)
        public IActionResult VerifyGoogleAuthenticator(TokenModel model)
        {
            var username = HttpContext.Session.GetString("RequiresMultiFactor");

            var customer = _customerSettings.UsernamesEnabled ? _customerService.GetCustomerByUsername(username) : _customerService.GetCustomerByEmail(username);
            if (customer == null)
                return RedirectToRoute("Login");

            var record = _googleAuthenticatorService.GetConfigurationByCustomerEmail(customer.Email);
            if (record != null)
            {
                var isValidToken = _googleAuthenticatorService.ValidateTwoFactorToken(record.SecretKey, model.Token);
                //isValidToken = true; //TODO удалить после тестов
                if (isValidToken)
                {                    
                    //return RedirectToRoute("MultiFactorAuthorization");
                    //return Json(new { Result = true, Customer = customer.Email }); 
                    return _customerController.MultiFactorAuthorization(customer.Email);
                }
            }

            //return Json(new { Result = false });
            return RedirectToRoute("MultiFactorAuthorization");
        }

        #endregion

    }
}
