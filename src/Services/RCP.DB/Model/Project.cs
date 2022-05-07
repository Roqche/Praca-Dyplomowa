using System.Collections.Generic;

namespace RCP.DB.Model
{
	public class Project
	{
		public int Id { get; set; }

		public string Name { get; set; }


		public List<Programmer> Programmers { get; set; }
	}
}
