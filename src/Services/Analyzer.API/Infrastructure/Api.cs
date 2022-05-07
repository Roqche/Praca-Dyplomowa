using System;

namespace Analyzer.API.Infrastructure
{
	public static class Api
	{
		public static class AnalyzerDB
		{
			public static string GetSpecialMoments(string baseUrl) => $"{baseUrl}/{nameof(GetSpecialMoments)}";

			public static string SavePipelinesExecutions(string baseUrl) => $"{baseUrl}/{nameof(SavePipelinesExecutions)}";

			public static string SaveProgrammers(string baseUrl) => $"{baseUrl}/{nameof(SaveProgrammers)}";

			public static string SaveProgrammersWorkingTimes(string baseUrl) => $"{baseUrl}/{nameof(SaveProgrammersWorkingTimes)}";

			public static string GetPipelineExecutions(string baseUrl) => $"{baseUrl}/{nameof(GetPipelineExecutions)}";

			public static string GetProjectPipelineExecutions(string baseUrl, int projectId) => $"{baseUrl}/{nameof(GetProjectPipelineExecutions)}/{projectId}";

			public static string GetProjectContexts(string baseUrl) => $"{baseUrl}/{nameof(GetProjectContexts)}";

			public static string GetProgrammers(string baseUrl) => $"{baseUrl}/{nameof(GetProgrammers)}";

			public static string GetProgrammersWorkingTimes(string baseUrl) => $"{baseUrl}/{nameof(GetProgrammersWorkingTimes)}";
		}

		public static class Rcp
		{
			public static string GetAllProgrammers(string baseUrl) => $"{baseUrl}/{nameof(GetAllProgrammers)}";

			public static string GetJenkinsJobs(string baseUrl) => $"{baseUrl}/GetAllJenkinsJobs";

			public static string GetProgrammersWorkingTimes(string baseUrl) => $"{baseUrl}/{nameof(GetProgrammersWorkingTimes)}";
		}
	}
}
