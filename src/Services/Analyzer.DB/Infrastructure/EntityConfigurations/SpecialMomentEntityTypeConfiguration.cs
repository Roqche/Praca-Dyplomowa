using Analyzer.DB.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Analyzer.DB.Infrastructure.EntityConfigurations
{
	public class SpecialMomentEntityTypeConfiguration : IEntityTypeConfiguration<SpecialMoment>
	{
		public void Configure(EntityTypeBuilder<SpecialMoment> builder)
		{
			builder.ToTable(nameof(SpecialMoment));

			builder.HasKey(b => b.Id);

			builder.Property(b => b.Id)
				.UseHiLo("project_hilo")
				.IsRequired();

			builder.Property(b => b.Name)
				.IsRequired();

			builder.HasOne(b => b.Context)
				.WithMany(b => b.SpecialMoments)
				.HasForeignKey(b => b.ContextId)
				.IsRequired()
				.OnDelete(DeleteBehavior.NoAction);

			builder.HasOne(b => b.Project)
				.WithMany()
				.HasForeignKey(b => b.ProjectId)
				.IsRequired()
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
