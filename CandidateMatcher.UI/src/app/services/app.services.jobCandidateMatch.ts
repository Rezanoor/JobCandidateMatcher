import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppServiceBase } from './app.services.share';



@Injectable()
export class JobCandidateMatchService extends AppServiceBase {

    getJobsCandidatesMatch(): Observable<any> {
        return this.http.get<any>(`${this.environmentSettings.JobCandidateBaseUrl}/GetCandidateJobMatchList/`);
    }

}

