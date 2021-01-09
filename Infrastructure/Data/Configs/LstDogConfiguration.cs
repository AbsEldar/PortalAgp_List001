using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configs
{
    public class LstDogConfiguration : IEntityTypeConfiguration<LstDog>
    {
        public void Configure(EntityTypeBuilder<LstDog> builder)
        {
            builder.Property(x => x.DogAuthor).IsRequired().HasMaxLength(100);
            builder.Property(x => x.LstTypeClass).IsRequired();
            builder.Property(x => x.LstTypeItem).IsRequired();
        }
    }
}