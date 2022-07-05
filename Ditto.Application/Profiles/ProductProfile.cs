using AutoMapper;
using Ditto.Application.Mediat.Product.Commands;
using Ditto.Application.Mediat.Product.Models;
using Ditto.Common.Domain;

namespace Ditto.Application.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductModel>();
        CreateMap<InsertProductCommand, Product>();
        CreateMap<UpdateProductCommand, Product>();
    }
}
