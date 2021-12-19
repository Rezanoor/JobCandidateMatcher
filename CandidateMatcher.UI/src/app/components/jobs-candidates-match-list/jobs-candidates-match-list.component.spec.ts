import { AppService } from 'src/app/app.service';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppState } from 'src/app/app.state.service';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { AppModule } from 'src/app/app.module';
import { DebugElement } from '@angular/core';
import { JobsCandidatesMatchListComponent } from './jobs-candidates-match-list.component';
import { JobCandidateMatchService } from 'src/app/services/app.services.jobCandidateMatch';



describe('JobsCandidatesMatchListComponent', () => {
  let component: JobsCandidatesMatchListComponent;
  let fixture: ComponentFixture<JobsCandidatesMatchListComponent>;
  let jobCandidateMatchService: JobCandidateMatchService;
  let de: DebugElement;

  //set up 
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        AppModule
      ],
      providers: [
        AppService,

        AppState,
        jobCandidateMatchService
      ]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(JobsCandidatesMatchListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
    //Init services here
    jobCandidateMatchService = TestBed.get(jobCandidateMatchService);
    de = fixture.debugElement;
  });

  //Tear down
  it('should create', () => {
    expect(component).toBeTruthy();
  });


});