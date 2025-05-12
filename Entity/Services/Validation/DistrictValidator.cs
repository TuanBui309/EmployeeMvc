﻿using Entity.Services.ViewModels;
using FluentValidation;

namespace Entity.Services.Validation;

public class DistrictValidator : AbstractValidator<DistrictViewModel>
{
    public DistrictValidator()
    {
        RuleFor(x => x.DistrictName).NotEmpty().WithMessage("District name is required");
    }
}
