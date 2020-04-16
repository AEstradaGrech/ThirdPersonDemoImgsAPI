using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThirdPersonDemoIMGsDomain.Entities;

namespace ThirdPersonDemoIMGsInfrasturcture.Context.EntityTypeConfigurations
{
    public class ImageEntityTypeConfiguration : IEntityTypeConfiguration<Image>
    {       
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(i => i.Id);

            builder.HasIndex(i => i.ImgName)
                   .IsUnique();

            builder.Property(i => i.ImgBytes)
                   .IsRequired();

            builder.Property(i => i.ImgName)
                   .HasColumnName("Name")
                   .HasMaxLength(20)
                   .IsRequired();

            builder.Property(i => i.CreationDate)
                   .HasDefaultValue(DateTime.Now)
                   .IsRequired();
        }
    }
}
