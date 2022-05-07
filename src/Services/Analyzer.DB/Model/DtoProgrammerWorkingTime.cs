using System;

namespace Analyzer.DB.Model
{
	public class DtoProgrammerWorkingTime
	{
		public long Id { get; set; }

		public int ProgrammerId { get; set; }

		public int ProjectId { get; set; }

		public double Time { get; set; }

		public DateTime Date { get; set; }
	}
}
