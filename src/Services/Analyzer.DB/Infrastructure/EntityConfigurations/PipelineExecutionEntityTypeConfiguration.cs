using Analyzer.DB.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Analyzer.DB.Infrastructure.EntityConfigurations
{
	public class PipelineExecutionEntityTypeConfiguration : IEntityTypeConfiguration<PipelineExecution>
	{
		public void Configure(EntityTypeBuilder<PipelineExecution> builder)
		{
			builder.ToTable(nameof(PipelineExecution));

			builder.HasKey(x => x.Id);

			builder.Property(b => b.Id)
				.UseIdentityColumn()
				.IsRequired();

			builder.HasOne(b => b.Context)
				.WithMany(b => b.PipelinesExecutions)
				.HasForeignKey(b => b.ContextId)
				.IsRequired();

			builder.HasOne(b => b.Programmer)
				.WithMany(b => b.PipelinesExecutions)
				.HasForeignKey(b => b.ProgrammerId)
				.OnDelete(DeleteBehavior.NoAction)
				.IsRequired();

			builder.HasOne(b => b.Project)
				.WithMany(b => b.PipelinesExecutions)
				.HasForeignKey(b => b.ProjectId)
				.OnDelete(DeleteBehavior.NoAction)
				.IsRequired();

			builder.Property(b => b.Result)
				.IsRequired();
		}
	}
}
