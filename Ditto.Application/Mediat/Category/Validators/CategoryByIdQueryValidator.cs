using Ditto.Application.Mediat.Category.Queries;
using FluentValidation;

namespace Ditto.Application.Mediat.Category.Validators;

public class CategoryByIdQueryValidator : AbstractValidator<CategoryByIdQuery>
{
    public CategoryByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .GreaterThan(0);
    }
}
