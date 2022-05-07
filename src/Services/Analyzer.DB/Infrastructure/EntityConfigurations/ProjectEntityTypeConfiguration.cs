using Analyzer.DB.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Analyzer.DB.Infrastructure.EntityConfigurations
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

			builder.Property(b => b.ProjectName)
				.IsRequired();
		}
	}
}
