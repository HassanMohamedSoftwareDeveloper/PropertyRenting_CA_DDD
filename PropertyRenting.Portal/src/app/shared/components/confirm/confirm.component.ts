import { Component, Inject } from "@angular/core";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material/dialog";

@Component({
    selector: "app-confirm",
    templateUrl: "./confirm.component.html",
    styleUrls: ["./confirm.component.scss"],
})
export class ConfirmComponent {
    constructor(
        @Inject(MAT_DIALOG_DATA) public data: any,
        public dialogRef: MatDialogRef<ConfirmComponent>
    ) {}

    closeDialog() {
        this.dialogRef.close(false);
    }
}
