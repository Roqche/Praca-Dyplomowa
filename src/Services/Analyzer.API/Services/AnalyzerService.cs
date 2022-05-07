using Analyzer.API.Services.Model;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Analyzer.API.Services
{
	public class AnalyzerService : IAnalyzerService
	{
		private readonly HttpClient httpClient;
		private readonly string remoteServiceBaseUrl;

		public AnalyzerService(HttpClient httpClient, IOptions<AppSettings> settings)
		{
			this.httpClient = httpClient;

			remoteServiceBaseUrl = $"{settings.Value.AnalyzerDBUrl}/api/v1/Analyzer";
		}

		public async Task<List<DtoSpecialMoment>> GetSpecialMoments(DtoPipelineContext specialMomentContext)
		{
			var uri = Infrastructure.Api.AnalyzerDB.GetSpecialMoments(remoteServiceBaseUrl);

			var requestContent = CreateRequestContent(specialMomentContext);

			var response = await httpClient.PostAsync(uri, requestContent);

			var str = await response.Content.ReadAsStringAsync();

			var specialMoments = JsonSerializer.Deserialize<List<DtoSpecialMoment>>(str, new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			});

			return specialMoments;
		}

		public async Task SavePipelinesExecutions(List<DtoSavePipelineExecution> pipelinesExecutions)
		{
			var uri = Infrastructure.Api.AnalyzerDB.SavePipelinesExecutions(remoteServiceBaseUrl);

			var requestContent = CreateRequestContent(pipelinesExecutions);

			await httpClient.PostAsync(uri, requestContent);
		}

		public async Task SaveProgrammers(List<DtoProgrammer> programmers)
		{
			var uri = Infrastructure.Api.AnalyzerDB.SaveProgrammers(remoteServiceBaseUrl);

			var requestContent = CreateRequestContent(programmers);

			await httpClient.PostAsync(uri, requestContent);
		}

		public async Task SaveProgrammersWorkingTimes(List<DtoSaveProgrammerWorkingTime> programmersWorkingTimes)
		{
			var uri = Infrastructure.Api.AnalyzerDB.SaveProgrammersWorkingTimes(remoteServiceBaseUrl);

			var requestContent = CreateRequestContent(programmersWorkingTimes);

			await httpClient.PostAsync(uri, requestContent);
		}

		public async Task<List<DtoPipelineExecution>> GetPipelineExecutions(DtoPipelineContext pipelineContext)
		{
			var uri = Infrastructure.Api.AnalyzerDB.GetPipelineExecutions(remoteServiceBaseUrl);

			var requestContent = CreateRequestContent(pipelineContext);

			var response = await httpClient.PostAsync(uri, requestContent);

			var str = await response.Content.ReadAsStringAsync();

			var pipelineExecutions = JsonSerializer.Deserialize<List<DtoPipelineExecution>>(str, new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			});

			return pipelineExecutions;
		}

		public async Task<List<DtoPipelineExecution>> GetProjectPipelineExecutions(int projectId)
		{
			var uri = Infrastructure.Api.AnalyzerDB.GetProjectPipelineExecutions(remoteServiceBaseUrl, projectId);

			var response = await httpClient.GetAsync(uri);

			var str = await response.Content.ReadAsStringAsync();

			var pipelineExecutions = JsonSerializer.Deserialize<List<DtoPipelineExecution>>(str, new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			});

			return pipelineExecutions;
		}

		private static StringContent CreateRequestContent(object o)
		{
			return new StringContent(JsonSerializer.Serialize(o), Encoding.UTF8, "application/json");
		}

		public async Task<List<DtoPipelineContext>> GetProjectContexts(int projectId)
		{
			var uri = Infrastructure.Api.AnalyzerDB.GetProjectContexts(remoteServiceBaseUrl);

			var requestContent = CreateRequestContent(projectId);

			var response = await httpClient.PostAsync(uri, requestContent);

			var str = await response.Content.ReadAsStringAsync();

			var contexts = JsonSerializer.Deserialize<List<DtoPipelineContext>>(str, new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			});

			return contexts;
		}

		public async Task<List<DtoProgrammer>> GetProgrammers(int projectId)
		{
			var uri = Infrastructure.Api.AnalyzerDB.GetProgrammers(remoteServiceBaseUrl);

			var requestContent = CreateRequestContent(projectId);

			var response = await httpClient.PostAsync(uri, requestContent);

			var str = await response.Content.ReadAsStringAsync();

			var programmers = JsonSerializer.Deserialize<List<DtoProgrammer>>(str, new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			});

			return programmers;
		}

		public async Task<List<DtoProgrammerWorkingTime>> GetProgrammersWorkingTimes(int projectId)
		{
			var uri = Infrastructure.Api.AnalyzerDB.GetProgrammersWorkingTimes(remoteServiceBaseUrl);

			var requestContent = CreateRequestContent(projectId);

			var response = await httpClient.PostAsync(uri, requestContent);

			var str = await response.Content.ReadAsStringAsync();

			var programmers = JsonSerializer.Deserialize<List<DtoProgrammerWorkingTime>>(str, new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			});

			return programmers;
		}
	}
}
