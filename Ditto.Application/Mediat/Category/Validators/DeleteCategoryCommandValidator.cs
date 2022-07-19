using Ditto.Application.Mediat.Category.Commands;
using FluentValidation;

namespace Ditto.Application.Mediat.Category.Validators;

public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
{
    public DeleteCategoryCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .GreaterThan(0);
    }
}