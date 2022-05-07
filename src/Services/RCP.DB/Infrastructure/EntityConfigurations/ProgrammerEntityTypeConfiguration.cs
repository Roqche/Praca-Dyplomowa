using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RCP.DB.Model;

namespace RCP.DB.Infrastructure.EntityConfigurations
{
	public class ProgrammerEntityTypeConfiguration : IEntityTypeConfiguration<Programmer>
	{
		public void Configure(EntityTypeBuilder<Programmer> builder)
		{
			builder.ToTable(nameof(Programmer));

			builder.HasKey(b => b.Id);

			builder.Property(b => b.Id)
				.UseIdentityColumn()
				.IsRequired();

			builder.Property(b => b.Login)
				.IsRequired();

			builder.HasOne(b => b.Project)
				.WithMany(b => b.Programmers)
				.HasForeignKey(b => b.ProjectId)
				.IsRequired();
		}
	}
}
