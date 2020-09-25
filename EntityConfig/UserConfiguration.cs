using Edu.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edu.EntityConfig
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Usuarios", schema: "dbo");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.HasAlternateKey(x => x.UserName);
            builder.Property(x => x.IsActive)
                .HasDefaultValue(true);
            builder.HasMany(x => x.Roles)
                .WithOne(x => x.User);
        }
    }
}
