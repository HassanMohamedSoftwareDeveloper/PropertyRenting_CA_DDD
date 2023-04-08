import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";

import { CountryService } from "./services/country.service";
import { MaterialModule } from "../material/material.module";
import { HttpClientModule } from "@angular/common/http";
import { CountryListComponent } from "./components/country/country-list/country-list.component";
import { CountryAddUpdateComponent } from "./components/country/country-add-update/country-add-update.component";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { SharedModule } from "../shared/shared.module";
import { TranslateModule } from "@ngx-translate/core";
import { CityListComponent } from "./components/city/city-list/city-list.component";
import { CityAddUpdateComponent } from "./components/city/city-add-update/city-add-update.component";
import { CityService } from "./services/city-service";
import { LookupsService } from "./services/lookups-service";

@NgModule({
    declarations: [
        CountryListComponent,
        CountryAddUpdateComponent,
        CityListComponent,
        CityAddUpdateComponent,
    ],
    imports: [
        CommonModule,
        RouterModule,
        MaterialModule,
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule,
        SharedModule,
        TranslateModule,
    ],
    providers: [CountryService, CityService, LookupsService],
    exports: [
        CountryListComponent,
        CountryAddUpdateComponent,
        CityListComponent,
        CityAddUpdateComponent,
    ],
})
export class LookupModule {}
