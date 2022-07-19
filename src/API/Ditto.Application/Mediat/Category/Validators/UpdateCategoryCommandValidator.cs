using Ditto.Application.Mediat.Category.Commands;
using FluentValidation;

namespace Ditto.Application.Mediat.Category.Validators;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(50);
    }
}
