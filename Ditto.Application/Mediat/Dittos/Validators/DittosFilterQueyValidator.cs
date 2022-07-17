using Ditto.Common.Models;
using Ditto.Common.Repositories;
using FluentValidation;

namespace Ditto.Application.Mediat.Dittos.Validators;

public class DittosFilterQueyValidator : AbstractValidator<DittoFilterModel>
{
    public DittosFilterQueyValidator(IUnitOfWork repositories)
    {
        RuleFor(d => d.Limit).NotNull().NotEmpty().GreaterThan(0).When(d => d.Offset.HasValue);
        RuleFor(d => d.Offset).NotNull().NotEmpty().GreaterThan(0).When(d => d.Limit.HasValue);
    }
}
