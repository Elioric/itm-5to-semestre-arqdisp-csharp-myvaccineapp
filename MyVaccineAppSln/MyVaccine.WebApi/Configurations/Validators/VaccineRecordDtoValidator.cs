using FluentValidation;
using MyVaccine.WebApi.Dtos.VaccineRecord;

namespace MyVaccine.WebApi.Configurations.Validators;

public class VaccineRecordDtoValidator : AbstractValidator<VaccineRecordRequestDto>
{
    public VaccineRecordDtoValidator()
    {
        RuleFor(dto => dto.UserId).NotEmpty().GreaterThan(0);
        RuleFor(dto => dto.DependentId).NotEmpty().GreaterThan(0);
        RuleFor(dto => dto.VaccineId).NotEmpty().GreaterThan(0);
        RuleFor(dto => dto.DateAdministered).NotEmpty().LessThanOrEqualTo(DateTime.Now);
        RuleFor(dto => dto.AdministeredLocation).NotEmpty().MaximumLength(255);
        RuleFor(dto => dto.AdministeredBy).NotEmpty().MaximumLength(255);
    }
}
