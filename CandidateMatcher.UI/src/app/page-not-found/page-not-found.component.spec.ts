import { Location } from '@angular/common';
import { async, ComponentFixture, fakeAsync, TestBed, tick } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { RouterTestingModule } from '@angular/router/testing';
import { MockComponent } from 'ng-mocks';
import { JobsCandidatesMatchListComponent } from '../components/jobs-candidates-match-list/jobs-candidates-match-list.component';

import { PageNotFoundComponent } from './page-not-found.component';

describe('PageNotFoundComponent', () => {
  let component: PageNotFoundComponent;
  let fixture: ComponentFixture<PageNotFoundComponent>;
  let location: Location;
  let router: Router;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        PageNotFoundComponent,
        MockComponent(JobsCandidatesMatchListComponent)
      ],
      imports: [RouterTestingModule.withRoutes([
        { path: 'JobsCandidatesMatchListComponent', component: MockComponent(JobsCandidatesMatchListComponent) }
      ])],
    })
      .compileComponents();

    router = TestBed.get(Router);
    location = TestBed.get(Location);
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PageNotFoundComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should have link to JobsCandidatesMatchListComponent', () => {
    const anchorElement: HTMLAnchorElement = fixture.debugElement.query(By.css('#mainPage')).nativeElement as HTMLAnchorElement;
    const href = anchorElement.getAttribute('href');
    expect(href.toLowerCase()).toBe('/JobsCandidatesMatchList');
  })

  it('JobsCandidatesMatchListComponent link to navigate to match list', fakeAsync(() => {
    const anchorElement: HTMLAnchorElement = fixture.debugElement.query(By.css('#mainPage')).nativeElement as HTMLAnchorElement;
    anchorElement.click();
    tick();
    expect(location.path()).toBe('/JobsCandidatesMatchList');
  }))
});
