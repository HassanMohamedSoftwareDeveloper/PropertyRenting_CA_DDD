import { Injectable } from "@angular/core";
import { TranslateService } from "@ngx-translate/core";
import { TranslatorModel } from "../models/translator-model";

@Injectable({
    providedIn: "root",
})
export class TranslatorService {
    private static LANG_STORAGE_KEY = "Lang";
    private static DEFAULT_LANG_VALUE = "en";
    private static DEFAULT_LANG: TranslatorModel = {
        Value: "en",
        Description: "EN",
        Direction: "ltr",
    };
    private static LANG_LIST: TranslatorModel[] = [
        { ...TranslatorService.DEFAULT_LANG },
        {
            Description: "AR",
            Value: "ar",
            Direction: "rtl",
        },
    ];

    constructor(private translate: TranslateService) {}

    UseCurrentLanguage() {
        const lang_Value = TranslatorService.GET_LANGUAGE_VALUE();
        this.translate.use(lang_Value);
        const lang =
            TranslatorService.LANG_LIST.find((x) => x.Value == lang_Value) ||
            TranslatorService.DEFAULT_LANG;

        document.documentElement.lang = lang_Value;
        document.documentElement.dir = lang.Direction;
    }

    Translate(key: string) {
        return this.translate.instant(key);
    }

    static SET_LANGUAGE_VALUE(lang: string) {
        localStorage.setItem(TranslatorService.LANG_STORAGE_KEY, lang);
        window.location.reload();
    }
    static GET_LANG_LIST(): TranslatorModel[] {
        return TranslatorService.LANG_LIST;
    }
    static GET_CURRENT_LANGUAGE(): TranslatorModel {
        const current =
            TranslatorService.LANG_LIST.find(
                (x) => x.Value === TranslatorService.GET_LANGUAGE_VALUE()
            ) || TranslatorService.DEFAULT_LANG;

        return current;
    }
    static GET_LANGUAGE_VALUE(): string {
        return (
            localStorage.getItem(TranslatorService.LANG_STORAGE_KEY) ||
            TranslatorService.DEFAULT_LANG_VALUE
        );
    }
}
