using Analyzer.DB.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Analyzer.DB.Infrastructure.EntityConfigurations
{
	public class SkippedLoginEntityTypeConfiguration : IEntityTypeConfiguration<SkippedLogin>
	{
		public void Configure(EntityTypeBuilder<SkippedLogin> builder)
		{
			builder.ToTable(nameof(SkippedLogin));

			builder.HasKey(x => x.Id);

			builder.Property(x => x.Id)
				.UseIdentityColumn()
				.IsRequired();

			builder.Property(x => x.Login)
				.IsRequired();

			builder.HasOne(x => x.Project)
				.WithMany(x => x.SkippedLogins)
				.HasForeignKey(x => x.ProjectId)
				.IsRequired();
		}
	}
}
