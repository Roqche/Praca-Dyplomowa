using Analyzer.DB.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Analyzer.DB.Infrastructure.EntityConfigurations
{
	public class ProgrammerWorkingTimeEntityTypeConfiguration : IEntityTypeConfiguration<ProgrammerWorkingTime>
	{
		public void Configure(EntityTypeBuilder<ProgrammerWorkingTime> builder)
		{
			builder.ToTable(nameof(ProgrammerWorkingTime));

			builder.HasKey(x => x.Id);

			builder.Property(b => b.Id)
				.UseIdentityColumn()
				.IsRequired();

			builder.HasOne(b => b.Project)
				.WithMany(b => b.ProgrammerWorkingTimes)
				.HasForeignKey(b => b.ProjectId)
				.OnDelete(DeleteBehavior.NoAction)
				.IsRequired();

			builder.HasOne(b => b.Programmer)
				.WithMany(b => b.ProgrammerWorkingTimes)
				.HasForeignKey(b => b.ProgrammerId)
				.OnDelete(DeleteBehavior.NoAction)
				.IsRequired();

			builder.Property(b => b.Date)
				.HasColumnType("date");
		}
	}
}
