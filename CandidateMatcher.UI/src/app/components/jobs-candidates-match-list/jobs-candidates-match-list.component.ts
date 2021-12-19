import { Component, OnInit } from '@angular/core';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { AppService } from 'src/app/app.service';
import { JobsCandidatesMatch } from 'src/app/models/jobs-candidates-match';
import { JobCandidateMatchService } from 'src/app/services/app.services.jobCandidateMatch';


@Component({
  selector: 'jobs-candidates-match-list',
  templateUrl: './jobs-candidates-match-list.component.html',
  styleUrls: ['./jobs-candidates-match-list.component.css']
})

export class JobsCandidatesMatchListComponent implements OnInit {

  @BlockUI('jobs-candidates-match-list') jobsCandidatesMatchListBlockUI: NgBlockUI;
  jobsCandidatesMatchList: JobsCandidatesMatch[];



  constructor(private appService: AppService,
    private jobCandidateMatchService: JobCandidateMatchService,
  ) { }

  ngOnInit() {
    this.GetJobsCandidatesMatchList();
  }

  private GetJobsCandidatesMatchList() {
    this.jobsCandidatesMatchListBlockUI.start();

    this.jobCandidateMatchService.getJobsCandidatesMatch().subscribe(
      (data: any) => {
        this.jobsCandidatesMatchList = data;
      }, error => {
        //TODO: error handling
        console.log(error);
        this.jobsCandidatesMatchListBlockUI.stop();
      }, () => {
        this.jobsCandidatesMatchListBlockUI.stop();
      });
  }

}
