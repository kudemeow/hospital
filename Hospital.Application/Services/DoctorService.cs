using System.Data.Common;
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

    public async Task<DoctorView> GetById(int id)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

        var doctor = await _unitOfWork.DoctorRepository.GetById(id);

        return _mapper.Map<DoctorView>(doctor);
    }

    public async Task<IEnumerable<DoctorView>> GetByQuery(DoctorView query)
    {
        ArgumentNullException.ThrowIfNull(query);

        var queryDto = _mapper.Map<DoctorDto>(query);

        var doctors = await _unitOfWork.DoctorRepository.GetByQuery(queryDto);

        return _mapper.Map<IEnumerable<DoctorView>>(doctors);
    }

    public async Task<DoctorView> Create(DoctorView doctorView)
    {
        var doctorDto = _mapper.Map<DoctorDto>(doctorView);

        var newDoctor = await _unitOfWork.DoctorRepository.Create(doctorDto);

        return _mapper.Map<DoctorView>(newDoctor);
    }

    public async Task<DoctorView> Update(int id, DoctorView doctorView)
    {
        ArgumentNullException.ThrowIfNull(doctorView);

        var existingDoctor = await _unitOfWork.DoctorRepository.GetById(id);

        var doctor = _mapper.Map(doctorView, existingDoctor);

        var newDoctor = await _unitOfWork.DoctorRepository.Update(doctor);

        return _mapper.Map<DoctorView>(newDoctor);
    }

    public async Task Delete(int id)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

        await _unitOfWork.DoctorRepository.Delete(id);
    }
}