﻿namespace ESIN.Clinic.CrossCutting.Features.HospitalUnits;

public class GetHospitalUnitByIdQueryResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Room { get; set; } = string.Empty;
}