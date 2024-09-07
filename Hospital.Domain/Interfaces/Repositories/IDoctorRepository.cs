using Hospital.Domain.Dtos.Entities;

namespace Hospital.Domain.Interfaces.Repositories;

public interface IDoctorRepository
{
    Task<DoctorDto> GetById(int id);
    Task<IEnumerable<DoctorDto>> GetByQuery(DoctorDto query);
    Task<DoctorDto> Create(DoctorDto doctorDto);
    Task<DoctorDto> Update(DoctorDto doctorDto);
    Task Delete(int id);
}