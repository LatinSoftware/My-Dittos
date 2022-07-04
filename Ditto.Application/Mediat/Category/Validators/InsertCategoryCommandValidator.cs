using Ditto.Application.Mediat.Category.Commands;
using FluentValidation;

namespace Ditto.Application.Mediat.Category.Validators;

public class InsertCategoryCommandValidator : AbstractValidator<InsertCategoryCommand>
{
    public InsertCategoryCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(50);
    }
}
