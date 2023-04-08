import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { MaterialModule } from "../material/material.module";
import { HeaderComponent } from "./components/header/header.component";
import { FooterComponent } from "./components/footer/footer.component";
import { SidebarComponent } from "./components/sidebar/sidebar.component";
import { FlexLayoutModule } from "@angular/flex-layout";
import { FormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";
import { PageHeaderComponent } from "./components/page-header/page-header.component";
import { FormHeaderComponent } from "./components/form-header/form-header.component";
import { ConfirmComponent } from "./components/confirm/confirm.component";
import { LoaderComponent } from "./components/loader/loader.component";
import { LoaderService } from "./services/loader.service";
import { HttpClient, HTTP_INTERCEPTORS } from "@angular/common/http";
import { LoaderInterceptor } from "./interceptors/loader.interceptor";
import { TranslateHttpLoader } from "@ngx-translate/http-loader";
import { TranslateLoader, TranslateModule } from "@ngx-translate/core";
import { TranslatorService } from "./services/translator.service";
import { ErrorCatchingInterceptor } from "./interceptors/error-catching.interceptor";
import { ErorrComponent } from "./components/error/error.component";
import { ErrorService } from "./services/error.service";
import { MatPaginatorIntl } from "@angular/material/paginator";
import { MyLocalizedPaginatorIntl } from "./providers/my-localized-paginator-Intl";
@NgModule({
    declarations: [
        HeaderComponent,
        FooterComponent,
        SidebarComponent,
        PageHeaderComponent,
        FormHeaderComponent,
        ConfirmComponent,
        LoaderComponent,
        ErorrComponent,
    ],
    imports: [
        CommonModule,
        RouterModule,
        MaterialModule,
        FlexLayoutModule,
        FormsModule,
        TranslateModule.forRoot({
            defaultLanguage: TranslatorService.GET_CURRENT_LANGUAGE().Value,
            loader: {
                provide: TranslateLoader,
                useFactory: httpTranslateLoader,
                deps: [HttpClient],
            },
        }),
    ],
    providers: [
        LoaderService,
        {
            provide: HTTP_INTERCEPTORS,
            useClass: LoaderInterceptor,
            multi: true,
        },
        TranslatorService,
        ErrorService,
        {
            provide: HTTP_INTERCEPTORS,
            useClass: ErrorCatchingInterceptor,
            multi: true,
        },
        { provide: MatPaginatorIntl, useClass: MyLocalizedPaginatorIntl },
    ],
    exports: [
        HeaderComponent,
        FooterComponent,
        SidebarComponent,
        MaterialModule,
        PageHeaderComponent,
        FormHeaderComponent,
        ConfirmComponent,
        LoaderComponent,
        ErorrComponent,
    ],
})
export class SharedModule {}

export function httpTranslateLoader(http: HttpClient) {
    document.documentElement.lang = TranslatorService.GET_LANGUAGE_VALUE();
    return new TranslateHttpLoader(http, "./assets/i18n/", ".json");
}
