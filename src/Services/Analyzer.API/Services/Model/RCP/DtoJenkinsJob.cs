using System;

namespace Analyzer.API.Services.Model.RCP
{
	public class DtoJenkinsJob
	{
		public string JobName { get; set; }

		public int BuildNumber { get; set; }

		public string Culprit { get; set; }

		public DateTime BuildTime { get; set; }

		public int Duration { get; set; }

		public string Result { get; set; }

		public int EstimatedDuration { get; set; }

		public string Branch { get; set; }

		public string ProjectName { get; set; }
	}
}
