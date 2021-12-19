import { AppComponent } from './app.component';
import { AppService } from './app.service';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { JobCandidateMatchService } from './services/app.services.jobCandidateMatch'
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE } from '@angular/material/core';
import { MAT_FORM_FIELD_DEFAULT_OPTIONS } from '@angular/material/form-field';
import { TestBed } from '@angular/core/testing';
import { AppModule } from './app.module';

describe('AppComponent', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        AppModule
      ],
      providers: [
        AppService,
        JobCandidateMatchService,
        { provide: MAT_FORM_FIELD_DEFAULT_OPTIONS, useValue: { appearance: 'fill' } },
        { provide: MAT_DATE_LOCALE, useValue: 'en-AU' },
        {
          provide: MAT_DATE_FORMATS, useValue: {
            parse: {
              dateInput: ["DD/MM/YYYY"]
            },
            display: {
              dateInput: "DD/MM/YYYY",
              monthYearLabel: 'MMM YYYY',
              dateA11yLabel: 'LL',
              monthYearA11yLabel: 'MMMM YYYY',
            }
          }
        },
      ]
    }).compileComponents();
  });

  it('should create the app', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app).toBeTruthy();
  });

  it(`should have as title 'app'`, () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app.title).toEqual('app');
  });

  it('should render title in a h1 tag', () => {
    const fixture = TestBed.createComponent(AppComponent);
    fixture.detectChanges();
    //expect(compiled.querySelector('h1').textContent).toContain('Welcome to contribution-portal!');
  });

});