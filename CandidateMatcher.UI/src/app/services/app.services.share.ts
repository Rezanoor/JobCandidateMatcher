import { HttpClient } from "@angular/common/http";
import { environment } from 'src/environments/environment';
import { Injectable } from "@angular/core";
import { AppService } from "../app.service";



@Injectable()
export class AppServiceBase {
    public environmentSettings: any;

    constructor(public http: HttpClient,
        public appService: AppService
    ) {
        this.environmentSettings = environment;
    }
}