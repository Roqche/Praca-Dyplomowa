using Analyzer.DB.Infrastructure.EntityConfigurations;
using Analyzer.DB.Model;
using Microsoft.EntityFrameworkCore;
using Miscellaneous.Repository;

namespace Analyzer.DB.Infrastructure
{
	public class AnalyzerContext : DbContext, IUnitOfWork
	{
		public AnalyzerContext(DbContextOptions<AnalyzerContext> options) : base(options)
		{
		}

		public DbSet<Project> Project { get; set; }
		public DbSet<ConnectorUsedInProject> ConnectorsUsedInProjects { get; }
		public DbSet<SpecialMoment> SpecialMoments { get; set; }
		public DbSet<Programmer> Programmers { get; set; }
		public DbSet<SkippedLogin> SkippedLogins { get; set; }
		public DbSet<ProgrammerWorkingTime> ProgrammersWorkingTimes { get; set; }
		public DbSet<PipelineContext> PipelinesContexts { get; set; }
		public DbSet<PipelineExecution> PipelinesExecutions { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ProjectEntityTypeConfiguration())
				.ApplyConfiguration(new ConnectorUsedInProjectEntityTypeConfiguration())
				.ApplyConfiguration(new SpecialMomentEntityTypeConfiguration())
				.ApplyConfiguration(new ProgrammerEntityTypeConfiguration())
				.ApplyConfiguration(new PipelineContextEntityTypeConfiguration())
				.ApplyConfiguration(new PipelineExecutionEntityTypeConfiguration())
				.ApplyConfiguration(new SkippedLoginEntityTypeConfiguration())
				.ApplyConfiguration(new ProgrammerWorkingTimeEntityTypeConfiguration());
		}
	}
}
