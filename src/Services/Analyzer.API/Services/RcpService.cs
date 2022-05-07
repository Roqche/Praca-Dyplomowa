using Analyzer.API.Services.Model;
using Analyzer.API.Services.Model.RCP;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Analyzer.API.Services
{
	public class RcpService : IRcpService
	{
		private readonly HttpClient httpClient;
		private readonly string remoteServiceBaseUrl;

		public RcpService(HttpClient httpClient, IOptions<AppSettings> settings)
		{
			this.httpClient = httpClient;

			remoteServiceBaseUrl = $"{settings.Value.RCPDBUrl}/api/v1/RCP";
		}

		public async Task<List<DtoProgrammer>> GetAllProgrammers()
		{
			var uri = Infrastructure.Api.Rcp.GetAllProgrammers(remoteServiceBaseUrl);

			var responseString = await httpClient.GetStringAsync(uri);

			var response = JsonSerializer.Deserialize<List<DtoProgrammer>>(responseString, new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			});

			return response;
		}

		public async Task<List<DtoJenkinsJob>> GetJenkinsJobs()
		{
			var uri = Infrastructure.Api.Rcp.GetJenkinsJobs(remoteServiceBaseUrl);

			var responseString = await httpClient.GetStringAsync(uri);

			var response = JsonSerializer.Deserialize<List<DtoJenkinsJob>>(responseString, new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			});

			return response;
		}

		public async Task<List<DtoSaveProgrammerWorkingTime>> GetProgrammersWorkingTimes()
		{
			var uri = Infrastructure.Api.Rcp.GetProgrammersWorkingTimes(remoteServiceBaseUrl);

			var responseString = await httpClient.GetStringAsync(uri);

			var response = JsonSerializer.Deserialize<List<DtoSaveProgrammerWorkingTime>>(responseString, new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			});

			return response;
		}
	}
}
