using Analyzer.DB.Mapper;
using Analyzer.DB.Model;
using Analyzer.DB.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Analyzer.DB.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class AnalyzerController : ControllerBase
	{
		private readonly IAnalyzerService analyzerRepository;

		public AnalyzerController(IAnalyzerService analyzerRepository)
		{
			this.analyzerRepository = analyzerRepository;
		}

		[HttpPost]
		[Route(nameof(InsertProject))]
		public async Task<IActionResult> InsertProject(DtoProject dto)
		{
			if (string.IsNullOrEmpty(dto?.ProjectName))
			{
				return BadRequest($"The property {nameof(dto.ProjectName)} can not be empty!");
			}

			var project = new Project()
			{
				ProjectName = dto.ProjectName
			};

			await analyzerRepository.InsertProject(project);

			return Ok();
		}

		[HttpPost]
		[Route(nameof(SaveProgrammers))]
		public async Task<IActionResult> SaveProgrammers(List<DtoProgrammer> programmers)
		{
			await analyzerRepository.SaveProgrammers(programmers);

			return Ok();
		}

		[HttpPost]
		[Route(nameof(SavePipelinesExecutions))]
		public async Task<IActionResult> SavePipelinesExecutions(List<DtoSavePipelineExecution> dto)
		{
			await analyzerRepository.SavePipelineExecution(dto);

			return Ok();
		}

		[HttpPost]
		[Route(nameof(SetConnectorToProject))]
		public async Task<IActionResult> SetConnectorToProject(ConnectorUsedInProject connector)
		{
			await analyzerRepository.SetConnectorToProject(connector);

			return Ok();
		}

		[HttpPost]
		[Route(nameof(SaveSpecialMoment))]
		public async Task<IActionResult> SaveSpecialMoment(SpecialMoment specialMoment)
		{
			await analyzerRepository.SaveSpecialMoment(specialMoment);

			return Ok();
		}

		[HttpPost]
		[Route(nameof(SaveSkippedLogins))]
		public async Task<IActionResult> SaveSkippedLogins(List<DtoSkippedLogin> skippedLogins)
		{
			await analyzerRepository.SaveSkippedLogins(skippedLogins);
			return Ok();
		}

		[HttpPost]
		[Route(nameof(SaveProgrammersWorkingTimes))]
		public async Task<IActionResult> SaveProgrammersWorkingTimes(List<DtoSaveProgrammerWorkingTime> programmersWorkingTimes)
		{
			await analyzerRepository.SaveProgrammersWorkingTimes(programmersWorkingTimes);
			return Ok();
		}

		[HttpPost]
		[Route(nameof(GetSpecialMoments))]
		public ActionResult<List<DtoSpecialMoment>> GetSpecialMoments(DtoSpecialMomentContext specialMomentContext)
		{
			var specialMomemnts = analyzerRepository.GetSpecialMoments(specialMomentContext);

			var dto = specialMomemnts.Select(m => m.ToDto()).ToList();

			return Ok(dto);
		}

		[HttpGet]
		[Route(nameof(GetProjectByName) + "/{name}")]
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		[ProducesResponseType(typeof(Project), (int)HttpStatusCode.OK)]
		public ActionResult<Project> GetProjectByName(string name)
		{
			var project = analyzerRepository.GetProjectByName(name);

			if (project != null)
			{
				return project;
			}

			return NotFound();
		}

		[HttpPost]
		[Route(nameof(GetPipelineExecutions))]
		public ActionResult<List<DtoPipelineExecution>> GetPipelineExecutions(DtoPipelineContext pipelineContext)
		{
			var pipelineExecutions = analyzerRepository.GetPipelineExecutions(pipelineContext);

			return Ok(pipelineExecutions);
		}

		[HttpPost]
		[Route(nameof(GetProjectContexts))]
		public ActionResult<List<DtoPipelineContext>> GetProjectContexts([FromBody] int projectId)
		{
			var contexts = analyzerRepository.GetProjectContexts(projectId);

			return Ok(contexts);
		}

		[HttpPost]
		[Route(nameof(GetProgrammers))]
		public ActionResult<List<DtoProgrammer>> GetProgrammers([FromBody] int projectId)
		{
			var programmers = analyzerRepository.GetProgrammers(projectId);

			return Ok(programmers);
		}

		[HttpPost]
		[Route(nameof(GetProgrammersWorkingTimes))]
		public ActionResult<List<DtoProgrammerWorkingTime>> GetProgrammersWorkingTimes([FromBody] int projectId)
		{
			var programmersWorkingTime = analyzerRepository.GetProgrammersWorkingTimes(projectId);

			return Ok(programmersWorkingTime);
		}
	}
}
