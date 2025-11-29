using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyVaccine.WebApi.Dtos.Vaccine;
using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Repositories.Contracts;
using MyVaccine.WebApi.Services.Contracts;

namespace MyVaccine.WebApi.Services.Implementations;

public class VaccineService : IVaccineService
{
    private readonly IBaseRepository<Vaccine> _vaccineRepository;
    private readonly IMapper _mapper;

    public VaccineService(IBaseRepository<Vaccine> vaccineRepository, IMapper mapper)
    {
        _vaccineRepository = vaccineRepository;
        _mapper = mapper;
    }

    public async Task<VaccineResponseDto> Add(VaccineRequestDto request)
    {
        var vaccine = new Vaccine();
        vaccine.Name = request.Name;
        vaccine.RequiresBooster = request.RequiresBooster;

        await _vaccineRepository.Add(vaccine);
        var response = _mapper.Map<VaccineResponseDto>(vaccine);
        return response;
    }

    public async Task<VaccineResponseDto> Delete(int id)
    {
        var vaccine = await _vaccineRepository.FindBy(x => x.VaccineId == id).FirstOrDefaultAsync();

        await _vaccineRepository.Delete(vaccine);
        var response = _mapper.Map<VaccineResponseDto>(vaccine);
        return response;
    }

    public async Task<IEnumerable<VaccineResponseDto>> GetAll()
    {
        var vaccines = await _vaccineRepository.GetAll().AsNoTracking().ToListAsync();
        var response = _mapper.Map<IEnumerable<VaccineResponseDto>>(vaccines);
        return response;
    }

    public async Task<VaccineResponseDto> GetById(int id)
    {
        var vaccine = await _vaccineRepository.FindByAsNoTracking(x => x.VaccineId == id).FirstOrDefaultAsync();
        var response = _mapper.Map<VaccineResponseDto>(vaccine);
        return response;
    }

    public async Task<VaccineResponseDto> Update(VaccineRequestDto request, int id)
    {
        var vaccine = await _vaccineRepository.FindBy(x => x.VaccineId == id).FirstOrDefaultAsync();
        vaccine.Name = request.Name;
        vaccine.RequiresBooster = request.RequiresBooster;

        await _vaccineRepository.Update(vaccine);
        var response = _mapper.Map<VaccineResponseDto>(vaccine);
        return response;
    }
}
