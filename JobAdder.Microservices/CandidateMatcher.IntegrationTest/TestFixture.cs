using System.IO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Hosting;

namespace CandidateMatcher.IntegrationTest
{

    public class TestFixture<TStartup> : IDisposable
    {


        private TestServer Server;
        public HttpClient Client { get; }

        public IDictionary<string, string> portDictionary = new Dictionary<string, string>()
        {
            {"CandidateMatcher.API", "53207"}
        };

        public TestFixture()
            : this(Path.Combine(""))
        {
        }

        public void Dispose()
        {
            Client.Dispose();
            Server.Dispose();
        }

        protected TestFixture(string relativeTargetProjectParentDir)
        {
            var startupAssembly = typeof(TStartup).GetTypeInfo().Assembly;

            var contentRoot = GetProjectPath(relativeTargetProjectParentDir, startupAssembly);

            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(contentRoot)
                .AddJsonFile("appsettings.json");

            var webHostBuilder = new WebHostBuilder()
                .UseContentRoot(contentRoot)
                .ConfigureServices(InitializeServices)
                .UseConfiguration(configurationBuilder.Build())
                .UseEnvironment("Development")
                .UseStartup(typeof(TStartup));

            // Create instance of test server
            Server = new TestServer(webHostBuilder);

            // Add configuration for client
            Client = Server.CreateClient();
            Client.BaseAddress = new Uri($"http://localhost:{portDictionary[GetProjectName(startupAssembly)]}");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public static string GetProjectPath(string projectRelativePath, Assembly startupAssembly)
        {
            var projectName = GetProjectName(startupAssembly);

            var applicationBasePath = AppContext.BaseDirectory;

            var directoryInfo = new DirectoryInfo(applicationBasePath);

            do
            {
                directoryInfo = directoryInfo.Parent;

                var projectDirectoryInfo = new DirectoryInfo(Path.Combine(directoryInfo.FullName, projectRelativePath));

                if (projectDirectoryInfo.Exists)
                    if (new FileInfo(Path.Combine(projectDirectoryInfo.FullName, projectName, $"{projectName}.csproj")).Exists)
                        return Path.Combine(projectDirectoryInfo.FullName, projectName);

            }
            while (directoryInfo.Parent != null);

            throw new Exception($"Project root could not be located using the application root {applicationBasePath}.");
        }

        private static string GetProjectName(Assembly startupAssembly)
        {
            return startupAssembly.GetName().Name;
        }

        protected virtual void InitializeServices(IServiceCollection services)
        {
            var startupAssembly = typeof(TStartup).GetTypeInfo().Assembly;

            var manager = new ApplicationPartManager
            {
                ApplicationParts =
            {
                new AssemblyPart(startupAssembly)
            },
                FeatureProviders =
            {
                new ControllerFeatureProvider(),
                new ViewComponentFeatureProvider()
            }
            };

            services.AddSingleton(manager);
        }
    }
        
}
