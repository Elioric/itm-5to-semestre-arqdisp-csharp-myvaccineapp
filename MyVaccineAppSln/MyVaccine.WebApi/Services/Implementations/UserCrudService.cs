using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyVaccine.WebApi.Dtos.User;
using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Repositories.Contracts;
using MyVaccine.WebApi.Services.Contracts;

namespace MyVaccine.WebApi.Services.Implementations;

public class UserCrudService : IUserService
{
    private readonly IBaseRepository<User> _userRepository;
    private readonly IMapper _mapper;

    public UserCrudService(IBaseRepository<User> userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserResponseDto> Add(UserRequestDto request)
    {
        var user = new User();
        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.AspNetUserId = request.AspNetUserId;

        await _userRepository.Add(user);
        var response = _mapper.Map<UserResponseDto>(user);
        return response;
    }

    public async Task<UserResponseDto> Delete(int id)
    {
        var user = await _userRepository.FindBy(x => x.UserId == id).FirstOrDefaultAsync();

        await _userRepository.Delete(user);
        var response = _mapper.Map<UserResponseDto>(user);
        return response;
    }

    public async Task<IEnumerable<UserResponseDto>> GetAll()
    {
        var users = await _userRepository.GetAll().AsNoTracking().ToListAsync();
        var response = _mapper.Map<IEnumerable<UserResponseDto>>(users);
        return response;
    }

    public async Task<UserResponseDto> GetById(int id)
    {
        var user = await _userRepository.FindByAsNoTracking(x => x.UserId == id).FirstOrDefaultAsync();
        var response = _mapper.Map<UserResponseDto>(user);
        return response;
    }

    public async Task<UserResponseDto> GetByAspNetUserId(string aspNetUserId)
    {
        var user = await _userRepository.FindByAsNoTracking(x => x.AspNetUserId == aspNetUserId).FirstOrDefaultAsync();
        var response = _mapper.Map<UserResponseDto>(user);
        return response;
    }

    public async Task<UserResponseDto> Update(UserRequestDto request, int id)
    {
        var user = await _userRepository.FindBy(x => x.UserId == id).FirstOrDefaultAsync();
        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.AspNetUserId = request.AspNetUserId;

        await _userRepository.Update(user);
        var response = _mapper.Map<UserResponseDto>(user);
        return response;
    }
}
