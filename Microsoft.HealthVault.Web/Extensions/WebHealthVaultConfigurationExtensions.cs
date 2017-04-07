﻿using System;
using Microsoft.HealthVault.Web.Configuration;
using static Microsoft.HealthVault.Web.Constants.HealthVaultWebConstants;

namespace Microsoft.HealthVault.Web.Extensions
{
    internal static class WebHealthVaultConfigurationExtensions
    {
        private static readonly string AuthTarget = "AUTH";

        /// <summary>
        /// Gets the URL to/from which BLOBs get streamed, for
        /// the configured default instance of the HealthVault web-service.
        /// </summary>
        ///
        /// <remarks>
        ///  When reading from web.config, this property corresponds to the "HealthVaultUrl" configuration
        /// value with the path modified to the appropriate handler.
        /// </remarks>
        public static Uri BlobStreamUrl(this WebHealthVaultConfiguration config) => config.HealthVaultUrl?.ReplacePath(Urls.BlobStreamUrlSuffix);

        /// <summary>
        /// Gets the HealthVault client service URL for
        /// the configured default instance of the HealthVault web-service,
        /// from the application or web configuration file.
        /// </summary>
        ///
        /// <remarks>
        ///  When reading from web.config, this property corresponds to the "HV_HealthVaultUrl" configuration
        /// value with the path modified to the appropriate handler.
        /// </remarks>
        public static Uri HealthClientServiceUrl(this WebHealthVaultConfiguration config) => config.HealthVaultUrl?.Append(Urls.HealthClientServiceSuffix);

        /// <summary>
        /// Gets the URL of the HealthVault Shell authentication page.
        /// </summary>
        ///
        /// <remarks>
        /// When reading from web.config, this property uses the "HV_ShellUrl" configuration value to construct the
        /// redirector URL with a target of "AUTH".
        /// </remarks>
        ///
        public static Uri HealthVaultShellAuthenticationUrl(this WebHealthVaultConfiguration config)
        {
            var redirect = new ShellRedirectParameters(config.HealthVaultShellUrl.OriginalString)
            {
                TargetLocation = AuthTarget,
                ApplicationId = config.MasterApplicationId,
            };

            return redirect.ConstructRedirectUrl();
        }

        /// <summary>
        /// Gets the HealthVault type schema root URL for
        /// the configured default instance of the HealthVault web-service.
        /// </summary>
        ///
        /// <remarks>
        /// This property corresponds to the "HV_HealthServiceUrl" configuration value when reading from web.config.
        /// </remarks>
        ///
        public static Uri HealthVaultTypeSchemaUrl(this WebHealthVaultConfiguration config) => new Uri(config.HealthVaultUrl, Urls.TypeSchemaSuffix);

        /// <summary>
        /// Shell redirector url, derived from web config.
        /// </summary>
        ///
        public static Uri ShellRedirectorUrl(this WebHealthVaultConfiguration config) => config.HealthVaultShellUrl?.Append(ConfigDefaults.ShellRedirectorLocation);

        /// <summary>
        /// Gets the URL of the page corresponding to the action.
        /// </summary>
        ///
        /// <remarks>
        /// This property corresponds to the "HV_Action*" configuration values when reading from web.config.
        /// </remarks>
        public static Uri GetActionUrl(this WebHealthVaultConfiguration config, string action) => config.ActionPageUrls[action];

        // Helpers

        private static Uri ReplacePath(this Uri original, string newPathWithLeadingSlash)
        {
            if (original == null)
            {
                return null;
            }

            return new Uri(original.GetLeftPart(UriPartial.Authority) + newPathWithLeadingSlash);
        }

        private static Uri Append(this Uri baseUrl, string path)
        {
            if (baseUrl == null)
            {
                return null;
            }

            return new Uri(baseUrl, path);
        }
    }
}