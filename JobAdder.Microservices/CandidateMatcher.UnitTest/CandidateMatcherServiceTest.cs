using CandidateMatcher.Common.IServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CandidateMatcher.Services.Services;
using CandidateMatcher.Services.Models;
using CandidateMatcher.Common.Constants;
using CandidateMatcher.Services.Constants;
using System.Collections.Generic;
using System.IO;
using System;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Linq;

namespace CandidateMatcher.UnitTest
{

    [TestClass]
    public class CandidateMatcherServiceTest
    {
        private static Mock<IExternalApiService> _mockExternalApiService;


        public CandidateMatcherServiceTest()
        {
            _mockExternalApiService = new Mock<IExternalApiService>();
        }

        [TestMethod]
        public async Task TestFindTheBestCandidate()
        {
            var _jobs = new List<Job>();
            using (StreamReader streamReader = new StreamReader("TestData\\A_job_test_data.json"))
            {
                string json = await streamReader.ReadToEndAsync();
                _jobs = JsonConvert.DeserializeObject<List<Job>>(json);
            }

            var _candidates = new List<Candidate>();
            using (StreamReader streamReader = new StreamReader("TestData\\A_candidate_test_data.json"))
            {
                string json = await streamReader.ReadToEndAsync();
                _candidates = JsonConvert.DeserializeObject<List<Candidate>>(json);
            }

            _mockExternalApiService.Setup(api => api.GetEntity<List<Job>>(HttpClientResourceNames.JOB_ADDER_API, ExternalEntities.JOBS)).Returns(_jobs);

            _mockExternalApiService.Setup(api => api.GetEntity<List<Candidate>>(HttpClientResourceNames.JOB_ADDER_API, ExternalEntities.CANDIDATES)).Returns(_candidates);

            var CandidateMatcherService = new CandidateMatcherService(_mockExternalApiService.Object);
            var candidateJobMatchList = CandidateMatcherService.GetCandidateJobMatchList();

            Assert.IsTrue(candidateJobMatchList.First().candidate.name.Equals("C4"));
        }

        [TestMethod]
        public async Task TestFindBestCandidateWhenDuplicateSkills()
        {
            var _jobs = new List<Job>();
            using (StreamReader streamReader = new StreamReader("TestData\\B_job_test_data.json"))
            {
                string json = await streamReader.ReadToEndAsync();
                _jobs = JsonConvert.DeserializeObject<List<Job>>(json);
            }

            var _candidates = new List<Candidate>();
            using (StreamReader streamReader = new StreamReader("TestData\\B_candidate_test_data.json"))
            {
                string json = await streamReader.ReadToEndAsync();
                _candidates = JsonConvert.DeserializeObject<List<Candidate>>(json);
            }

            _mockExternalApiService.Setup(api => api.GetEntity<List<Job>>(HttpClientResourceNames.JOB_ADDER_API, ExternalEntities.JOBS)).Returns(_jobs);

            _mockExternalApiService.Setup(api => api.GetEntity<List<Candidate>>(HttpClientResourceNames.JOB_ADDER_API, ExternalEntities.CANDIDATES)).Returns(_candidates);

            var CandidateMatcherService = new CandidateMatcherService(_mockExternalApiService.Object);
            var candidateJobMatchList = CandidateMatcherService.GetCandidateJobMatchList();

            Assert.IsTrue(candidateJobMatchList.First().candidate.name.Equals("C4"));
        }

        [TestMethod]
        public async Task TestFindBestCandidateWhenNumberOfSkillsMoreThanFirstSkillRequired()
        {
            var _jobs = new List<Job>();
            using (StreamReader streamReader = new StreamReader("TestData\\C_job_test_data.json"))
            {
                string json = await streamReader.ReadToEndAsync();
                _jobs = JsonConvert.DeserializeObject<List<Job>>(json);
            }

            var _candidates = new List<Candidate>();
            using (StreamReader streamReader = new StreamReader("TestData\\C_candidate_test_data.json"))
            {
                string json = await streamReader.ReadToEndAsync();
                _candidates = JsonConvert.DeserializeObject<List<Candidate>>(json);
            }

            _mockExternalApiService.Setup(api => api.GetEntity<List<Job>>(HttpClientResourceNames.JOB_ADDER_API, ExternalEntities.JOBS)).Returns(_jobs);

            _mockExternalApiService.Setup(api => api.GetEntity<List<Candidate>>(HttpClientResourceNames.JOB_ADDER_API, ExternalEntities.CANDIDATES)).Returns(_candidates);

            var CandidateMatcherService = new CandidateMatcherService(_mockExternalApiService.Object);
            var candidateJobMatchList = CandidateMatcherService.GetCandidateJobMatchList();

            Assert.IsTrue(candidateJobMatchList.First().candidate.name.Equals("C3"));
        }

        [TestMethod]
        public async Task TestFindBestCandidateWhenNumberOfSkillsAreDifferent()

        {
            var _jobs = new List<Job>();
            using (StreamReader streamReader = new StreamReader("TestData\\D_job_test_data.json"))
            {
                string json = await streamReader.ReadToEndAsync();
                _jobs = JsonConvert.DeserializeObject<List<Job>>(json);
            }

            var _candidates = new List<Candidate>();
            using (StreamReader streamReader = new StreamReader("TestData\\D_candidate_test_data.json"))
            {
                string json = await streamReader.ReadToEndAsync();
                _candidates = JsonConvert.DeserializeObject<List<Candidate>>(json);
            }

            _mockExternalApiService.Setup(api => api.GetEntity<List<Job>>(HttpClientResourceNames.JOB_ADDER_API, ExternalEntities.JOBS)).Returns(_jobs);

            _mockExternalApiService.Setup(api => api.GetEntity<List<Candidate>>(HttpClientResourceNames.JOB_ADDER_API, ExternalEntities.CANDIDATES)).Returns(_candidates);

            var CandidateMatcherService = new CandidateMatcherService(_mockExternalApiService.Object);
            var candidateJobMatchList = CandidateMatcherService.GetCandidateJobMatchList();

            Assert.IsTrue(candidateJobMatchList.First().candidate.name.Equals("C1"));
        }
    }
}
