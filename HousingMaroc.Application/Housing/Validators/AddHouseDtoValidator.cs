using FluentValidation;
using HousingMaroc.Application.Housing.Commands;

namespace HousingMaroc.Application.Housing.Validators;

public class AddHouseDtoValidator: AbstractValidator<AddHouseCommand>
{
    public AddHouseDtoValidator()
    {
        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("Address is required");
        
        RuleFor(x => x.City)
            .NotEmpty().WithMessage("City is required");

        RuleFor(x => x.Description)
            .NotEmpty();
        
        RuleFor(x => x.Latitude)
            .NotEmpty().WithMessage("Latitude is required");
        
        RuleFor(x => x.Longitude)
            .NotEmpty().WithMessage("Longitude is required");
        
        RuleFor(x => x.Price)
            .NotEmpty().Must(x => x > 0).WithMessage("Price must be greater than 0");

        RuleFor(x => x.Images)
            .NotEmpty().WithMessage("Images are required");
    }
}
