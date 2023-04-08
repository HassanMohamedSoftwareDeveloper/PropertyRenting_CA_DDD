import { Component } from "@angular/core";
import { ErrorService } from "../../services/error.service";

@Component({
    selector: "app-error",
    templateUrl: "./error.component.html",
    styleUrls: ["./error.component.scss"],
})
export class ErorrComponent {
    hasError$ = this.errorService.hasError$;
    errors$ = this.errorService.errors$;

    constructor(private errorService: ErrorService) {}

    Clear() {
        this.errorService.clearErrors();
    }
}
