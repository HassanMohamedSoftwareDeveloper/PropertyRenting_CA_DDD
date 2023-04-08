import { Component, OnInit } from "@angular/core";
import {
    FormBuilder,
    FormControl,
    FormGroup,
    Validators,
} from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { Country } from "../../../models/country/country";
import { CountryService } from "../../../services/country.service";

@Component({
    selector: "app-country-add-update",
    templateUrl: "./country-add-update.component.html",
    styleUrls: ["./country-add-update.component.scss"],
})
export class CountryAddUpdateComponent implements OnInit {
    form!: FormGroup;
    country: Country = { id: "", name: "", nationality: "" };
    showForm = false;
    isNew = true;
    constructor(
        private fb: FormBuilder,
        private countryService: CountryService,
        private router: Router,
        private route: ActivatedRoute
    ) {}

    ngOnInit(): void {
        this.LoadData();
    }
    LoadData() {
        const id = this.route.snapshot.paramMap.get("id");
        if (id) {
            this.isNew = false;
            this.countryService.GetCountryById(id).subscribe(
                (res) => {
                    this.country = res;
                    this.CreateForm();
                },
                (error) => {
                    console.log(error);
                }
            );
        } else {
            this.CreateForm();
        }
    }

    CreateForm() {
        this.form = this.fb.group({
            CountryName: [null, Validators.required],
            Nationality: [null, Validators.required],
        });
        this.showForm = true;
    }

    get CountryName() {
        return this.form.controls["CountryName"] as FormControl;
    }
    get Nationality() {
        return this.form.controls["Nationality"] as FormControl;
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
        this.countryService.CreateCountry(this.country).subscribe(() => {
            this.router.navigate(["/countries"]);
        });
    }
    Update() {
        this.countryService.UpdateCountry(this.country).subscribe(() => {
            this.router.navigate(["/countries"]);
        });
    }
}
