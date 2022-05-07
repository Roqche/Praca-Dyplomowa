using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RCP.DB.Model;

namespace RCP.DB.Infrastructure.EntityConfigurations
{
	public class ProjectEntityTypeConfiguration : IEntityTypeConfiguration<Project>
	{
		public void Configure(EntityTypeBuilder<Project> builder)
		{
			builder.ToTable(nameof(Project));

			builder.HasKey(b => b.Id);

			builder.Property(b => b.Id)
				.UseHiLo("project_hilo")
				.IsRequired();

			builder.Property(b => b.Name)
				.IsRequired();
		}
	}
}
