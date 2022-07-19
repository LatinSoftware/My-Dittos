using Ditto.Application.Mediat.Dittos.Commands;
using Ditto.Common.Repositories;
using FluentValidation;

namespace Ditto.Application.Mediat.Dittos.Validators;

public class InsertDittoCommandValidator : AbstractValidator<InsertDittoCommand>
{
    public InsertDittoCommandValidator(IUnitOfWork repositories)
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
        RuleFor(x => x.FrecuencyTime).NotEmpty();
        RuleFor(x => x.Frecuency).NotEmpty();
        RuleFor(x => x.OrderDate).NotEmpty().GreaterThanOrEqualTo(DateTime.Today);
        RuleFor(x => x.ExpectedPrice).NotEmpty().GreaterThan(0);
   }
}
