using Analyzer.DB.Model;

namespace Analyzer.DB.Mapper
{
	public static class PipelineExecutionMapper
	{
		public static DtoPipelineExecution ToDto(this PipelineExecution specialMoment)
		{
			return new DtoPipelineExecution()
			{
				ContextId = specialMoment.ContextId,
				ProgrammerId = specialMoment.ProgrammerId,
				ProjectId = specialMoment.ProjectId,
				Result = specialMoment.Result,
				ExecutionNumber = specialMoment.ExecutionNumber,
				StartTime = specialMoment.StartTime,
				Duration = specialMoment.Duration,
			};
		}
	}
}
