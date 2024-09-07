using Hospital.Domain.Dtos.Entities;

namespace Hospital.Domain.Interfaces.Repositories;

public interface IDoctorRepository
{
    Task<IEnumerable<DoctorDto>> GetByQuery(DoctorDto query);
    Task<DoctorDto> Create(DoctorDto doctor);
    Task<DoctorDto> Update(DoctorDto doctor);
    Task Delete(int id);
}