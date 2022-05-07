using System;

namespace Analyzer.DB.Model
{
	public class DtoSaveProgrammerWorkingTime
	{
		public string Login { get; set; }

		public double Time { get; set; }

		public DateTime Date { get; set; }

		public string ProjectName { get; set; }
	}
}
