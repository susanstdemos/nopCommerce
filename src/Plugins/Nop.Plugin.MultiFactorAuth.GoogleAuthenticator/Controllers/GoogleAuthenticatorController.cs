using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.MultiFactorAuth.GoogleAuthenticator.Models;
using Nop.Services.Authentication.MultiFactor;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.MultiFactorAuth.GoogleAuthenticator.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class GoogleAuthenticatorController : BasePluginController
    {
        #region Fields

        private readonly GoogleAuthenticatorSettings _googleAuthenticatorSettings;
        private readonly ILocalizationService _localizationService;
        private readonly IMultiFactorAuthenticationPluginManager _multiFactorAuthenticationPluginManager;        
        private readonly INotificationService _notificationService;
        private readonly IPermissionService _permissionService;
        private readonly ISettingService _settingService;
        private readonly IStoreContext _storeContext;
        private readonly IWorkContext _workContext;

        #endregion

        #region Ctor 

        public GoogleAuthenticatorController(GoogleAuthenticatorSettings googleAuthenticatorSettings,
            ILocalizationService localizationService,
            IMultiFactorAuthenticationPluginManager multiFactorAuthenticationPluginManager,
            INotificationService notificationService,
            IPermissionService permissionService,
            ISettingService settingService,
            IStoreContext storeContext,
            IWorkContext workContext
            )
        {
            _googleAuthenticatorSettings = googleAuthenticatorSettings;
            _localizationService = localizationService;
            _multiFactorAuthenticationPluginManager = multiFactorAuthenticationPluginManager;
            _notificationService = notificationService;
            _permissionService = permissionService;
            _settingService = settingService;
            _storeContext = storeContext;
            _workContext = workContext;
        }

        #endregion

        #region Methods

        [AuthorizeAdmin]
        [Area(AreaNames.Admin)]
        public IActionResult Configure()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageMultifactorAuthenticationMethods))
                return AccessDeniedView();

            //prepare model
            var model = new ConfigurationModel
            {
                QRPixelsPerModule = _googleAuthenticatorSettings.QRPixelsPerModule
            };

            return View("~/Plugins/MultiFactorAuth.GoogleAuthenticator/Views/Configure.cshtml", model);
        }

        [HttpPost]        
        [AuthorizeAdmin]
        [Area(AreaNames.Admin)]
        public IActionResult Configure(ConfigurationModel model)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageMultifactorAuthenticationMethods))
                return AccessDeniedView();

            if (!ModelState.IsValid)
                return Configure();

            //load settings for a chosen store scope
            var storeScope = _storeContext.ActiveStoreScopeConfiguration;
            var settings = _settingService.LoadSetting<GoogleAuthenticatorSettings>(storeScope);

            //set new settings values
            settings.QRPixelsPerModule = model.QRPixelsPerModule;

            //save settings
            _settingService.SaveSettingOverridablePerStore(settings, setting => setting.QRPixelsPerModule, true, storeScope, false);
            _settingService.ClearCache();

            _notificationService.SuccessNotification(_localizationService.GetResource("Admin.Plugins.Saved"));

            return Configure();
        }

        #endregion
    }
}
