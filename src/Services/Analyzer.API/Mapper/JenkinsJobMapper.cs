using Analyzer.API.Services.Model;
using Analyzer.API.Services.Model.RCP;

namespace Analyzer.API.Mapper
{
	public static class JenkinsJobMapper
	{
		public static DtoSavePipelineExecution ToSavePipelineExectuionDto(this DtoJenkinsJob jenkinsJob)
		{
			return new DtoSavePipelineExecution()
			{
				Context = jenkinsJob.JobName,
				Duration = jenkinsJob.Duration,
				ExecutionNUmber = jenkinsJob.BuildNumber,
				ProgrammerLogin = jenkinsJob.Culprit,
				ProjectName = jenkinsJob.ProjectName,
				Result = jenkinsJob.Result,
				StartTime = jenkinsJob.BuildTime
			};
		}
	}
}
