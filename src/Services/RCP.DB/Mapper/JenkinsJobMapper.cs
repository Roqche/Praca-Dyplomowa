using RCP.DB.Model;

namespace RCP.DB.Mapper
{
	public static class JenkinsJobMapper
	{
		public static JenkinsJob FromDto(this DtoJenkinsJob dto)
		{
			return new JenkinsJob()
			{
				Branch = dto.Branch,
				BuildNumber = dto.BuildNumber,
				BuildTime = dto.BuildTime,
				Culprit = dto.Culprit,
				Duration = dto.Duration,
				EstimatedDuration = dto.EstimatedDuration,
				JobName = dto.JobName,
				ProjectName = dto.ProjectName,
				Result = dto.Result,
			};
		}

		public static DtoJenkinsJob ToDto(this JenkinsJob jenkinsJob)
		{
			return new DtoJenkinsJob()
			{
				Branch = jenkinsJob.Branch,
				BuildNumber = jenkinsJob.BuildNumber,
				BuildTime = jenkinsJob.BuildTime,
				Culprit = jenkinsJob.Culprit,
				Duration = jenkinsJob.Duration,
				EstimatedDuration = jenkinsJob.EstimatedDuration,
				JobName = jenkinsJob.JobName,
				ProjectName = jenkinsJob.ProjectName,
				Result = jenkinsJob.Result,
			};
		}
	}
}
