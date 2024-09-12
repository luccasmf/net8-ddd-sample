using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace net8_ddd_sample.application.Configuration
{
    internal static class LocalizationConfiguration
    {
        #region Variables
        public const string MainCulture = "pt-BR";
        #endregion

        #region Methods
        public static void ConfigureLocalization(this IApplicationBuilder app)
        {
            var supportedCultures = new[] { new CultureInfo("pt-BR"), new CultureInfo("en-US") };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                ApplyCurrentCultureToResponseHeaders = true,
                SupportedUICultures = supportedCultures,
                DefaultRequestCulture = new RequestCulture(MainCulture),
                SupportedCultures = supportedCultures,
                FallBackToParentCultures = false
            });

            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CreateSpecificCulture(MainCulture);
        }
        #endregion
    }
}
