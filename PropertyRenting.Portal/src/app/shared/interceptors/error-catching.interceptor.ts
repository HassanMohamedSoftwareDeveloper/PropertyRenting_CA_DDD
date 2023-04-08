import { Injectable } from "@angular/core";
import {
    HttpErrorResponse,
    HttpEvent,
    HttpHandler,
    HttpInterceptor,
    HttpRequest,
} from "@angular/common/http";
import { Observable, throwError } from "rxjs";
import { catchError, map } from "rxjs/operators";
import { ErrorService } from "../services/error.service";

@Injectable()
export class ErrorCatchingInterceptor implements HttpInterceptor {
    constructor(private errorService: ErrorService) {}
    intercept(
        request: HttpRequest<unknown>,
        next: HttpHandler
    ): Observable<HttpEvent<unknown>> {
        this.errorService.clearErrors();
        return next.handle(request).pipe(
            map((res) => {
                return res;
            }),
            catchError((error: HttpErrorResponse) => {
                let errorMsg = "";
                if (error.error instanceof ErrorEvent) {
                    errorMsg = `Error: ${error.error.message}`;
                } else {
                    errorMsg = `Error Code: ${error.status},  Message: ${error.message}`;
                }
                this.errorService.Errors([errorMsg]);
                return throwError(errorMsg);
            })
        );
    }
}
