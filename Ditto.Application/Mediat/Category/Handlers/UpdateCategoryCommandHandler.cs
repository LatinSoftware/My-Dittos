using AutoMapper;
using Ditto.Application.Mediat.Category.Commands;
using Ditto.Common.Repositories;
using MediatR;

namespace Ditto.Application.Mediat.Category.Handlers;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
{
    private readonly IUnitOfWork repositories;
    private readonly IMapper mapper;

    public UpdateCategoryCommandHandler(IUnitOfWork repositories, IMapper mapper)
    {
        this.repositories = repositories;
        this.mapper = mapper;
    }
    public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await repositories.Categories.GetByIDAsync(request.Id);
        if(category == null) throw new KeyNotFoundException("Category Not Found");
        category.Name = request.Name;
        if(! await repositories.SaveChangesAsync()) throw new Exception("Could not save data");
        return Unit.Value;
    }
}
