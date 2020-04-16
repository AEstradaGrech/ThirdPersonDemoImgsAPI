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

            builder.Property(i => i.ImgBytes)
                   .IsRequired();
        }
    }
}
