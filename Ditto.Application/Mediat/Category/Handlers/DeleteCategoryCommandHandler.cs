using AutoMapper;
using Ditto.Application.Mediat.Category.Commands;
using Ditto.Common.Repositories;
using MediatR;

namespace Ditto.Application.Mediat.Category.Handlers;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
{
    private readonly IUnitOfWork repositories;
    private readonly IMapper mapper;

    public DeleteCategoryCommandHandler(IUnitOfWork repositories, IMapper mapper)
    {
        this.repositories = repositories;
        this.mapper = mapper;
    }
    public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await repositories.Categories.GetByIDAsync(request.Id);
        if(category == null) throw new Exception("Categoria no encontrada");
        repositories.Categories.Delete(category);
        return Unit.Value;
    }
}
