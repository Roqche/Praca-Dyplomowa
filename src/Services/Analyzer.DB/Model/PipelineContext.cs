using System.Collections.Generic;

namespace Analyzer.DB.Model
{
	public class PipelineContext
	{
		public int Id { get; set; }

		public string Context { get; set; }


		public int ProjectId { get; set; }

		public Project Project { get; set; }

		public List<PipelineExecution> PipelinesExecutions { get; set; }

		public List<SpecialMoment> SpecialMoments { get; set; }
	}
}