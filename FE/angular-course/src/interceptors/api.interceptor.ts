import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable()
export class ApiInterceptor implements HttpInterceptor {

    public intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if (req.url.split('/')[0] === 'api') {
            const url = `${environment.apiBaseUrl}/${req.url}`;
            req = req.clone({
                url: url
            });
        }

        return next.handle(req);
    }
}
