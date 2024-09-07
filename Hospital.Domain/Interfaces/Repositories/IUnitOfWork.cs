namespace Hospital.Domain.Interfaces.Repositories;

public interface IUnitOfWork
{
    IPatientRepository PatientRepository { get; }
    IDoctorRepository DoctorRepository { get; }

    Task<int> SaveChangesAsync();
}