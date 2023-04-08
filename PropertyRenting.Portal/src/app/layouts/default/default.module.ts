import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { DefaultComponent } from "./default.component";
import { DashboardComponent } from "../../modules/dashboard/dashboard.component";
import { RouterModule } from "@angular/router";
import { SharedModule } from "../../shared/shared.module";
import { LookupModule } from "../../lookup/lookup.module";
import { DefaultRoutingModule } from "./default-routing.module";

@NgModule({
    declarations: [DefaultComponent, DashboardComponent],
    imports: [
        CommonModule,
        RouterModule,
        DefaultRoutingModule,
        SharedModule,
        LookupModule,
    ],
})
export class DefaultModule {}
