import { CommonModule } from '@angular/common';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule, ViewContainerRef } from '@angular/core';
import { BrowserModule, Title } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { ServiceWorkerModule } from '@angular/service-worker';
import { environment } from '../environments/environment';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AppService } from './app.service';
import { ErrorComponent } from './error/error.component';
import { BlockTemplate } from './shared/blockuitemplate/blockTemplate';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { BlockUIModule } from 'ng-block-ui';
import { AppState } from './app.state.service';
import { JobsCandidatesMatchListComponent } from './components/jobs-candidates-match-list/jobs-candidates-match-list.component';
import { JobCandidateMatchService } from './services/app.services.jobCandidateMatch';
import { AppHttpInterceptor } from './app.htp-interceptor';


@NgModule({
  declarations: [
    AppComponent,
    ErrorComponent,
    JobsCandidatesMatchListComponent,
    PageNotFoundComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    RouterModule,
    ServiceWorkerModule.register('ngsw-worker.js', {
      enabled: environment.production,
    }),
    BlockUIModule.forRoot({
      delayStart: 0,
      delayStop: 500,
      message: "Loading...",
      template: BlockTemplate
    })
  ],
  providers: [
    AppService,
    AppState,
    JobCandidateMatchService,
    AppHttpInterceptor,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AppHttpInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent],
  entryComponents: [
    BlockTemplate
  ]
})
export class AppModule { }
