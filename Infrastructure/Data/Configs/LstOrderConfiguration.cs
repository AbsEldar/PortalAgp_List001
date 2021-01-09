using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configs
{
    public class LstOrderConfiguration : IEntityTypeConfiguration<LstOrder>
    {
        public void Configure(EntityTypeBuilder<LstOrder> builder)
        {
            builder.Property(x => x.OrderCode).IsRequired().HasMaxLength(100);
            builder.Property(x => x.LstTypeClass).IsRequired();
            builder.Property(x => x.LstTypeItem).IsRequired();
        }
    }
}