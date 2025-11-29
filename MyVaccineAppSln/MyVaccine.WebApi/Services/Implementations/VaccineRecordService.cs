using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyVaccine.WebApi.Dtos.VaccineRecord;
using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Repositories.Contracts;
using MyVaccine.WebApi.Services.Contracts;

namespace MyVaccine.WebApi.Services.Implementations;

public class VaccineRecordService : IVaccineRecordService
{
    private readonly IBaseRepository<VaccineRecord> _vaccineRecordRepository;
    private readonly IMapper _mapper;

    public VaccineRecordService(IBaseRepository<VaccineRecord> vaccineRecordRepository, IMapper mapper)
    {
        _vaccineRecordRepository = vaccineRecordRepository;
        _mapper = mapper;
    }

    public async Task<VaccineRecordResponseDto> Add(VaccineRecordRequestDto request)
    {
        var vaccineRecord = new VaccineRecord();
        vaccineRecord.UserId = request.UserId;
        vaccineRecord.DependentId = request.DependentId;
        vaccineRecord.VaccineId = request.VaccineId;
        vaccineRecord.DateAdministered = request.DateAdministered;
        vaccineRecord.AdministeredLocation = request.AdministeredLocation;
        vaccineRecord.AdministeredBy = request.AdministeredBy;

        await _vaccineRecordRepository.Add(vaccineRecord);
        var response = _mapper.Map<VaccineRecordResponseDto>(vaccineRecord);
        return response;
    }

    public async Task<VaccineRecordResponseDto> Delete(int id)
    {
        var vaccineRecord = await _vaccineRecordRepository.FindBy(x => x.VaccineRecordId == id).FirstOrDefaultAsync();

        await _vaccineRecordRepository.Delete(vaccineRecord);
        var response = _mapper.Map<VaccineRecordResponseDto>(vaccineRecord);
        return response;
    }

    public async Task<IEnumerable<VaccineRecordResponseDto>> GetAll()
    {
        var vaccineRecords = await _vaccineRecordRepository.GetAll().AsNoTracking().ToListAsync();
        var response = _mapper.Map<IEnumerable<VaccineRecordResponseDto>>(vaccineRecords);
        return response;
    }

    public async Task<VaccineRecordResponseDto> GetById(int id)
    {
        var vaccineRecord = await _vaccineRecordRepository.FindByAsNoTracking(x => x.VaccineRecordId == id).FirstOrDefaultAsync();
        var response = _mapper.Map<VaccineRecordResponseDto>(vaccineRecord);
        return response;
    }

    public async Task<IEnumerable<VaccineRecordResponseDto>> GetRecordsByUserId(int userId)
    {
        var vaccineRecords = await _vaccineRecordRepository.FindByAsNoTracking(x => x.UserId == userId).ToListAsync();
        var response = _mapper.Map<IEnumerable<VaccineRecordResponseDto>>(vaccineRecords);
        return response;
    }

    public async Task<IEnumerable<VaccineRecordResponseDto>> GetRecordsByDependentId(int dependentId)
    {
        var vaccineRecords = await _vaccineRecordRepository.FindByAsNoTracking(x => x.DependentId == dependentId).ToListAsync();
        var response = _mapper.Map<IEnumerable<VaccineRecordResponseDto>>(vaccineRecords);
        return response;
    }

    public async Task<VaccineRecordResponseDto> Update(VaccineRecordRequestDto request, int id)
    {
        var vaccineRecord = await _vaccineRecordRepository.FindBy(x => x.VaccineRecordId == id).FirstOrDefaultAsync();
        vaccineRecord.UserId = request.UserId;
        vaccineRecord.DependentId = request.DependentId;
        vaccineRecord.VaccineId = request.VaccineId;
        vaccineRecord.DateAdministered = request.DateAdministered;
        vaccineRecord.AdministeredLocation = request.AdministeredLocation;
        vaccineRecord.AdministeredBy = request.AdministeredBy;

        await _vaccineRecordRepository.Update(vaccineRecord);
        var response = _mapper.Map<VaccineRecordResponseDto>(vaccineRecord);
        return response;
    }
}
