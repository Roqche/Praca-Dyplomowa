namespace Analyzer.DB.Model
{
	public class ConnectorUsedInProject
	{
		public int Id { get; set; }

		public ConnectorType Connector { get; set; }


		public int ProjectId { get; set; }

		public Project Project { get; set; }
	}
}
