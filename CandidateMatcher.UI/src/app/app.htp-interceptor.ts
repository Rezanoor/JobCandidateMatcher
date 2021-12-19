import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { AppService } from './app.service';

@Injectable()

export class AppHttpInterceptor implements HttpInterceptor {
    constructor(private appService: AppService) { }
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        // modify request
        request = request.clone({

        });
        setTimeout(() => {

        });
        return next.handle(request)
            .pipe(
                tap(event => {
                    if (event instanceof HttpResponse) {
                        setTimeout(() => {

                        });
                    }
                }, error => {
                    console.error(error.message);

                })
            )
    }

}