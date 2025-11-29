using MyVaccine.WebApi.Dtos;
using MyVaccine.WebApi.Dtos.User;
using MyVaccine.WebApi.Models;

namespace MyVaccine.WebApi.Services.Contracts;

public interface IUserService
{
    Task<AuthResponseDto> AddUserAsync(RegisterRequetDto request);
    Task<AuthResponseDto> Login(LoginRequestDto request);
    Task<AuthResponseDto> RefreshToken(string email);
    Task<User> GetUserInfo(string email);
    Task<IEnumerable<UserResponseDto>> GetAll();
    Task<UserResponseDto> GetById(int id);
    Task<UserResponseDto> Add(UserRequestDto request);
    Task<UserResponseDto> Update(UserRequestDto request, int id);
    Task<UserResponseDto> Delete(int id);
    Task<UserResponseDto> GetByAspNetUserId(string aspNetUserId);
}
