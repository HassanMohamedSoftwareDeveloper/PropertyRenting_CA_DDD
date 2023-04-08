import { Injectable } from "@angular/core";
import { MatDialog } from "@angular/material/dialog";
import { ConfirmComponent } from "../components/confirm/confirm.component";

@Injectable({
    providedIn: "root",
})
export class ConfirmService {
    constructor(private dialog: MatDialog) {}

    async confirm(msg: string) {
        const isClosed: boolean = await this.dialog
            .open(ConfirmComponent, {
                width: "800px",
                panelClass: "confirm-dialog-container",
                disableClose: true,
                position: { top: "4rem" },
                data: {
                    message: msg,
                },
            })
            .afterClosed()
            .toPromise();

        return isClosed;
    }
}
