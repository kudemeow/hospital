using AutoMapper;
using Hospital.Domain.Dtos.Entities;
using Hospital.Domain.Models.Entities;

namespace Hospital.Infrastructure.Models.Mappings;

public class InfrastructureMappingProfile : Profile
{
    public InfrastructureMappingProfile()
    {
        CreateUnitMappings();
        CreateDoctorMappings();
        CreateOfficeMappings();
        CreatePatientMappings();
        CreateSpecializationMappings();
    }

    private void CreateUnitMappings()
    {
        CreateMap<Unit, UnitDto>();
        CreateMap<UnitDto, Unit>();
    }

    private void CreateDoctorMappings()
    {
        CreateMap<Doctor, DoctorDto>();
        CreateMap<DoctorDto, Doctor>();
    }

    private void CreateOfficeMappings()
    {
        CreateMap<Office, OfficeDto>();
        CreateMap<OfficeDto, Office>();
    }

    public void CreatePatientMappings()
    {
        CreateMap<Patient, PatientDto>();
        CreateMap<PatientDto, Patient>();
    }

    private void CreateSpecializationMappings()
    {
        CreateMap<Specialization, SpecializationDto>();
        CreateMap<SpecializationDto, Specialization>();
    }
}
