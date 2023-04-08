import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { BaseLookup } from "../models/base-lookup";

@Injectable({
    providedIn: "root",
})
export class LookupsService {
    constructor(private http: HttpClient) {}

    GetCountriesLookup(): Observable<BaseLookup[]> {
        return this.http.get<BaseLookup[]>("/api/v1/countries/lookups/get-all");
    }
}
