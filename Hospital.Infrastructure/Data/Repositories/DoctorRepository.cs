using AutoMapper;
using AutoMapper.QueryableExtensions;
using Hospital.Domain.Dtos.Entities;
using Hospital.Domain.Interfaces.Repositories;
using Hospital.Domain.Models.Entities;
using Hospital.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Data.Repositories;

public class DoctorRepository : IDoctorRepository
{
    private readonly HospitalDbContext _context;
    private readonly IMapper _mapper;

    public DoctorRepository(HospitalDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<DoctorDto> GetById(int id)
    {
        return await _context.Doctors
            .AsNoTracking()
            .ProjectTo<DoctorDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<DoctorDto>> GetByQuery(DoctorDto query)
    {
        ArgumentNullException.ThrowIfNull(query);

        var entity = _context.Doctors.AsNoTracking();

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

        if (query.SpecializationId != 0 && query.SpecializationId > 0)
        {
            entity = entity.Where(x => x.SpecializationId == query.SpecializationId);
        }

        if (query.OfficeId != 0 && query.OfficeId > 0)
        {
            entity = entity.Where(x => x.OfficeId == query.OfficeId);
        }

        if (query.UnitId != 0 && query.UnitId > 0)
        {
            entity = entity.Where(x => x.UnitId == query.UnitId);
        }

        if (query.IsUnitDoctor)
        {
            entity = entity.Where(x => x.IsUnitDoctor);
        }
        else
        {
            entity = entity.Where(x => x.IsUnitDoctor == false);
        }

        var result = await entity.ToListAsync();

        return _mapper.Map<IEnumerable<DoctorDto>>(result);
    }

    public async Task<DoctorDto> Create(DoctorDto doctor)
    {
        ArgumentNullException.ThrowIfNull(doctor);

        var newDoctor = _mapper.Map<Doctor>(doctor);

        _context.Doctors.Add(newDoctor);
        await _context.SaveChangesAsync();

        return await GetById(newDoctor.Id);
    }

    public async Task<DoctorDto> Update(DoctorDto doctor)
    {
        ArgumentNullException.ThrowIfNull(doctor);

        var request = _mapper.Map<Doctor>(doctor);

        _context.Doctors.Update(request);
        await _context.SaveChangesAsync();

        return await GetById(request.Id);
    }

    public async Task Delete(int id)
    {
        var doctor = _mapper.Map<Doctor>(await GetById(id));

        if (doctor != null)
        {
            _context.Doctors.Remove(doctor);
        }
    }
}