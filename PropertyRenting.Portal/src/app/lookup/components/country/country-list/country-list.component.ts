import { Component, AfterViewInit, OnInit, ViewChild } from "@angular/core";
import { MatTableDataSource } from "@angular/material/table";
import { ConfirmService } from "../../../../shared/services/confirm.service";
import { TranslatorService } from "../../../../shared/services/translator.service";
import { Country } from "../../../models/country/country";
import { CountryService } from "../../../services/country.service";
import { String } from "typescript-string-operations";
import { MatPaginator, PageEvent } from "@angular/material/paginator";
import { environment } from "../../../../../environments/environment";

@Component({
    selector: "app-country-list",
    templateUrl: "./country-list.component.html",
    styleUrls: ["./country-list.component.scss"],
})
export class CountryListComponent implements AfterViewInit, OnInit {
    dataSource = new MatTableDataSource<Country>([]);
    @ViewChild(MatPaginator) paginator!: MatPaginator;
    displayedColumns: string[] = [];
    tables = [0];
    searchValue = "";
    pageSize = environment.Default_PageSize;
    pageIndex = 0;
    length = 50;
    pageSizeOptions = environment.PageSizeOptions;
    hidePageSize = false;
    showPageSizeOptions = true;
    showFirstLastButtons = true;
    disabled = false;

    constructor(
        private countryService: CountryService,
        private confirmService: ConfirmService,
        private translatorService: TranslatorService
    ) {
        this.displayedColumns.length = 3;

        this.displayedColumns[0] = "CountryName";
        this.displayedColumns[1] = "Nationality";
        this.displayedColumns[2] = "Actions";
    }
    ngOnInit(): void {
        this.Search(false);
    }
    ngAfterViewInit() {
        this.dataSource.paginator = this.paginator;
    }

    async Delete(element: Country) {
        const deleteMSG = String.format(
            this.translatorService.Translate("Country.DeleteMsg"),
            element.name
        );
        if (await this.confirmService.confirm(deleteMSG)) {
            this.countryService.DeleteCountry(element.id).subscribe(
                () => {
                    this.Search(false);
                },
                (error) => {
                    console.log(error);
                }
            );
        }
    }

    Search(resetPage: boolean) {
        this.pageIndex = resetPage ? 0 : this.pageIndex;
        this.countryService
            .GetCountriesByPageWithSearch(
                this.searchValue,
                this.pageIndex + 1,
                this.pageSize
            )
            .subscribe(
                (res) => {
                    this.InitiateData(res.data);
                    this.UpdatePaginator(res.pageNumber, res.totalCount);
                },
                (error) => {
                    console.log(error);
                }
            );
    }
    private InitiateData(data: Country[]) {
        this.dataSource = new MatTableDataSource<Country>(data);
    }
    private UpdatePaginator(page: number, totalCount: number) {
        this.pageIndex = page == 0 ? 0 : page - 1;
        this.length = totalCount;
        this.paginator.pageIndex = this.pageIndex;
        this.paginator.length = this.length;
    }

    handlePageEvent(e: PageEvent) {
        this.length = e.length;
        this.pageSize = e.pageSize;
        this.pageIndex = e.pageIndex;

        this.Search(false);
    }
}
