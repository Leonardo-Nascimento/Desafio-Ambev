using Ambev.DeveloperEvaluation.Application.Handlers.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Models;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.CreateUser;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings;

public class CreateUserRequestProfile : Profile
{
    public CreateUserRequestProfile()
    {
        CreateMap<CreateUserRequest, CreateUserCommand>();
        CreateMap<Customer, CustomerModel>().ReverseMap();
    }
}