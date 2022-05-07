using System.Collections.Generic;

namespace RCP.DB.Model
{
	public class Programmer
	{
		public int Id { get; set; }

		public string Login { get; set; }

		public string FullName { get; set; }

		public string JobTitle { get; set; }

		public string Email { get; set; }


		public int ProjectId { get; set; }

		public Project Project { get; set; }
	}
}
