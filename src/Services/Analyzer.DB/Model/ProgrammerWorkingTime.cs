using System;

namespace Analyzer.DB.Model
{
	public class ProgrammerWorkingTime
	{
		public long Id { get; set; }

		public int ProjectId { get; set; }

		public int ProgrammerId { get; set; }

		public double Time { get; set; }

		public DateTime Date { get; set; }


		public Project Project { get; set; }

		public Programmer Programmer { get; set; }
	}
}
