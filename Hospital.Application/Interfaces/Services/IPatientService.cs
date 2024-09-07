using Hospital.Application.Models.Views;

namespace Hospital.Application.Interfaces.Services;

public interface IPatientService
{
    Task<IEnumerable<PatientView>> GetByQuery(PatientView query);
    Task<PatientView> Create(PatientView patient);
    Task<PatientView> Update(PatientView patient);
    Task Delete(int id); // better be Deactivate()
}