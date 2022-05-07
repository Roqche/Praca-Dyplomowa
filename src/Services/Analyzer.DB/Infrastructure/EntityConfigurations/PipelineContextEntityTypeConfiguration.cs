using Analyzer.DB.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Analyzer.DB.Infrastructure.EntityConfigurations
{
	public class PipelineContextEntityTypeConfiguration : IEntityTypeConfiguration<PipelineContext>
	{
		public void Configure(EntityTypeBuilder<PipelineContext> builder)
		{
			builder.ToTable(nameof(PipelineContext));

			builder.HasKey(x => x.Id);

			builder.Property(b => b.Id)
				.UseIdentityColumn()
				.IsRequired();

			builder.Property(b => b.Context)
				.IsRequired();
		}
	}
}
