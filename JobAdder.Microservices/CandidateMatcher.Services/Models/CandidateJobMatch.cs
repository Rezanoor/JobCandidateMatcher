using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateMatcher.Services.Models
{
    public class CandidateJobMatch
    {
        public Candidate candidate { get; set; }
        public Job job { get; set; }
    }
}
