using AutoMapper;
using Ditto.Application.Mediat.Category.Models;
using Ditto.Application.Mediat.Category.Queries;
using Ditto.Common.Exceptions;
using Ditto.Common.Repositories;
using MediatR;

namespace Ditto.Application.Mediat.Category.Handlers;

public class CategoryByIdQueryHandler : IRequestHandler<CategoryByIdQuery, CategoryModel>
{
    private readonly IUnitOfWork repositories;
    private readonly IMapper mapper;

    public CategoryByIdQueryHandler(IUnitOfWork repositories, IMapper mapper)
    {
        this.repositories = repositories;
        this.mapper = mapper;
    }
    public async Task<CategoryModel> Handle(CategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await repositories.Categories.GetByIDAsync(request.Id);
        if(category == null) throw new BusinessException("Categoria no encontrada");
        return mapper.Map<CategoryModel>(category);
    }
}
