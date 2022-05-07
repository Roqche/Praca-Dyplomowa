using System;

namespace Analyzer.API.Services.Model
{
	public class DtoSaveProgrammerWorkingTime
	{
		public string Login { get; set; }

		public double Time { get; set; }

		public DateTime Date { get; set; }

		public string ProjectName { get; set; }
	}
}
