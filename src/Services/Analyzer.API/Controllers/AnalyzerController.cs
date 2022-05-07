using Analyzer.API.Mapper;
using Analyzer.API.Services;
using Analyzer.API.Services.Model;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Analyzer.API.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class AnalyzerController : ControllerBase
	{
		private readonly IAnalyzerService analyzerService;
		private readonly IRcpService RCPService;

		public AnalyzerController(IAnalyzerService analyzerService, IRcpService RCPService)
		{
			this.analyzerService = analyzerService;
			this.RCPService = RCPService;
		}

		[HttpPost]
		[Route(nameof(ProcessData))]
		public async Task<IActionResult> ProcessData()
		{
			var programmers = await RCPService.GetAllProgrammers();

			await analyzerService.SaveProgrammers(programmers);

			var programmersWorkingTimes = await RCPService.GetProgrammersWorkingTimes();

			await analyzerService.SaveProgrammersWorkingTimes(programmersWorkingTimes);

			var jenkinsJobs = await RCPService.GetJenkinsJobs();

			var pipelinesExecutions = jenkinsJobs.Select(j => j.ToSavePipelineExectuionDto()).ToList();

			await analyzerService.SavePipelinesExecutions(pipelinesExecutions);

			return Ok();
		}

		[HttpGet]
		[Route(nameof(GetProjectContexts))]
		public async Task<IActionResult> GetProjectContexts(int projectId)
		{
			var contexts = await analyzerService.GetProjectContexts(projectId);

			return Ok(contexts);
		}

		[HttpPost]
		[Route(nameof(PostSpecialMoments))]
		public async Task<IActionResult> PostSpecialMoments(DtoPipelineContext specialMomentContext)
		{
			var specialMoments = await analyzerService.GetSpecialMoments(specialMomentContext);
			return Ok(specialMoments);
		}

		[HttpGet]
		[Route(nameof(GetSpecialMoments))]
		public async Task<IActionResult> GetSpecialMoments(int projectId, string context)
		{
			var pipelineContext = new DtoPipelineContext { ProjectId = projectId, Context = context };
			return await PostSpecialMoments(pipelineContext);
		}

		[HttpPost]
		[Route(nameof(PostPipelineExecutions))]
		public async Task<IActionResult> PostPipelineExecutions(DtoPipelineContext pipelineContext)
		{
			var pipelineExecutions = await analyzerService.GetPipelineExecutions(pipelineContext);

			return Ok(pipelineExecutions);
		}

		[HttpGet]
		[Route(nameof(GetPipelineExecutions))]
		public async Task<IActionResult> GetPipelineExecutions(int projectId, string context)
		{
			var pipelineContext = new DtoPipelineContext { ProjectId = projectId, Context = context };

			return await PostPipelineExecutions(pipelineContext);
		}

		[HttpGet]
		[Route(nameof(GetProgrammers))]
		public async Task<IActionResult> GetProgrammers(int projectId)
		{
			var programmers = await analyzerService.GetProgrammers(projectId);

			return Ok(programmers);
		}

		[HttpGet]
		[Route(nameof(GetProgrammersWorkingTimes))]
		public async Task<IActionResult> GetProgrammersWorkingTimes(int projectId)
		{
			var programmersWorkingTimes = await analyzerService.GetProgrammersWorkingTimes(projectId);

			return Ok(programmersWorkingTimes);
		}
	}
}
