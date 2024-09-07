using AutoMapper;
using AutoMapper.QueryableExtensions;
using Hospital.Domain.Dtos.Entities;
using Hospital.Domain.Interfaces.Repositories;
using Hospital.Domain.Models.Entities;
using Hospital.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Data.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly HospitalDbContext _context;
    private readonly IMapper _mapper;

    public PatientRepository(HospitalDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PatientDto> GetById(int id)
    {
        return await _context.Patients
            .AsNoTracking()
            .ProjectTo<PatientDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<PatientDto>> GetByQuery(PatientDto query)
    {
        ArgumentNullException.ThrowIfNull(query);

        var entity = _context.Patients.AsNoTracking();

        if (query.LastName != null)
        {
            entity = entity.Where(x => x.LastName == query.LastName);
        }

        if (query.FirstName != null)
        {
            entity = entity.Where(x => x.FirstName == query.FirstName);
        }

        if (query.FatherName != null)
        {
            entity = entity.Where(x => x.FatherName == query.FatherName);
        }

        if (query.City != null)
        {
            entity = entity.Where(x => x.City == query.City);
        }

        if (query.Street != null)
        {
            entity = entity.Where(x => x.Street == query.Street);
        }

        if (query.Gender != null)
        {
            entity = entity.Where(x => x.Gender == query.Gender);
        }

        if (query.UnitId != 0 && query.UnitId > 0)
        {
            entity = entity.Where(x => x.UnitId == query.UnitId).Include(x => x.Unit.Number);
        }

        var result = await entity.ToListAsync();

        return _mapper.Map<IEnumerable<PatientDto>>(result);
    }

    public async Task<PatientDto> Create(PatientDto patientDto)
    {
        ArgumentNullException.ThrowIfNull(patientDto);

        var newPatient = _mapper.Map<Patient>(patientDto);

        _context.Patients.Add(newPatient);
        await _context.SaveChangesAsync();

        return await GetById(newPatient.Id);
    }

    public async Task<PatientDto> Update(PatientDto patientDto)
    {
        ArgumentNullException.ThrowIfNull(patientDto);

        var request = _mapper.Map<Patient>(patientDto);

        _context.Patients.Update(request);
        await _context.SaveChangesAsync();

        return await GetById(request.Id);
    }

    public async Task Delete(int id)
    {
        var patient = _mapper.Map<Patient>(await GetById(id));

        if (patient != null)
        {
            _context.Patients.Remove(patient);
        }
    }
}