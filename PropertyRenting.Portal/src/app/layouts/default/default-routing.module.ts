import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { CityAddUpdateComponent } from "../../lookup/components/city/city-add-update/city-add-update.component";
import { CityListComponent } from "../../lookup/components/city/city-list/city-list.component";
import { CountryAddUpdateComponent } from "../../lookup/components/country/country-add-update/country-add-update.component";
import { CountryListComponent } from "../../lookup/components/country/country-list/country-list.component";
import { DashboardComponent } from "../../modules/dashboard/dashboard.component";
import { DefaultComponent } from "./default.component";

const routes: Routes = [
    {
        path: "",
        component: DefaultComponent,
        children: [
            {
                path: "",
                component: DashboardComponent,
            },
            {
                path: "countries",
                component: CountryListComponent,
            },
            {
                path: "countries/add",
                component: CountryAddUpdateComponent,
            },
            {
                path: "countries/edit/:id",
                component: CountryAddUpdateComponent,
            },
            {
                path: "cities",
                component: CityListComponent,
            },
            {
                path: "cities/add",
                component: CityAddUpdateComponent,
            },
            {
                path: "cities/edit/:id",
                component: CityAddUpdateComponent,
            },
        ],
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class DefaultRoutingModule {}
