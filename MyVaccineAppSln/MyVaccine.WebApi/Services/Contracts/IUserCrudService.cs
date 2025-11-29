using MyVaccine.WebApi.Dtos.User;

namespace MyVaccine.WebApi.Services.Contracts;

public interface IUserCrudService
{
    Task<IEnumerable<UserResponseDto>> GetAll();
    Task<UserResponseDto> GetById(int id);
    Task<UserResponseDto> Add(UserRequestDto request);
    Task<UserResponseDto> Update(UserRequestDto request, int id);
    Task<UserResponseDto> Delete(int id);
    Task<UserResponseDto> GetByAspNetUserId(string aspNetUserId);
}
