import { Component } from "@angular/core";

@Component({
    selector: "app-default",
    templateUrl: "./default.component.html",
    styleUrls: ["./default.component.scss"],
})
export class DefaultComponent {
    sideBarOpen = true;
    sideBarTooggler() {
        this.sideBarOpen = !this.sideBarOpen;
    }
}
