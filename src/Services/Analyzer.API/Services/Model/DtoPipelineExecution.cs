using System;

namespace Analyzer.API.Services.Model
{
	public class DtoPipelineExecution
	{
		public int ContextId { get; set; }

		public int ProgrammerId { get; set; }

		public int ProjectId { get; set; }

		public string Result { get; set; }

		public int ExecutionNumber { get; set; }

		public DateTime StartTime { get; set; }

		public int Duration { get; set; }
	}
}
