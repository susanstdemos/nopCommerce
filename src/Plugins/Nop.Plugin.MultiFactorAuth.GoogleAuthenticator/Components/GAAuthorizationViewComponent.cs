using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.MultiFactorAuth.GoogleAuthenticator.Components
{
    /// <summary>
    /// Represents view component for setting GoogleAuthenticator
    /// </summary>
    [ViewComponent(Name = GoogleAuthenticatorDefaults.VIEW_COMPONENT_NAME)]
    public class GAAuthorizationViewComponent : NopViewComponent
    {
        #region Fields

        #endregion

        #region Ctor

        public GAAuthorizationViewComponent()
        {

        }

        #endregion

        #region Methods

        /// <summary>
        ///  Invoke view component
        /// </summary>
        /// <param name="widgetZone">Widget zone name</param>
        /// <param name="additionalData">Additional data</param>
        /// <returns>View component result</returns>
        public IViewComponentResult Invoke(string widgetZone, object additionalData)
        {
            return View("~/Plugins/MultiFactorAuth.GoogleAuthenticator/Views/Customer/GAAuthorization.cshtml");
        }

        #endregion
    }
}
