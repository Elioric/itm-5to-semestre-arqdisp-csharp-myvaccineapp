using FluentValidation;
using MyVaccine.WebApi.Dtos.User;

namespace MyVaccine.WebApi.Configurations.Validators;

public class UserDtoValidator : AbstractValidator<UserRequestDto>
{
    public UserDtoValidator()
    {
        RuleFor(dto => dto.FirstName).NotEmpty().MaximumLength(255);
        RuleFor(dto => dto.LastName).NotEmpty().MaximumLength(255);
        RuleFor(dto => dto.AspNetUserId).NotEmpty().MaximumLength(450);
    }
}
