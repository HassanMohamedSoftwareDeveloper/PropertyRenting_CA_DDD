import { Injectable } from "@angular/core";
import { MatPaginatorIntl } from "@angular/material/paginator";
import { Subject } from "rxjs";
import { TranslatorService } from "../services/translator.service";

@Injectable()
export class MyLocalizedPaginatorIntl implements MatPaginatorIntl {
    changes = new Subject<void>();
    firstPageLabel = "First page";
    itemsPerPageLabel = "Items per page:";
    lastPageLabel = "Last page";
    nextPageLabel = "Next page";
    previousPageLabel = "Previous page";
    page = "Page";
    of = "from";

    constructor(private translatorService: TranslatorService) {}
    getRangeLabel(page: number, pageSize: number, length: number): string {
        this.itemsPerPageLabel = this.translatorService.Translate(
            "Common.Paginator.ItemsPerPageLabel"
        );
        this.firstPageLabel = this.translatorService.Translate(
            "Common.Paginator.FirstPageLabel"
        );
        this.lastPageLabel = this.translatorService.Translate(
            "Common.Paginator.LastPageLabel"
        );
        this.nextPageLabel = this.translatorService.Translate(
            "Common.Paginator.NextPageLabel"
        );
        this.previousPageLabel = this.translatorService.Translate(
            "Common.Paginator.PreviousPageLabel"
        );
        this.page = this.translatorService.Translate("Common.Paginator.Page");
        this.of = this.translatorService.Translate("Common.Paginator.Of");

        if (length === 0) {
            return `${this.page} 1 ${this.of} 1  [0 ${this.of} 0]`;
        }
        const amountPages = Math.ceil(length / pageSize);
        const start = page * pageSize + 1;
        let end = start - 1 + pageSize;
        end = end > length ? length : end;
        return `${this.page} ${page + 1} ${
            this.of
        } ${amountPages}  [${start} - ${end} ${this.of} ${length}]`;
    }
}
