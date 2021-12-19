using CandidateMatcher.API;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace CandidateMatcher.IntegrationTest
{
    public class CandidateMatcherTest : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;
        public CandidateMatcherTest(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }

        [Fact]
        public async Task TestGetCandidateJobMatchListAsync()
        {
            // Arrange
            var request = "/CandidateMatcher/GetCandidateJobMatchList";

            // Act
            var response = await Client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
