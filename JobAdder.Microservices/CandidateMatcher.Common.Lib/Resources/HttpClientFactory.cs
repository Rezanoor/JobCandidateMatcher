using CandidateMatcher.Common.Constants;
using CandidateMatcher.Common.IServices;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace CandidateMatcher.Common.Resources
{
    
    public class HttpClientFactory
    {
        private readonly IConfigurationService configurationService;

        private readonly IDictionary<string, IHttpClient> ConnectHttpClientDictionary = new Dictionary<string, IHttpClient>()
        {
            {HttpClientResourceNames.JOB_ADDER_API, new JobAdderApiHttpClient()},
            
        };

        public HttpClientFactory(IConfigurationService configurationService)
        {
            this.configurationService = configurationService;
        }

        public HttpClient GetHttpClient(string httpClientName)
        {
            return this.ConnectHttpClientDictionary[httpClientName].init(this.configurationService);
        }

        public interface IHttpClient
        {
            HttpClient init(IConfigurationService configurationService);
        }

        public class JobAdderApiHttpClient : IHttpClient
        {
            private static HttpClient _jobAdderApiHttpClient = null;
            private static readonly object _lock = new object();

            public HttpClient init(IConfigurationService configurationService)
            {
                lock (_lock)
                {
                    if (_jobAdderApiHttpClient is null)
                    {
                        _jobAdderApiHttpClient = new HttpClient();
                        _jobAdderApiHttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        _jobAdderApiHttpClient.BaseAddress = new Uri(configurationService.GetJobAdderApiConfiguration().BaseUrl);

                    }
                    return _jobAdderApiHttpClient;
                }
            }
        }
    }
}
