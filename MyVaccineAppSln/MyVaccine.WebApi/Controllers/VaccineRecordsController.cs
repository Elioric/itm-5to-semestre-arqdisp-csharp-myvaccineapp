using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyVaccine.WebApi.Dtos.VaccineRecord;
using MyVaccine.WebApi.Services.Contracts;

namespace MyVaccine.WebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class VaccineRecordsController : ControllerBase
{
    private readonly IVaccineRecordService _vaccineRecordService;
    private readonly IValidator<VaccineRecordRequestDto> _validator;

    public VaccineRecordsController(IVaccineRecordService vaccineRecordService, IValidator<VaccineRecordRequestDto> validator)
    {
        _vaccineRecordService = vaccineRecordService;
        _validator = validator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var vaccineRecords = await _vaccineRecordService.GetAll();
        return Ok(vaccineRecords);
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var vaccineRecord = await _vaccineRecordService.GetById(id);
        return Ok(vaccineRecord);
    }

    [HttpGet("get-records-by-userid/{userId}")]
    public async Task<IActionResult> GetRecordsByUserId(int userId)
    {
        var vaccineRecords = await _vaccineRecordService.GetRecordsByUserId(userId);
        return Ok(vaccineRecords);
    }

    [HttpGet("get-records-by-dependentid/{dependentId}")]
    public async Task<IActionResult> GetRecordsByDependentId(int dependentId)
    {
        var vaccineRecords = await _vaccineRecordService.GetRecordsByDependentId(dependentId);
        return Ok(vaccineRecords);
    }

    [HttpPost]
    public async Task<IActionResult> Create(VaccineRecordRequestDto vaccineRecordDto)
    {
        var validationResult = await _validator.ValidateAsync(vaccineRecordDto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }
        var vaccineRecord = await _vaccineRecordService.Add(vaccineRecordDto);
        return Ok(vaccineRecord);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, VaccineRecordRequestDto vaccineRecordDto)
    {
        var vaccineRecord = await _vaccineRecordService.Update(vaccineRecordDto, id);
        if (vaccineRecord == null)
        {
            return NotFound();
        }
        return Ok(vaccineRecord);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var vaccineRecord = await _vaccineRecordService.Delete(id);
        if (vaccineRecord == null)
        {
            return NotFound();
        }
        return Ok(vaccineRecord);
    }
}
