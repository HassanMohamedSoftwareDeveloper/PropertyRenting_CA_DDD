import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { AuthRoutingModule } from "./auth-routing.module";
import { LoginComponent } from "./components/login/login.component";
import { SignupComponent } from "./components/signup/signup.component";
import { ChangepasswordComponent } from "./components/changepassword/changepassword.component";
import { RouterModule } from "@angular/router";
import { AuthComponent } from "./auth.component";

@NgModule({
    declarations: [
        LoginComponent,
        SignupComponent,
        ChangepasswordComponent,
        AuthComponent,
    ],
    imports: [CommonModule, RouterModule, AuthRoutingModule],
})
export class AuthModule {}
