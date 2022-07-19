using AutoMapper;
using Ditto.Application.Mediat.Category.Commands;
using Ditto.Application.Mediat.Category.Models;
using Ditto.Common.Domain;

namespace Ditto.Application.Profiles;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CategoryModel>();
        CreateMap<InsertCategoryCommand, Category>();
    }
}
