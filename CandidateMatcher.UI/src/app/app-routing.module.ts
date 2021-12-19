import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { JobsCandidatesMatchListComponent } from './components/jobs-candidates-match-list/jobs-candidates-match-list.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';



const appRoutes: Routes = [
  { path: '', redirectTo: 'JobsCandidatesMatchList', pathMatch: 'full' },
  { path: 'JobsCandidatesMatchList', component: JobsCandidatesMatchListComponent, },
  { path: '404', component: PageNotFoundComponent },
  { path: '**', redirectTo: '404' }
];

@NgModule({
  imports: [RouterModule.forRoot(
    appRoutes, { useHash: true }
  )]
})
export class AppRoutingModule { }
