using Hospital.Domain.Dtos.Entities;

namespace Hospital.Domain.Interfaces.Repositories;

public interface IPatientRepository
{
    Task<PatientDto> GetById(int id);
    Task<IEnumerable<PatientDto>> GetByQuery(PatientDto query);
    Task<PatientDto> Create(PatientDto patientDto);
    Task<PatientDto> Update(PatientDto patientDto);
    Task Delete(int id);
}