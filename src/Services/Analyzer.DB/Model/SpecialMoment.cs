using System;

namespace Analyzer.DB.Model
{
	public class SpecialMoment
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public DateTime Appeared { get; set; }


		public int ProjectId { get; set; }

		public int ContextId { get; set; }

		public Project Project { get; set; }

		public PipelineContext Context { get; set; }
	}
}
