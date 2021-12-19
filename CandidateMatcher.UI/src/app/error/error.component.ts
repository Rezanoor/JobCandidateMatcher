import { Component, OnInit } from '@angular/core';
import { AppState } from '../app.state.service';

@Component({
  selector: 'app-error',
  templateUrl: './error.component.html',
  styleUrls: ['./error.component.css']
})
export class ErrorComponent implements OnInit {

  errorMessage: string;

  constructor(private appState: AppState) {
    this.errorMessage = appState.get('errorMessage');
  }

  ngOnInit() {
  }

}
