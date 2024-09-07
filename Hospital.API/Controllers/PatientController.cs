using Hospital.Application.Interfaces.Services;
using Hospital.Application.Models.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "RequireAuthenticatedUser")]

public class PatientController : ControllerBase
{
    private readonly IPatientService _service;

    public PatientController(IPatientService service)
    {
        _service = service;
    }

    [HttpGet("getById")]
    public async Task<IActionResult> GetById(int id)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

        var patient = await _service.GetById(id);

        return Ok(patient);
    }

    [HttpPost("query")]
    public async Task<IActionResult> GetByQuery(PatientView query)
    {
        ArgumentNullException.ThrowIfNull(query);

        var patients = await _service.GetByQuery(query);

        return Ok(patients);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(PatientView patient)
    {
        ArgumentNullException.ThrowIfNull(patient);

        var newPatient = await _service.Create(patient);

        return Ok(newPatient);
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update(int id, PatientView patient)
    {
        ArgumentNullException.ThrowIfNull(patient);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

        if (id != patient.Id)
        {
            return BadRequest();
        }

        var newPatient = await _service.Update(id, patient);

        return Ok(newPatient);
    }

    [HttpPost("delete")]
    public async Task<IActionResult> Delete(int id)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

        await _service.Delete(id);

        return Ok();
    }
} 