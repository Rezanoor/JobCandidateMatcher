using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateMatcher.Services.Models
{
    public class Job
    {
        public int jobId { get; set; }
        public string name { get; set; }
        public string company { get; set; }
        public string skills { get; set; }
        public List<Skill> skillsList {get; set;}
    }
}
