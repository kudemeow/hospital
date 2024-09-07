using AutoMapper;
using Hospital.Domain.Interfaces.Repositories;
using Hospital.Infrastructure.Data.Contexts;
using Hospital.Infrastructure.Data.Repositories;

namespace Hospital.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly HospitalDbContext _context;

    public UnitOfWork(HospitalDbContext context, IMapper mapper)
    {
        _context = context;

        PatientRepository = new PatientRepository(_context, mapper);
        DoctorRepository = new DoctorRepository(_context, mapper);
    }

    public IPatientRepository PatientRepository { get; }
    public IDoctorRepository DoctorRepository { get; }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

}