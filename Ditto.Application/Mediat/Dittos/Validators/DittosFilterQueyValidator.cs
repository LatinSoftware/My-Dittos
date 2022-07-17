using Ditto.Common.Models;
using Ditto.Common.Repositories;
using FluentValidation;

namespace Ditto.Application.Mediat.Dittos.Validators;

public class DittosFilterQueyValidator : AbstractValidator<DittoFilterModel>
{
    public DittosFilterQueyValidator(IUnitOfWork repositories)
    {
        RuleFor(d => d.Limit).NotNull().NotEmpty().When(d => d.Page.HasValue);
        RuleFor(d => d.Page).NotNull().NotEmpty().When(d => d.Limit.HasValue);
    }
}
