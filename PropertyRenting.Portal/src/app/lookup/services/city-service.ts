import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { PagedList } from "../../shared/models/paged-list-model";
import { CityDTO } from "../models/city/city-dto";
import { CityReadDTO } from "../models/city/city-read-dto";
import { CityRequest } from "../models/city/city-request";

@Injectable({
    providedIn: "root",
})
export class CityService {
    constructor(private http: HttpClient) {}

    GetCityList(): Observable<CityReadDTO[]> {
        return this.http.get<CityReadDTO[]>("/api/v1/cities/get-all");
    }
    GetCitiesByPage(
        page: number,
        pageSize: number
    ): Observable<PagedList<CityReadDTO>> {
        let params = new HttpParams();
        params = params.append("Page", page);
        params = params.append("PageSize", pageSize);
        const requestOptions = { params: params };
        return this.http.get<PagedList<CityReadDTO>>(
            "/api/v1/cities/get-by-page",
            requestOptions
        );
    }
    GetCitiesByPageWithSearch(
        search: string,
        page: number,
        pageSize: number
    ): Observable<PagedList<CityReadDTO>> {
        let params = new HttpParams();
        params = params.append("Page", page);
        params = params.append("PageSize", pageSize);
        params = params.append("Search", search);
        const requestOptions = { params: params };
        return this.http.get<PagedList<CityReadDTO>>(
            "/api/v1/cities/get-by-page-with-search",
            requestOptions
        );
    }
    GetCityById(id: string): Observable<CityDTO> {
        return this.http.get<CityDTO>(`/api/v1/cities/get-by-id/${id}`);
    }
    CreateCity(city: CityRequest) {
        return this.http.post("/api/v1/cities/create", city);
    }
    UpdateCity(city: CityRequest) {
        return this.http.put(`/api/v1/cities/update/${city.cityId}`, city);
    }
    DeleteCity(countryId: string, cityId: string) {
        return this.http.delete(`/api/v1/cities/remove/${countryId}/${cityId}`);
    }
}
