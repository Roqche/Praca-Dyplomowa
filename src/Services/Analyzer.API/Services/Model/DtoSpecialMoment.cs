using System;

namespace Analyzer.API.Services.Model
{
	public class DtoSpecialMoment
	{
		public int ProjectId { get; set; }

		public int ContextId { get; set; }

		public string Name { get; set; }

		public DateTime Appeared { get; set; }
	}
}
