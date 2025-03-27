using Ambev.DeveloperEvaluation.Application.Handlers.Cart.CreateCart;
using Ambev.DeveloperEvaluation.Application.Handlers.StoreBranch.CreateStoreBranch;
using Ambev.DeveloperEvaluation.Application.Handlers.StoreBranch.UpdateStoreBranch;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Models;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Mappers
{
    public class Mappers : Profile
    {
        public Mappers()
        {
            CreateMap<Product, ProductModel>().ReverseMap();
            
            CreateMap<CreateStoreBranchCommand, StoreBranch>().ReverseMap();
            CreateMap<UpdateStoreBranchCommand, StoreBranch>().ReverseMap();
            CreateMap<StoreBranchModel, StoreBranch>().ReverseMap();
            
            CreateMap<CreateCartCommand, Cart>().ReverseMap();
            CreateMap<OrderModel, Order>().ReverseMap();

        }
    }
}
