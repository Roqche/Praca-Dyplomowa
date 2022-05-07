using Analyzer.DB.Model;

namespace Analyzer.DB.Mapper
{
	public static class PipelineContextMapper
	{
		public static DtoPipelineContext ToDto(this PipelineContext context)
		{
			return new DtoPipelineContext()
			{
				ProjectId = context.ProjectId,
				Context = context.Context
			};
		}
	}
}
