export class JobsCandidatesMatch {
    job: Job;
    candidate: Candidate;
}

export class Job {
    jobId: number;
    name: string;
    company: string;
    skills: string;
}

export class Candidate {
    candidateId: number;
    name: string;
    skillTags: string;
}