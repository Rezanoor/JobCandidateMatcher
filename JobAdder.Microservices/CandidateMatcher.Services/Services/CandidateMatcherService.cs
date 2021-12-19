using CandidateMatcher.Common.Constants;
using CandidateMatcher.Common.IServices;
using CandidateMatcher.Services.Constants;
using CandidateMatcher.Services.Extentions;
using CandidateMatcher.Services.IServices;
using CandidateMatcher.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CandidateMatcher.Services.Services
{
    public class CandidateMatcherService : ICandidateMatcherService
    {
        #region Member Variables
        private IExternalApiService _externalApiService;
        #endregion

        #region Constructos
        public CandidateMatcherService(IExternalApiService externalApiService) {
            _externalApiService = externalApiService;
        }
        #endregion

        #region Public Methods
        public IEnumerable<CandidateJobMatch> GetCandidateJobMatchList()
        {
            List<Candidate> candidates = GetCandidatesListFromJobAdderApi();

            List<Job> jobs = GetJobsListFromJobAdderApi();

            return MatchJobsWithCandidates(jobs, candidates);
        }
        #endregion

        #region Private Methods
        private List<Candidate> GetCandidatesListFromJobAdderApi()
        {
            return _externalApiService.GetEntity<List<Candidate>>(HttpClientResourceNames.JOB_ADDER_API, ExternalEntities.CANDIDATES);
        }

        private List<Job> GetJobsListFromJobAdderApi()
        {
            return _externalApiService.GetEntity<List<Job>>(HttpClientResourceNames.JOB_ADDER_API, ExternalEntities.JOBS);
        }

        private List<CandidateJobMatch> MatchJobsWithCandidates(List<Job> jobs, List<Candidate> candidates)
        {
            var jobSkills = SetJobsSkillList(jobs);
            var candidateSkills = SetCandidateSkillList(candidates);

            return GetMatchListByJobListAndCandidateList(jobSkills, candidateSkills);
        }

        private List<Job> SetJobsSkillList(List<Job> jobs)
        {
            return jobs.Select(job => new Job()
            {
                jobId = job.jobId,
                name = job.name,
                company = job.company,
                skills = job.skills,
                skillsList = ConvertSkillTagsToSkillListForJob(job.skills)
            }).ToList();
        }

        private List<Candidate> SetCandidateSkillList(List<Candidate> candidates)
        {
            int maximumNumberOfSkills = GetLongestSkillListLength(candidates);
            return candidates.Select(candidate => new Candidate()
            {
                candidateId = candidate.candidateId,
                name = candidate.name,
                skillTags = candidate.skillTags,
                skillsList = ConvertSkillTagsToSkillListForCandidate(candidate.skillTags, maximumNumberOfSkills)
            }).ToList();
        }

        

        /// <summary>
        /// We have given each skill a weight equivalent to their order in the list
        /// First skill has the highest weight, We also remove duplicate values in skill tags as well
        /// (Distinct does that)
        /// </summary>
        /// <param name="skillTags"></param>
        /// <returns></returns>
        private List<Skill> ConvertSkillTagsToSkillListForJob(string jobSkillTags)
        {
            List<string> skillList = jobSkillTags.Split(",").Select(skill => skill.Trim()).Distinct().ToList();
            return skillList.Select((skillName, index) => new Skill() { name = skillName, weight = skillList.Count() - index }).ToList();
        }

        /// <summary>
        /// For Candidates, the order of skill weight starts from the longest candidate skill list
        /// </summary>
        /// <param name="jobSkillTags"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        private List<Skill> ConvertSkillTagsToSkillListForCandidate(string jobSkillTags, int maximumNumberOfSkills)
        {
            
            List<string> skillList = jobSkillTags.Split(",").Select(skill => skill.Trim()).Distinct().ToList();
            return skillList.Select((skillName, index) => new Skill() { name = skillName, weight = maximumNumberOfSkills - index }).ToList();
        }

        private int GetLongestSkillListLength(List<Candidate> candidates)
        {
            var maxCandidate = candidates.Max(candidate => candidate.skillTags.Split(",").Count());
            return maxCandidate;
        }

        private List<CandidateJobMatch> GetMatchListByJobListAndCandidateList(List<Job> jobs, List<Candidate> candidates)
        {
            List<CandidateJobMatch> candidateJobMatch = new List<CandidateJobMatch>();

            jobs.ForEach(job => {
                var CandidateJob = new CandidateJobMatch();
                CandidateJob.job = job;
                CandidateJob.candidate = FindBestCandidateForGivenJob(job, candidates);
                candidateJobMatch.Add(CandidateJob);
            });
            
            return candidateJobMatch;
        }

        private Candidate FindBestCandidateForGivenJob(Job job, List<Candidate> candidates)
        {
            Candidate bestCandidate = null;
            int bestScore = 0;
            foreach (Candidate candidate in candidates)
            {
                int candidateScore = GetCandidateScoreForGivenJob(candidate, job);
                
                if (candidateScore.GreaterThan(bestScore))
                {
                    bestScore = candidateScore;
                    bestCandidate = candidate;
                }
            }
            return bestCandidate;
        }

        /// <summary>
        /// If there is a match in a job skill list with candidate skill list
        /// we multiply their weights, and add up, this would be the candidate score for the job
        /// the higher score is, the better candidate rank
        /// </summary>
        /// <param name="candidate"></param>
        /// <param name="job"></param>
        /// <returns></returns>
        private int GetCandidateScoreForGivenJob(Candidate candidate, Job job)
        {
            int score = 0;
            candidate.skillsList.ForEach(candidateSkill => {

                var matchedSkill = job.skillsList.Find(jobSkill => jobSkill.name.ContainsIgnoreCase(candidateSkill.name));
                if (matchedSkill != null)
                    score = (matchedSkill.weight * candidateSkill.weight) + score;
            });
            return score;
        }
        #endregion
    }
}
