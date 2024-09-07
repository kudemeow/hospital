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

    [HttpPost("filter")]
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

    [HttpPost("Update")]
    public async Task<IActionResult> Update(PatientView patient)
    {
        ArgumentNullException.ThrowIfNull(patient);

        var newPatient = await _service.Update(patient);

        return Ok(newPatient);
    }

    [HttpPost("Delete")]
    public async Task<IActionResult> Delete(int id)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

        await _service.Delete(id);

        return Ok();
    }
} 