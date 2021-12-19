using CandidateMatcher.Common.IServices;
using CandidateMatcher.Common.Resources;
using Newtonsoft.Json;
using System;


namespace CandidateMatcher.Common.Services
{
    public class ExternalApiService : IExternalApiService
    {
        private HttpClientFactory _httpClientFactory;

        public ExternalApiService(HttpClientFactory httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;
        }

        public T GetEntity<T>(string httpClientName, string query)
        {
            var result = GetResultByQuery(httpClientName, query);
            T entity = JsonConvert.DeserializeObject<T>(result);
            return entity;
        }

        private string GetResultByQuery(string httpClientName, string query)
        {
            var client = _httpClientFactory.GetHttpClient(httpClientName);

            var response = client.GetAsync(query).Result;

            if (response.IsSuccessStatusCode)
                return response.Content.ReadAsStringAsync().Result;
            else
                throw new ApplicationException($"External API Issue - {response.StatusCode} - {response.ReasonPhrase}");
        }
    }
}
