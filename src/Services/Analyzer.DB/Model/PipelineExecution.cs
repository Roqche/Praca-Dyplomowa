using System;

namespace Analyzer.DB.Model
{
	public class PipelineExecution
	{
		public int Id { get; set; }

		public int ContextId { get; set; }

		public int ProgrammerId { get; set; }

		public int ProjectId { get; set; }

		public string Result { get; set; }

		public int ExecutionNumber { get; set; }

		public DateTime StartTime { get; set; }

		public int Duration { get; set; }


		public PipelineContext Context { get; set; }

		public Programmer Programmer { get; set; }

		public Project Project { get; set; }
	}
}
