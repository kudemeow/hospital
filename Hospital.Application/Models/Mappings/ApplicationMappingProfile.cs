using AutoMapper;
using Hospital.Application.Models.Views;
using Hospital.Domain.Dtos.Entities;

namespace Hospital.Application.Models.Mappings;

public class ApplicationMappingProfile : Profile
{
    public ApplicationMappingProfile()
    {
        CreateUnitMappings();
        CreateDoctorMappings();
        CreateOfficeMappings();
        CreatePatientMappings();
        CreateSpecializationMappings();
    }

    private void CreateUnitMappings()
    {
        CreateMap<UnitView, UnitDto>();
        CreateMap<UnitDto, UnitView>();
    }

    private void CreateDoctorMappings()
    {
        CreateMap<DoctorView, DoctorDto>();
        CreateMap<DoctorDto, DoctorView>();
    }

    private void CreateOfficeMappings()
    {
        CreateMap<OfficeView, OfficeDto>();
        CreateMap<OfficeDto, OfficeView>();
    }

    public void CreatePatientMappings()
    {
        CreateMap<PatientView, PatientDto>();
        CreateMap<PatientDto, PatientView>();
    }

    private void CreateSpecializationMappings()
    {
        CreateMap<SpecializationView, SpecializationDto>();
        CreateMap<SpecializationDto, SpecializationView>();
    }
}
