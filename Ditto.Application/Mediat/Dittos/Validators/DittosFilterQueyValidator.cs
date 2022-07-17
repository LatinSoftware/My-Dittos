using Ditto.Application.Mediat.Dittos.Queries;
using Ditto.Common.Repositories;
using FluentValidation;

namespace Ditto.Application.Mediat.Dittos.Validators;

public class DittosFilterQueyValidator : AbstractValidator<DittosFilterQuery>
{
    public DittosFilterQueyValidator(IUnitOfWork repositories)
    {
        RuleFor(d => d.Limit).NotNull().NotEmpty().GreaterThanOrEqualTo(0).When(d => d.Offset.HasValue);
        RuleFor(d => d.Offset).NotNull().NotEmpty().GreaterThan(0).When(d => d.Limit.HasValue);
    }
}
