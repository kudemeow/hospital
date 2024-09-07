using Hospital.Application.Interfaces.Services;
using Hospital.Application.Models.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "RequireAuthenticatedUser")]

public class DoctorController : ControllerBase
{
    private readonly IDoctorService _service;

    public DoctorController(IDoctorService service)
    {
        _service = service;
    }

    [HttpGet("getById")]
    public async Task<IActionResult> GetById(int id)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

        var doctor = await _service.GetById(id);

        return Ok(doctor);
    }

    [HttpPost("filter")]
    public async Task<IActionResult> GetByQuery(DoctorView query)
    {
        ArgumentNullException.ThrowIfNull(query);

        var doctors = await _service.GetByQuery(query);

        return Ok(doctors);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(DoctorView doctor)
    {
        ArgumentNullException.ThrowIfNull(doctor);

        var newDoctor = await _service.Create(doctor);

        return Ok(newDoctor);
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update(int id, DoctorView doctor)
    {
        ArgumentNullException.ThrowIfNull(doctor);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

        if (id != doctor.Id)
        {
            return BadRequest();
        }

        var newDoctor = await _service.Update(id, doctor);

        return Ok(newDoctor);
    }

    [HttpPost("delete")]
    public async Task<IActionResult> Delete(int id)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

        await _service.Delete(id);

        return Ok();
    }
} 