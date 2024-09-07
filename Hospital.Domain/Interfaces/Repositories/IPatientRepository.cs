using Hospital.Domain.Dtos.Entities;

namespace Hospital.Domain.Interfaces.Repositories;

public interface IPatientRepository
{
    Task<IEnumerable<PatientDto>> GetByQuery(PatientDto query);
    Task<PatientDto> Create(PatientDto patient);
    Task<PatientDto> Update(PatientDto patient);
    Task Delete(int id);
}