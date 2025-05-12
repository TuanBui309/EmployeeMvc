using Entity.Constants;
using Entity.Data.Request;
using Entity.Repository.Repositories;
using Entity.Util.Utilities;
using FluentValidation;

namespace Entity.Validation;

public class DegreeValidator : AbstractValidator<DegreeViewModel>
{
	private readonly IDegreeRepository _degreeRepository;
	public DegreeValidator(IDegreeRepository degreeRepository)
	{
		_degreeRepository = degreeRepository;

		RuleFor(x => x.EmployeeId).NotEmpty().WithMessage("EmloyeeId is required")
			.MustAsync((model, EmployeeId, CancellationToken) => IsValidEmployeeId(model)).WithMessage("This person has a maximum of 3 unexpired degrees!");
		RuleFor(x => x.DegreeName).NotEmpty().WithMessage("DegreeName is required")
			.MaximumLength(Validations.NameDegreeMaxLength).WithMessage("Name can not over 250 characters");
		RuleFor(x => x.IssuedBy).NotEmpty().WithMessage("IssuedBy is required")
			.MaximumLength(Validations.IssuedByMaxLength).WithMessage("IssuedBy can not over 550 characters");
		RuleFor(x => x.DateRange).NotEmpty().WithMessage("DateRange is required")
			.Must(FuncUtilities.BeAValidDate).WithMessage("Invalid date (MM/dd/yyyy)!")
			.Must((model, DateRage, CancellationToken) => IsValidDate(model)).WithMessage("The issue date cannot be greater than the expiration date !");
		RuleFor(x => x.DateOfExpiry).NotEmpty().WithMessage("DateOfExpiry is required")
			.Must(FuncUtilities.BeAValidDateOfExpiry).WithMessage("Invalid date (MM/dd/yyyy)!")
			.Must((model, DateRange, CancellationToken) => IsValidDate(model)).WithMessage("Expiration date cannot be less than issue date");
	}
	private async Task<bool> IsValidEmployeeId(DegreeViewModel model)
	{
		var degree = await _degreeRepository.GetMultiByCondition(x => x.EmployeeId == model.EmployeeId && FuncUtilities.ConvertStringToDate(model.DateOfExpiry) > DateTime.Now && x.Id != model.Id);
		return degree.Count() < Validations.MaximumNumberOfDegrees;
	}

	private static bool IsValidDate(DegreeViewModel model)
	{
		return FuncUtilities.ConvertStringToDate(model.DateOfExpiry) > FuncUtilities.ConvertStringToDate(model.DateRange);
	}
}
