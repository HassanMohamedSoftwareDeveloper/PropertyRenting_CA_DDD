import { Component, EventEmitter, Output } from "@angular/core";
import { TranslatorModel } from "../../models/translator-model";
import { TranslatorService } from "../../services/translator.service";

@Component({
    selector: "app-header",
    templateUrl: "./header.component.html",
    styleUrls: ["./header.component.scss"],
})
export class HeaderComponent {
    @Output() toggleSideBarForMe = new EventEmitter();
    currentLanguage = TranslatorService.GET_LANGUAGE_VALUE();
    languageList: TranslatorModel[] = TranslatorService.GET_LANG_LIST();

    toggleSideBar() {
        this.toggleSideBarForMe.emit();
        setTimeout(() => {
            window.dispatchEvent(new Event("resize"));
        }, 300);
    }
    changeLanguage() {
        TranslatorService.SET_LANGUAGE_VALUE(this.currentLanguage);
    }
}
