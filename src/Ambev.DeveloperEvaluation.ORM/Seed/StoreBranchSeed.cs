using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Seed
{
    public class StoreBranchSeed : IEntityTypeConfiguration<StoreBranch>
    {


        public void Configure(EntityTypeBuilder<StoreBranch> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasData(

                   new StoreBranch(1, "Carrefour", 1001, "60731455", "São Paulo", "Campinas"),
                   new StoreBranch(2, "Extra", 1234, "45678456", "Ceará", "Fortaleza")

            );
        }
    }
}
