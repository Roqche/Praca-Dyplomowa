using System;

namespace RCP.DB.Model
{
	public class ProgrammerWorkingTime
	{
		public long Id { get; set; }

		public string Login { get; set; }

		public double Time { get; set; }

		public DateTime Date { get; set; }

		public string ProjectName { get; set; }
	}
}
