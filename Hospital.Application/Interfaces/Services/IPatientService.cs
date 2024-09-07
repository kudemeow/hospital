using Hospital.Application.Models.Views;

namespace Hospital.Application.Interfaces.Services;

public interface IPatientService
{
    Task<PatientView> GetById(int id);
    Task<IEnumerable<PatientView>> GetByQuery(PatientView query);
    Task<PatientView> Create(PatientView patientView);
    Task<PatientView> Update(int id, PatientView patientView);
    Task Delete(int id); // better be Deactivate()
}