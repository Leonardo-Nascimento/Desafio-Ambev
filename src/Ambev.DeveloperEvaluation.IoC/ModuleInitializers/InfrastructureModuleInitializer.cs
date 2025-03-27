using Ambev.DeveloperEvaluation.Application.Handlers.Product.GetProductById;
using Ambev.DeveloperEvaluation.Application.Mappers;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.ORM;
using Ambev.DeveloperEvaluation.ORM.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ambev.DeveloperEvaluation.IoC.ModuleInitializers;

public class InfrastructureModuleInitializer : IModuleInitializer
{
    public void Initialize(WebApplicationBuilder builder)
    {
        var connection = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<DefaultContext>(options => options.UseSqlServer(connection));


        builder.Services.AddScoped<DbContext>(provider => provider.GetRequiredService<DefaultContext>());
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
        builder.Services.AddScoped<IStoreBranchRepository, StoreBranchRepository>();
        builder.Services.AddScoped<ICartRepository, CartRepository>();
        builder.Services.AddScoped<IOrderRepository, OrderRepository>();
        



        //validators
        builder.Services.AddValidatorsFromAssemblyContaining<GetProductByIdValidator>();

        //Mappers
        builder.Services.AddAutoMapper(typeof(Mappers));
    }
}