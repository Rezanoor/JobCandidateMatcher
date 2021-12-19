import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from "@angular/common/http";
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable()
export class AppService {

    private environmentSettings: any;


    constructor(private http: HttpClient) {
        this.environmentSettings = environment;
    }



    getBrowserName(): string {
        const agent = window.navigator.userAgent.toLowerCase()
        switch (true) {
            case agent.indexOf('edge') > -1:
                return "edge";
            case agent.indexOf('opr') > -1 && !!(<any>window).opr:
                return "opera"
            case agent.indexOf('chrome') > -1 && !!(<any>window).chrome:
                return "chrome";
            case agent.indexOf('trident') > -1:
                return "ie";
            case agent.indexOf('firefox') > -1:
                return "firefox";
            case agent.indexOf('safari') > -1:
                return "safari";
            default:
                return "other";
        }
    }


}