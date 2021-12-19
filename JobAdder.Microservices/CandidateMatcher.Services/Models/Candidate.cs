using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateMatcher.Services.Models
{
    public class Candidate
    {
        public int candidateId { get; set; }
        public string name { get; set; }
        public string skillTags { get; set; }
        public List<Skill> skillsList {get; set;}
    }
}
