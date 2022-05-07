namespace Analyzer.DB.Model
{
	public class SkippedLogin
	{
		public int Id { get; set; }

		public string Login { get; set; }

		public int ProjectId { get; set; }

		public Project Project { get; set; }
	}
}
