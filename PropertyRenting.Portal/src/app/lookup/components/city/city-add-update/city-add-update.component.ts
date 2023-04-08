import { Component, OnInit } from "@angular/core";
import {
    FormBuilder,
    FormControl,
    FormGroup,
    Validators,
} from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { forkJoin } from "rxjs";
import { BaseLookup } from "../../../models/base-lookup";
import { CityRequest } from "../../../models/city/city-request";
import { CityService } from "../../../services/city-service";
import { LookupsService } from "../../../services/lookups-service";

@Component({
    selector: "app-city-add-update",
    templateUrl: "./city-add-update.component.html",
    styleUrls: ["./city-add-update.component.scss"],
})
export class CityAddUpdateComponent implements OnInit {
    form!: FormGroup;
    city: CityRequest = new CityRequest(null, null, "");
    countries: BaseLookup[] = [];
    showForm = false;
    isNew = true;
    constructor(
        private fb: FormBuilder,
        private cityService: CityService,
        private router: Router,
        private route: ActivatedRoute,
        private lookupsService: LookupsService
    ) {}

    ngOnInit(): void {
        this.LoadData();
    }
    LoadData() {
        const id = this.route.snapshot.paramMap.get("id");
        if (id) {
            this.isNew = false;
            forkJoin(
                this.cityService.GetCityById(id),
                this.lookupsService.GetCountriesLookup()
            ).subscribe(
                ([cityRes, countriesLookupRes]) => {
                    this.city = new CityRequest(
                        cityRes.countryId,
                        cityRes.cityId,
                        cityRes.cityName
                    );
                    this.countries = countriesLookupRes;
                    this.CreateForm();
                },
                (error) => {
                    console.log(error);
                }
            );
        } else {
            this.lookupsService.GetCountriesLookup().subscribe(
                (countriesLookupRes) => {
                    this.countries = countriesLookupRes;
                    this.CreateForm();
                },
                (error) => {
                    console.log(error);
                }
            );
        }
    }

    CreateForm() {
        this.form = this.fb.group({
            CityName: [null, Validators.required],
            CountryId: [null, Validators.required],
        });
        this.showForm = true;
    }

    get CityName() {
        return this.form.controls["CityName"] as FormControl;
    }
    get CountryId() {
        return this.form.controls["CountryId"] as FormControl;
    }

    onSubmit() {
        if (this.form.invalid) {
            return;
        }
        if (this.isNew) {
            this.Add();
        } else {
            this.Update();
        }
    }
    Add() {
        this.cityService.CreateCity(this.city).subscribe(() => {
            this.router.navigate(["/cities"]);
        });
    }
    Update() {
        this.cityService.UpdateCity(this.city).subscribe(() => {
            this.router.navigate(["/cities"]);
        });
    }

    Reset() {
        this.form.reset();
    }
}
