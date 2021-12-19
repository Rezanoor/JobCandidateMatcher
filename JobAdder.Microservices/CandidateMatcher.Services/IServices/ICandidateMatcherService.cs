using CandidateMatcher.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateMatcher.Services.IServices
{
    public interface ICandidateMatcherService
    {
        IEnumerable<CandidateJobMatch> GetCandidateJobMatchList();
    }
}
