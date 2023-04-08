export class CityRequest {
    countryId: string | null;
    cityId: string | null;
    name: string | null;

    constructor(
        countryId: string | null,
        cityId: string | null,
        cityName: string | null
    ) {
        this.cityId = cityId;
        this.countryId = countryId;
        this.name = cityName;
    }
}
