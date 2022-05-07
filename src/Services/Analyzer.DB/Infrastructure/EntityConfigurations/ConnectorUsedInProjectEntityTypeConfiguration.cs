using Analyzer.DB.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Analyzer.DB.Infrastructure.EntityConfigurations
{
	public class ConnectorUsedInProjectEntityTypeConfiguration : IEntityTypeConfiguration<ConnectorUsedInProject>
	{
		public void Configure(EntityTypeBuilder<ConnectorUsedInProject> builder)
		{
			builder.ToTable(nameof(ConnectorUsedInProject));

			builder.HasKey(b => b.Id);

			builder.HasOne(b => b.Project)
				.WithMany()
				.HasForeignKey(b => b.ProjectId);

			builder.Property(b => b.Id)
				.UseHiLo("connector_used_in_project_hilo")
				.IsRequired();

			builder.Property(b => b.Connector)
				.IsRequired();
		}
	}
}
