// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Castle.Windsor;
using EdFi.Ods.AdminApp.Web._Installers;
using log4net;
using log4net.Config;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup("Azure", typeof(EdFi.Ods.AdminApp.Web.AzureStartup))]
namespace EdFi.Ods.AdminApp.Web
{
    public class AzureStartup : StartupBase
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(AzureStartup));

        protected override void InstallConfigurationSpecificInstaller(IWindsorContainer container)
        {
            if (AppSettings.AppStartup == "Azure")
                container.Install(new AzureInstaller());
        }

        protected override void ConfigureLogging(IAppBuilder app)
        {
            if (AppSettings.AppStartup == "Azure")
            {
                XmlConfigurator.Configure();

                var applicationInsightsInstrumentationKey = AppSettings.ApplicationInsightsInstrumentationKey;

                if (applicationInsightsInstrumentationKey != null)
                {
                    TelemetryConfiguration.Active.InstrumentationKey = applicationInsightsInstrumentationKey;
                    _logger.DebugFormat("Found AppInsights instrumentation key in Web.config -- AppInsights will capture traces");
                }
                else
                {
                    _logger.DebugFormat("No instrumentation key found in Web.config -- AppInsights will NOT capture traces");
                }
            }
        }
    }
}
