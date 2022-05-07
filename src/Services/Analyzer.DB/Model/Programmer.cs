using System.Collections.Generic;

namespace Analyzer.DB.Model
{
	public class Programmer
	{
		public int Id { get; set; }

		public string Login { get; set; }

		public string FullName { get; set; }

		public string JobTitle { get; set; }

		public string Email { get; set; }


		public int ProjectId { get; set; }

		public Project Project { get; set; }


		public List<PipelineExecution> PipelinesExecutions { get; set; }

		public List<ProgrammerWorkingTime> ProgrammerWorkingTimes { get; set; }
	}
}