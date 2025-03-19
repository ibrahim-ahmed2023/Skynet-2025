﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole { Id = "1B3A22E5-9C02-4F1F-88E2-08115B3E55A8", Name = "Admin", NormalizedName = "ADMIN" },
            new IdentityRole { Id = "3F57C81B-7E32-4A1E-B2A3-1234567890AB", Name = "Customer", NormalizedName = "CUSTOMER" }
        );
    }

}