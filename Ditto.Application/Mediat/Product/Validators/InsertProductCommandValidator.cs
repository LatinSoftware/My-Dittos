using Ditto.Application.Mediat.Product.Commands;
using FluentValidation;

namespace Ditto.Application.Mediat.Product.Validators;

public class InsertProductCommandValidator : AbstractValidator<InsertProductCommand>
{
    public InsertProductCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.CategoryId).GreaterThan(0);
        RuleFor(x => x.ImageUrl).NotEmpty().MaximumLength(800);
    }
}


