using System.ComponentModel;
using AutoMapper;
using Hospital.Application.Interfaces.Services;
using Hospital.Application.Models.Views;
using Hospital.Domain.Dtos.Entities;
using Hospital.Domain.Interfaces.Repositories;
using Hospital.Domain.Models.Entities;

namespace Hospital.Application.Services;

public class PatientService : IPatientService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PatientService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PatientView> GetById(int id)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

        var patient = await _unitOfWork.PatientRepository.GetById(id);

        return _mapper.Map<PatientView>(patient);
    }

    public async Task<IEnumerable<PatientView>> GetByQuery(PatientView query)
    {
        ArgumentNullException.ThrowIfNull(query);

        var queryDto = _mapper.Map<PatientDto>(query);

        var patients = await _unitOfWork.PatientRepository.GetByQuery(queryDto);

        return _mapper.Map<IEnumerable<PatientView>>(patients);
    }

    public async Task<PatientView> Create(PatientView patientView)
    {
        var patientDto = _mapper.Map<PatientDto>(patientView);

        var newPatient = await _unitOfWork.PatientRepository.Create(patientDto);
        
        return _mapper.Map<PatientView>(newPatient);
    }

    public async Task<PatientView> Update(int id, PatientView patientView)
    {
        ArgumentNullException.ThrowIfNull(patientView);

        var existingPatient = await _unitOfWork.PatientRepository.GetById(id);

        var patient = _mapper.Map(patientView, existingPatient);

        var newPatient = await _unitOfWork.PatientRepository.Update(patient);

        return _mapper.Map<PatientView>(newPatient);
    }

    public async Task Delete(int id)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

        await _unitOfWork.PatientRepository.Delete(id);
    }
}