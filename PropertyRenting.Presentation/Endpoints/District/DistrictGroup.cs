﻿namespace PropertyRenting.API.Endpoints.District;

internal sealed class DistrictGroup : Group
{
    public DistrictGroup()
    {
        Configure("districts", ep => { });
    }
}
