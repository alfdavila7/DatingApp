import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpErrorResponse, HTTP_INTERCEPTORS } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  intercept( // Intercepts the error request and handle the errors. Not a 200 or 300 but the 400 and 500 range
    req: import('@angular/common/http').HttpRequest<any>, // Request itself
    next: import('@angular/common/http').HttpHandler // What happens next
  ): import('rxjs').Observable<import('@angular/common/http').HttpEvent<any>> {
    return next.handle(req).pipe
    (
        catchError
        (
            error => {
                if (error.status === 401){
                    return throwError(error.status.text);
                }
                if (error instanceof HttpErrorResponse){
                    const applicationError = error.headers.get('Aplication-Error');
                    if(applicationError){
                        return throwError(applicationError);
                    }
                    const serverError = error.error;
                    let modalStateErrors = '';
                    if(serverError.errors && typeof serverError.errors === 'object'){
                        for(const key in serverError.errors){
                            if(serverError.errors[key]){ // [] object bracket notation
                                modalStateErrors += serverError.errors[key] + '\n';
                            }
                        }
                    }
                    return throwError(modalStateErrors || serverError || 'Server Error');
                }
            }
        )
    );
  }
}

export const ErrorInterceptorProvider = {
    provide: HTTP_INTERCEPTORS,
    useClass: ErrorInterceptor,
    multi: true
};
