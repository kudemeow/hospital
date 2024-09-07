using Hospital.Application.Models.Views;

namespace Hospital.Application.Interfaces.Services;

public interface IDoctorService
{
    Task<DoctorView> GetById(int id);
    Task<IEnumerable<DoctorView>> GetByQuery(DoctorView query);
    Task<DoctorView> Create(DoctorView doctorView);
    Task<DoctorView> Update(int id, DoctorView doctorView);
    Task Delete(int id); // better be Deactivate()
}