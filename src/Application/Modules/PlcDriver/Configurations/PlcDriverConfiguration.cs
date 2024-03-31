using Domain.Modules.PlcDriver.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Modules.PlcDriver.Configurations;

public class PlcDriverConfiguration : IEntityTypeConfiguration<PlcDriverModel>
{
    public void Configure(EntityTypeBuilder<PlcDriverModel> builder)
    {
        builder
          .HasOne(b => b.PlcDriverGroup)
          .WithMany(a => a.PlcDriver)
          .IsRequired()
          .OnDelete(DeleteBehavior.Cascade);
    }
}
