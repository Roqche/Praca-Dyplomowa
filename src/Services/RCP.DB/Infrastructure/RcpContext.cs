using Microsoft.EntityFrameworkCore;
using Miscellaneous.Repository;
using RCP.DB.Infrastructure.EntityConfigurations;
using RCP.DB.Model;

namespace RCP.DB.Infrastructure
{
	public class RcpContext : DbContext, IUnitOfWork
	{
		public RcpContext(DbContextOptions<RcpContext> options) : base(options)
		{
		}

		public DbSet<JenkinsJob> JenkinsJobs { get; set; }
		public DbSet<ProgrammerWorkingTime> ProgrammersWorkingTime { get; set; }
		public DbSet<Project> Projects { get; set; }
		public DbSet<Programmer> Programmers { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder
				.ApplyConfiguration(new ProjectEntityTypeConfiguration())
				.ApplyConfiguration(new JenkinsJobEntityTypeConfiguration())
				.ApplyConfiguration(new ProgrammerWorkingTimeEntityTypeConfiguration())
				.ApplyConfiguration(new ProgrammerEntityTypeConfiguration());
		}
	}
}
