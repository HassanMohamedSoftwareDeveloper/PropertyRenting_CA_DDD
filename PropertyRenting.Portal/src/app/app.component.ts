import { Component } from "@angular/core";
import { TranslatorService } from "./shared/services/translator.service";

@Component({
    selector: "app-root",
    templateUrl: "./app.component.html",
    styleUrls: ["./app.component.scss"],
})
export class AppComponent {
    constructor(translatorService: TranslatorService) {
        translatorService.UseCurrentLanguage();
    }
}
