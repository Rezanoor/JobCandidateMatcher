import { Component, OnInit, ChangeDetectorRef, ViewChild, ElementRef } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { AppService } from './app.service'
import { BreakpointObserver } from '@angular/cdk/layout';
import { Observable, Subscription } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';




@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})

export class AppComponent implements OnInit {



  private environmentSettings: any;

  constructor(
    public appService: AppService,
    private changeDetectorRef: ChangeDetectorRef,
    private router: Router,


  ) {
    this.environmentSettings = environment;

  }

  ngOnInit() {


  }

  ngOnDestroy() {


  }

}
