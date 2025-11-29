using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyVaccine.WebApi.Dtos.FamilyGroup;
using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Repositories.Contracts;
using MyVaccine.WebApi.Services.Contracts;

namespace MyVaccine.WebApi.Services.Implementations;

public class FamilyGroupService : IFamilyGroupService
{
    private readonly IBaseRepository<FamilyGroup> _familyGroupRepository;
    private readonly IMapper _mapper;

    public FamilyGroupService(IBaseRepository<FamilyGroup> familyGroupRepository, IMapper mapper)
    {
        _familyGroupRepository = familyGroupRepository;
        _mapper = mapper;
    }

    public async Task<FamilyGroupResponseDto> Add(FamilyGroupRequestDto request)
    {
        var familyGroup = new FamilyGroup();
        familyGroup.Name = request.Name;

        await _familyGroupRepository.Add(familyGroup);
        var response = _mapper.Map<FamilyGroupResponseDto>(familyGroup);
        return response;
    }

    public async Task<FamilyGroupResponseDto> Delete(int id)
    {
        var familyGroup = await _familyGroupRepository.FindBy(x => x.FamilyGroupId == id).FirstOrDefaultAsync();

        await _familyGroupRepository.Delete(familyGroup);
        var response = _mapper.Map<FamilyGroupResponseDto>(familyGroup);
        return response;
    }

    public async Task<IEnumerable<FamilyGroupResponseDto>> GetAll()
    {
        var familyGroups = await _familyGroupRepository.GetAll().AsNoTracking().ToListAsync();
        var response = _mapper.Map<IEnumerable<FamilyGroupResponseDto>>(familyGroups);
        return response;
    }

    public async Task<FamilyGroupResponseDto> GetById(int id)
    {
        var familyGroup = await _familyGroupRepository.FindByAsNoTracking(x => x.FamilyGroupId == id).FirstOrDefaultAsync();
        var response = _mapper.Map<FamilyGroupResponseDto>(familyGroup);
        return response;
    }

    public async Task<FamilyGroupResponseDto> Update(FamilyGroupRequestDto request, int id)
    {
        var familyGroup = await _familyGroupRepository.FindBy(x => x.FamilyGroupId == id).FirstOrDefaultAsync();
        familyGroup.Name = request.Name;

        await _familyGroupRepository.Update(familyGroup);
        var response = _mapper.Map<FamilyGroupResponseDto>(familyGroup);
        return response;
    }
}
