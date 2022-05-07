using System.Collections.Generic;

namespace Analyzer.DB.Model
{
	public class Project
	{
		public int Id { get; set; }

		public string ProjectName { get; set; }


		public List<Programmer> Programmers { get; set; }

		public List<PipelineContext> PipelineContexts { get; set; }

		public List<PipelineExecution> PipelinesExecutions { get; set; }

		public List<SkippedLogin> SkippedLogins { get; set; }

		public List<ProgrammerWorkingTime> ProgrammerWorkingTimes { get; set; }
	}
}
