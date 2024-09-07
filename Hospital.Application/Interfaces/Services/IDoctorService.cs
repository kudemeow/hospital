using Hospital.Application.Models.Views;

namespace Hospital.Application.Interfaces.Services;

public interface IDoctorService
{
    Task<IEnumerable<DoctorView>> GetByQuery(DoctorView query);
    Task<DoctorView> Create(DoctorView doctor);
    Task<DoctorView> Update(DoctorView doctor);
    Task Delete(int id); // better be Deactivate()
}