using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestMS.API.Controllers;

namespace TestMS.Domain.Context
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<RefUser>
    {
        public void Configure(EntityTypeBuilder<RefUser> builder)
        {
            builder.ToTable("ref_user");
            builder.Property(e => e.UserId).HasColumnName("user_id");
            builder.Property(e => e.UserName).IsRequired().HasMaxLength(50).HasColumnName("user_name");
            builder.Property(e => e.Password).IsRequired().HasMaxLength(500).HasColumnName("password");
            builder.Property(e => e.EmailId).IsRequired().HasMaxLength(500).HasColumnName("email_id");
            builder.Property(e => e.Country).IsRequired().HasColumnName("country");
        }
    }
}