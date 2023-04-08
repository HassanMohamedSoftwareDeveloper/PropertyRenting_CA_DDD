import { Injectable } from "@angular/core";
import { BehaviorSubject, Subject } from "rxjs";

@Injectable({
    providedIn: "root",
})
export class ErrorService {
    hasError$ = new Subject<boolean>();
    private _errors = new BehaviorSubject<string[]>([]);
    readonly errors$ = this._errors.asObservable();

    Errors(errors: string[]) {
        this.hasError$.next(true);
        this._errors.next(Object.assign([], errors));
    }
    clearErrors() {
        this.hasError$.next(false);
        this._errors.next(Object.assign([], []));
    }
}
