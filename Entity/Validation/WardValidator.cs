using Entity.Data.Request;
using FluentValidation;

namespace Entity.Validation;

public class WardValidator : AbstractValidator<WardViewModel>
{
    public WardValidator()
    {
        RuleFor(x => x.WardName).NotEmpty().WithMessage("Ward name is required");
    }
}
