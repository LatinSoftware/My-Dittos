using AutoMapper;
using Ditto.Application.Mediat.Category.Commands;
using Ditto.Common.Repositories;
using category = Ditto.Common.Domain.Category;
using MediatR;

namespace Ditto.Application.Mediat.Category.Handlers;

public class InsertCategoryCommandHandler : IRequestHandler<InsertCategoryCommand, int>
{
    private readonly IUnitOfWork repositories;
    private readonly IMapper mapper;

    public InsertCategoryCommandHandler(IUnitOfWork repositories, IMapper mapper)
    {
        this.repositories = repositories;
        this.mapper = mapper;
    }
    public async Task<int> Handle(InsertCategoryCommand request, CancellationToken cancellationToken)
    {
        var categories = await repositories.Categories.GetAsync(filter: f => f.Name.ToLower().Contains(request.Name.ToLower()));
        if(categories.Any()) throw new Exception("Category already exist");
        var category = mapper.Map<category>(request);
        await repositories.Categories.InsertAsync(category);
        if(! await repositories.SaveChangesAsync()) throw new Exception("Could not save data");
        return category.Id;
    }
}