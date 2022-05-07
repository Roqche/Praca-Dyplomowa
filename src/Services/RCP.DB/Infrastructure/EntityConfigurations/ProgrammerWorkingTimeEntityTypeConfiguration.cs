using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RCP.DB.Model;

namespace RCP.DB.Infrastructure.EntityConfigurations
{
	public class ProgrammerWorkingTimeEntityTypeConfiguration : IEntityTypeConfiguration<ProgrammerWorkingTime>
	{
		public void Configure(EntityTypeBuilder<ProgrammerWorkingTime> builder)
		{
			builder.ToTable(nameof(ProgrammerWorkingTime));

			builder.HasKey(b => b.Id);

			builder.Property(b => b.Id)
				.UseHiLo("programmer_working_time_hilo")
				.IsRequired();

			builder.Property(b => b.Date)
				.HasColumnType("date");

			builder.Property(b => b.Login)
				.IsRequired();

			builder.Property(b => b.ProjectName)
				.IsRequired();
		}
	}
}
