using AutoMapper;
using Ditto.Application.Mediat.Category.Models;
using Ditto.Application.Mediat.Category.Queries;
using Ditto.Common.Repositories;
using MediatR;

namespace Ditto.Application.Mediat.Category.Handlers;

public class CategoryListQueryHandler : IRequestHandler<CategoriesQuery, List<CategoryModel>>
{
    private readonly IUnitOfWork repositories;
    private readonly IMapper mapper;

    public CategoryListQueryHandler(IUnitOfWork repositories, IMapper mapper)
    {
        this.repositories = repositories;
        this.mapper = mapper;
    }
    public async Task<List<CategoryModel>> Handle(CategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await repositories.Categories.GetAsync();
        return mapper.Map<List<CategoryModel>>(categories);
    }
}
