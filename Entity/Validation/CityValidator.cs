using Entity.Data.Request;
using FluentValidation;
namespace Entity.Validation;

public class CityValidator : AbstractValidator<CityViewModel>
{
    public CityValidator()
    {
        RuleFor(x => x.CityName).NotEmpty().WithMessage("First name is required")
            .MaximumLength(200).WithMessage("First name can not over 200 characters");
    }
}
