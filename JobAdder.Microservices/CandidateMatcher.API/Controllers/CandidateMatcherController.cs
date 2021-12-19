using CandidateMatcher.Services.IServices;
using CandidateMatcher.Services.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidateMatcher.API.Controllers
{
    
    [Route("[controller]")]
    public class CandidateMatcherController : ControllerBase
    {
        private ICandidateMatcherService _candidateMatcherService;
        private readonly ILogger<CandidateMatcherController> _logger;

        public CandidateMatcherController(ICandidateMatcherService candidateMatcherService, ILogger<CandidateMatcherController> logger)
        {
            _candidateMatcherService = candidateMatcherService;
            _logger = logger;
        }

        /// <summary>
        /// Get the list of jobs with most suitable candidate
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCandidateJobMatchList")]
        public IEnumerable<CandidateJobMatch> GetCandidateJobMatchList()
        {
            return _candidateMatcherService.GetCandidateJobMatchList();
        }
    }
}
