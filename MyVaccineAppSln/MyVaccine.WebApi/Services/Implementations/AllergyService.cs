using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyVaccine.WebApi.Dtos.Allergy;
using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Repositories.Contracts;
using MyVaccine.WebApi.Services.Contracts;

namespace MyVaccine.WebApi.Services.Implementations;

public class AllergyService : IAllergyService
{
    private readonly IBaseRepository<Allergy> _allergyRepository;
    private readonly IMapper _mapper;

    public AllergyService(IBaseRepository<Allergy> allergyRepository, IMapper mapper)
    {
        _allergyRepository = allergyRepository;
        _mapper = mapper;
    }

    public async Task<AllergyResponseDto> Add(AllergyRequestDto request)
    {
        var allergy = new Allergy();
        allergy.Name = request.Name;
        allergy.UserId = request.UserId;

        await _allergyRepository.Add(allergy);
        var response = _mapper.Map<AllergyResponseDto>(allergy);
        return response;
    }

    public async Task<AllergyResponseDto> Delete(int id)
    {
        var allergy = await _allergyRepository.FindBy(x => x.AllergyId == id).FirstOrDefaultAsync();

        await _allergyRepository.Delete(allergy);
        var response = _mapper.Map<AllergyResponseDto>(allergy);
        return response;
    }

    public async Task<IEnumerable<AllergyResponseDto>> GetAll()
    {
        var allergies = await _allergyRepository.GetAll().AsNoTracking().ToListAsync();
        var response = _mapper.Map<IEnumerable<AllergyResponseDto>>(allergies);
        return response;
    }

    public async Task<AllergyResponseDto> GetById(int id)
    {
        var allergy = await _allergyRepository.FindByAsNoTracking(x => x.AllergyId == id).FirstOrDefaultAsync();
        var response = _mapper.Map<AllergyResponseDto>(allergy);
        return response;
    }

    public async Task<IEnumerable<AllergyResponseDto>> GetAllergiesByUserId(int userId)
    {
        var allergies = await _allergyRepository.FindByAsNoTracking(x => x.UserId == userId).ToListAsync();
        var response = _mapper.Map<IEnumerable<AllergyResponseDto>>(allergies);
        return response;
    }

    public async Task<AllergyResponseDto> Update(AllergyRequestDto request, int id)
    {
        var allergy = await _allergyRepository.FindBy(x => x.AllergyId == id).FirstOrDefaultAsync();
        allergy.Name = request.Name;
        allergy.UserId = request.UserId;

        await _allergyRepository.Update(allergy);
        var response = _mapper.Map<AllergyResponseDto>(allergy);
        return response;
    }
}
