using System.Collections.Generic;
using FluentMigrator;
using Nop.Core.Infrastructure;
using Nop.Data;
using Nop.Data.Migrations;
using Nop.Services.Localization;

namespace Nop.Web.Framework.Migrations.UpgradeTo440
{
    [NopMigration("2020-06-10 00:00:00", "4.40.0", UpdateMigrationType.Localization)]
    [SkipMigrationOnInstall]
    public class LocalizationMigration : MigrationBase
    { 
        /// <summary>Collect the UP migration expressions</summary>
        public override void Up()
        {
            if(!DataSettingsManager.DatabaseIsInstalled)
                return;

            //do not use DI, because it produces exception on the installation process
            var localizationService = EngineContext.Current.Resolve<ILocalizationService>();

            //use localizationService to add, update and delete localization resources
            localizationService.DeleteLocaleResources(new List<string>
            {
                "Account.Fields.VatNumber.Status",
                "Account.Fields.VatNumberStatus",
                "Account.PasswordRecovery.OldPassword",
                "Account.PasswordRecovery.OldPassword.Required",
                "Account.Register.Unsuccessful",
                "Account.ShoppingCart",
                "ActivityLog.AddNewWidget",
                "ActivityLog.DeleteWidget",
                "ActivityLog.EditWidget",
                "Admin.Address.Fields.StateProvince.Required",
                "Admin.Catalog.AdditionalProductReviews.Fields.Description",
                "Admin.Catalog.Categories.Breadcrumb",
                "Admin.Catalog.Categories.Fields.CreatedOn",
                "Admin.Catalog.Categories.SwitchToListView",
                "Admin.Catalog.Manufacturers.Fields.CreatedOn",
                "Admin.Catalog.Products.ProductAttributes.Attributes.ValidationRules.ViewLink",
                "Admin.Catalog.Products.ProductAttributes.Attributes.Values.EditAttributeDetails",
                "Admin.Catalog.Products.SpecificationAttributes.NoAttributeOptions",
                "Admin.Catalog.Products.SpecificationAttributes.SelectOption",
                "Admin.Common.CancelChanges",
                "Admin.Common.Check",
                "Admin.Common.DeleteConfirmationParam",
                "Admin.Common.List",
                "Admin.Common.LoseUnsavedChanges",
                "Admin.Common.SaveChanges",
                "Admin.Configuration.Currencies.Localization",
                "Admin.Configuration.Currencies.Select",
                "Admin.Configuration.EmailAccounts.Fields.SendTestEmailTo.Button",
                "Admin.Configuration.PaymentMethods",
                "Admin.Configuration.PaymentMethodsAndRestrictions",
                "Admin.Configuration.Settings.CustomerUser.BlockTitle.DefaultFields",
                "Admin.Configuration.Settings.CustomerUser.BlockTitle.ExternalAuthentication",
                "Admin.Configuration.Settings.CustomerUser.BlockTitle.TimeZone",
                "Admin.Configuration.Settings.CustomerUser.CustomerSettings",
                "Admin.Configuration.Settings.Order.OrderSettings",
                "Admin.Configuration.Settings.ProductEditor.BlockTitle.LinkedProducts",
                "Admin.Configuration.Settings.ProductEditor.Id",
                "Admin.Configuration.Shipping.Measures.Dimensions.Description",
                "Admin.Configuration.Shipping.Measures.Weights.Description",
                "Admin.Configuration.SMSProviders",
                "Admin.Configuration.SMSProviders.BackToList",
                "Admin.Configuration.SMSProviders.Configure",
                "Admin.Configuration.SMSProviders.Fields.FriendlyName",
                "Admin.Configuration.SMSProviders.Fields.IsActive",
                "Admin.Configuration.SMSProviders.Fields.SystemName",
                "Admin.ContentManagement.Topics.Fields.Store.AllStores",
                "Admin.ContentManagement.Widgets.ChooseZone",
                "Admin.ContentManagement.Widgets.ChooseZone.Hint",
                "Admin.Customers.Customers.Fields.Email.Required",
                "Admin.Customers.Customers.Fields.FirstName.Required",
                "Admin.Customers.Customers.Fields.LastName.Required",
                "Admin.Customers.Customers.Fields.SystemName",
                "Admin.Customers.Customers.Fields.SystemName.Hint",
                "Admin.Customers.Customers.Fields.Username.Required",
                "Admin.Customers.Customers.RewardPoints.Alert.HistoryAdd",
                "Admin.DT.Processing",
                "Admin.NopCommerceNews.HideAdv",
                "Admin.NopCommerceNews.ShowAdv",
                "Admin.Orders.OrderNotes.Alert.Add",
                "Admin.Promotions.Discounts.Fields.AppliedToCategories",
                "Admin.Promotions.Discounts.Fields.AppliedToCategories.Hint",
                "Admin.Promotions.Discounts.Fields.AppliedToCategories.NoRecords",
                "Admin.System.QueuedEmails.Fields.Priority.Required",
                "Common.DeleteConfirmationParam",
                "Common.Extensions.RelativeFormat",
                "Common.Home",
                "EUCookieLaw.CannotBrowse",
                "EUCookieLaw.Title",
                "Filtering.FilterResults",
                "Forum.Replies.Count",
                "Forum.Topics.Count",
                "News.Archive",
                "Newsletter.ResultAlreadyDeactivated",
                "PageTitle.EmailRevalidation",
                "PDFInvoice.CreatedOn",
                "PDFInvoice.Note",
                "PrivateMessages.Send.Subject.Required",
                "PrivateMessages.Sent.DateColumn",
                "PrivateMessages.Sent.DeleteSelected",
                "PrivateMessages.Sent.SubjectColumn",
                "PrivateMessages.Sent.ToColumn",
                "Profile.FullName",
                "RewardPoints.Message.Expired",
                "ShoppingCart.AddToWishlist.Update",
                "ShoppingCart.UpdateCartItem",
                "Tax.SelectType",

                //<MFA #475>
                "Admin.Configuration.ExternalAuthenticationMethods",
                "Admin.Configuration.ExternalAuthenticationMethods.BackToList",
                "Admin.Configuration.ExternalAuthenticationMethods.Configure",
                "Admin.Configuration.ExternalAuthenticationMethods.Fields.DisplayOrder",
                "Admin.Configuration.ExternalAuthenticationMethods.Fields.FriendlyName",
                "Admin.Configuration.ExternalAuthenticationMethods.Fields.IsActive",
                "Admin.Configuration.ExternalAuthenticationMethods.Fields.SystemName",
                "Permission.ManageExternalAuthenticationMethods"
                //</MFA #475>

            });

            localizationService.AddLocaleResource(new Dictionary<string, string>
            {
                ["Admin.System.Warnings.PluginNotEnabled.AutoFixAndRestart"] = "Uninstall and delete all not used plugins automatically (site will be restarted)",
                //<MFA #475>
                ["Admin.Configuration.Authentication"] = "Authentication",
                ["Admin.Configuration.Authentication.ExternalMethods"] = "External authentication",
                ["Admin.Configuration.Authentication.ExternalMethods.BackToList"] = "back to external authentication method list",
                ["Admin.Configuration.Authentication.ExternalMethods.Configure"] = "Configure",
                ["Admin.Configuration.Authentication.ExternalMethods.Fields.DisplayOrder"] = "Display order",
                ["Admin.Configuration.Authentication.ExternalMethods.Fields.FriendlyName"] = "Friendly name",
                ["Admin.Configuration.Authentication.ExternalMethods.Fields.IsActive"] = "Is active",
                ["Admin.Configuration.Authentication.ExternalMethods.Fields.SystemName"] = "System name",
                ["Admin.Configuration.Authentication.MultiFactorMethods"] = "Multifactor authentication",
                ["Admin.Configuration.Authentication.MultiFactorMethods.BackToList"] = "back to multifactor authentication method list",
                ["Admin.Configuration.Authentication.MultiFactorMethods.Configure"] = "Configure",
                ["Admin.Configuration.Authentication.MultiFactorMethods.Fields.DisplayOrder"] = "Display order",
                ["Admin.Configuration.Authentication.MultiFactorMethods.Fields.FriendlyName"] = "Friendly name",
                ["Admin.Configuration.Authentication.MultiFactorMethods.Fields.IsActive"] = "Is active",
                ["Admin.Configuration.Authentication.MultiFactorMethods.Fields.SystemName"] = "System name",

                ["Permission.Authentication.ManageExternalMethods"] = "Admin area. Manage External Authentication Methods",
                ["Permission.Authentication.ManageMultifactorMethods"] = "Admin area. Manage Multifactor Authentication Methods",

                ["Admin.Configuration.Settings.CustomerUser.EnableMultifactorAuth"] = "Enable multifactor authentication",
                ["Admin.Configuration.Settings.CustomerUser.EnableMultifactorAuth.Hint"] = "When enabled, users attempting to access the public store must complete a second step to verify their account.",
                
                ["PageTitle.MultiFactorAuthentication"] = "Multifactor authentication",
                ["PageTitle.MultiFactorAuthorization"] = "Multifactor authorization",
                ["Account.MultiFactorAuthentication.Fields.IsEnabled"] = "Is enabled",
                ["Account.MultiFactorAuthentication.Settings"] = "Settings",
                ["Account.MultiFactorAuthentication.Providers"] = "Authentication providers",
                ["Account.MultiFactorAuthentication.Providers.NoActive"] = "No active providers"
                //</MFA #475>

            });
        }

        /// <summary>Collects the DOWN migration expressions</summary>
        public override void Down()
        {
            //add the downgrade logic if necessary 
        }
    }
}
