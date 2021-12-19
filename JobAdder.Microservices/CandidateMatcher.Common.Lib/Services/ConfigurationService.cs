using CandidateMatcher.Common.IServices;
using CandidateMatcher.Common.Models.Configurations;
using Microsoft.Extensions.Configuration;

namespace CandidateMatcher.Common.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private IConfiguration configuration;


        public ConfigurationService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public ApplicationConfiguration GetApplicationConfiguration()
        {
            var applicationConfiguration = new ApplicationConfiguration();
            configuration.GetSection(ApplicationConfiguration.Application).Bind(applicationConfiguration);
            return applicationConfiguration;
        }

        public JobAdderApiConfiguration GetJobAdderApiConfiguration()
        {
            var jobAdderApiConfiguration = new JobAdderApiConfiguration();
            configuration.GetSection(JobAdderApiConfiguration.JobAdderApi).Bind(jobAdderApiConfiguration);
            return jobAdderApiConfiguration;
        }
    }
}
