using AutoMapper;
using Hospital.Application.Interfaces.Services;
using Hospital.Application.Models.Views;
using Hospital.Domain.Dtos.Entities;
using Hospital.Domain.Interfaces.Repositories;

namespace Hospital.Application.Services;

public class DoctorService : IDoctorService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DoctorService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<DoctorView>> GetByQuery(DoctorView query)
    {
        ArgumentNullException.ThrowIfNull(query);

        var queryDto = _mapper.Map<DoctorDto>(query);

        var doctors = await _unitOfWork.DoctorRepository.GetByQuery(queryDto);

        return _mapper.Map<IEnumerable<DoctorView>>(doctors);
    }

    public async Task<DoctorView> Create(DoctorView doctor)
    {
        var doctorDto = _mapper.Map<DoctorDto>(doctor);

        var newDoctor = await _unitOfWork.DoctorRepository.Create(doctorDto);

        return _mapper.Map<DoctorView>(newDoctor);
    }

    public async Task<DoctorView> Update(DoctorView doctor)
    {
        ArgumentNullException.ThrowIfNull(doctor);

        var doctorDto = _mapper.Map<DoctorDto>(doctor);

        var newDoctor = await _unitOfWork.DoctorRepository.Update(doctorDto);

        return _mapper.Map<DoctorView>(newDoctor);
    }

    public async Task Delete(int id)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

        await _unitOfWork.DoctorRepository.Delete(id);
    }
}