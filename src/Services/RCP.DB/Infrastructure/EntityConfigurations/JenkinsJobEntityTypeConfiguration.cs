using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RCP.DB.Model;

namespace RCP.DB.Infrastructure.EntityConfigurations
{
	public class JenkinsJobEntityTypeConfiguration : IEntityTypeConfiguration<JenkinsJob>
	{
		public void Configure(EntityTypeBuilder<JenkinsJob> builder)
		{
			builder.ToTable(nameof(JenkinsJob));

			builder.HasKey(b => b.Id);

			builder.Property(b => b.Id)
				.UseHiLo("jenkins_job_hilo")
				.IsRequired();

			builder.Property(b => b.JobName)
				.IsRequired();

			builder.Property(b => b.Culprit)
				.IsRequired();

			builder.Property(b => b.Result)
				.IsRequired();
		}
	}
}
