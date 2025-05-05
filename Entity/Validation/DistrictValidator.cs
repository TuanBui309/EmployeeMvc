using Entity.Data.Request;
using FluentValidation;

namespace Entity.Validation;

public class DistrictValidator : AbstractValidator<DistrictViewModel>
{
    public DistrictValidator()
    {
        RuleFor(x => x.DistrictName).NotEmpty().WithMessage("District name is required");
    }
}
