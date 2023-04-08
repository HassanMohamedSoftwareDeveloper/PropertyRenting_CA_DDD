import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { PagedList } from "../../shared/models/paged-list-model";
import { Country } from "../models/country/country";

@Injectable({
    providedIn: "root",
})
export class CountryService {
    constructor(private http: HttpClient) {}

    GetCountryList(): Observable<Country[]> {
        return this.http.get<Country[]>("/api/v1/countries/get-all");
    }
    GetCountriesByPage(
        page: number,
        pageSize: number
    ): Observable<PagedList<Country>> {
        let params = new HttpParams();
        params = params.append("Page", page);
        params = params.append("PageSize", pageSize);
        const requestOptions = { params: params };
        return this.http.get<PagedList<Country>>(
            "/api/v1/countries/get-by-page",
            requestOptions
        );
    }
    GetCountriesByPageWithSearch(
        search: string,
        page: number,
        pageSize: number
    ): Observable<PagedList<Country>> {
        let params = new HttpParams();
        params = params.append("Page", page);
        params = params.append("PageSize", pageSize);
        params = params.append("Search", search);
        const requestOptions = { params: params };
        return this.http.get<PagedList<Country>>(
            "/api/v1/countries/get-by-page-with-search",
            requestOptions
        );
    }
    GetCountryById(id: string): Observable<Country> {
        return this.http.get<Country>(`/api/v1/countries/get-by-id/${id}`);
    }
    CreateCountry(country: Country) {
        return this.http.post("/api/v1/countries/create", country);
    }
    UpdateCountry(country: Country) {
        return this.http.put(`/api/v1/countries/update/${country.id}`, country);
    }
    DeleteCountry(id: string) {
        return this.http.delete(`/api/v1/countries/remove/${id}`);
    }
}
