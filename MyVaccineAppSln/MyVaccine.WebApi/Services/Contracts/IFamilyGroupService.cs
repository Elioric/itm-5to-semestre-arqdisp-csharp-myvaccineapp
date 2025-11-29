using MyVaccine.WebApi.Dtos.FamilyGroup;

namespace MyVaccine.WebApi.Services.Contracts;

public interface IFamilyGroupService
{
    Task<IEnumerable<FamilyGroupResponseDto>> GetAll();
    Task<FamilyGroupResponseDto> GetById(int id);
    Task<FamilyGroupResponseDto> Add(FamilyGroupRequestDto request);
    Task<FamilyGroupResponseDto> Update(FamilyGroupRequestDto request, int id);
    Task<FamilyGroupResponseDto> Delete(int id);
}
