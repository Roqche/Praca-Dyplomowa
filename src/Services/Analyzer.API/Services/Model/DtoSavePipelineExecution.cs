using System;

namespace Analyzer.API.Services.Model
{
	public class DtoSavePipelineExecution
	{
		public string Context { get; set; }

		public string ProgrammerLogin { get; set; }

		public string ProjectName { get; set; }

		public string Result { get; set; }

		public int ExecutionNUmber { get; set; }

		public DateTime StartTime { get; set; }

		public int Duration { get; set; }
	}
}
