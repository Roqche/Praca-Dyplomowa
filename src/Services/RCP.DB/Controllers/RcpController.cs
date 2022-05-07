using Microsoft.AspNetCore.Mvc;
using RCP.DB.Mapper;
using RCP.DB.Model;
using RCP.DB.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RCP.DB.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class RcpController : ControllerBase
	{
		private readonly IRcpService rcpService;

		public RcpController(IRcpService rcpService)
		{
			this.rcpService = rcpService;
		}

		[HttpPost]
		[Route(nameof(SaveJenkinsJobs))]
		public async Task<IActionResult> SaveJenkinsJobs(List<DtoJenkinsJob> dto)
		{
			var jenkinsJobs = dto.Select(j => j.FromDto());

			await rcpService.SaveJenkinsJobs(jenkinsJobs);

			return Ok(jenkinsJobs);
		}

		[HttpPost]
		[Route(nameof(SaveProgrammerWorkingTime))]
		public async Task<IActionResult> SaveProgrammerWorkingTime(ProgrammerWorkingTime programmerWorkingTime)
		{
			await rcpService.SaveProgrammerWorkingTime(programmerWorkingTime);
			return Ok();
		}

		[HttpPost]
		[Route(nameof(SaveManyProgrammersWorkingTimes))]
		public async Task<IActionResult> SaveManyProgrammersWorkingTimes(IEnumerable<ProgrammerWorkingTime> programmersWorkingTimes)
		{
			await rcpService.SaveManyProgrammersWorkingTimes(programmersWorkingTimes);
			return Ok();
		}

		[HttpGet]
		[Route(nameof(GetProgrammersWorkingTimes))]
		public ActionResult<List<ProgrammerWorkingTime>> GetProgrammersWorkingTimes()
		{
			var programmerWorkingTimes = rcpService.GetProgrammersWorkingTimes();
			return Ok(programmerWorkingTimes);
		}

		[HttpGet]
		[Route(nameof(GetAllJenkinsJobs))]
		public ActionResult<List<DtoJenkinsJob>> GetAllJenkinsJobs()
		{
			var jobs = rcpService.GetAllJenkinsJobs();
			return Ok(jobs);
		}

		[HttpPost]
		[Route(nameof(GetJenkinsJobs))]
		public ActionResult<List<DtoJenkinsJob>> GetJenkinsJobs(DtoGetJenkinsJob getJenkinsJob)
		{
			if (string.IsNullOrEmpty(getJenkinsJob.JobName))
			{
				return BadRequest($"The parameter {getJenkinsJob.JobName} can not be empty");
			}

			var jenkinsJobs = rcpService.GetJenkinsJobs(getJenkinsJob);

			var dto = jenkinsJobs.Select(j => j.ToDto()).ToList();
			return Ok(dto);
		}

		[HttpPost]
		[Route(nameof(GetProgrammersJenkinsJobs))]
		public ActionResult<List<DtoJenkinsJob>> GetProgrammersJenkinsJobs(DtoGetJenkinsJob getJenkinsJob)
		{
			if (string.IsNullOrEmpty(getJenkinsJob.JobName))
			{
				return BadRequest($"The parameter {nameof(getJenkinsJob.JobName)} can not be empty");
			}

			if (string.IsNullOrEmpty(getJenkinsJob.ProgrammerLogin))
			{
				return BadRequest($"The parameter {nameof(getJenkinsJob.ProgrammerLogin)} can not be empty");
			}

			var jenkinsJobs = rcpService.GetProgrammersJenkinsJobs(getJenkinsJob);

			var dto = jenkinsJobs.Select(j => j.ToDto()).ToList();
			return Ok(dto);
		}

		[HttpDelete]
		[Route(nameof(ClearJenkinsJobTable))]
		public async Task<IActionResult> ClearJenkinsJobTable()
		{
			await rcpService.ClearJenkinsJobTable();
			return Ok();
		}

		[HttpPost]
		[Route(nameof(SaveProject))]
		public async Task<IActionResult> SaveProject(string projectName)
		{
			await rcpService.SaveProject(projectName);
			return Ok();
		}

		[HttpPost]
		[Route(nameof(GetProject))]
		public ActionResult<Project> GetProject(string projectName)
		{
			var project = rcpService.GetProject(projectName);
			return Ok(project);
		}

		[HttpPost]
		[Route(nameof(SaveProgrammers))]
		public async Task<IActionResult> SaveProgrammers(List<DtoSaveProgrammer> dtoProgrammers)
		{
			await rcpService.SaveProgrammers(dtoProgrammers);
			return Ok();
		}

		[HttpGet]
		[Route(nameof(GetProgrammerByLogin))]
		public ActionResult<DtoProgrammer> GetProgrammerByLogin(string login)
		{
			var programmer = rcpService.GetProgrammer(login);
			return Ok(programmer.ToDto());
		}

		[HttpGet]
		[Route(nameof(GetProgrammer))]
		public ActionResult<DtoProgrammer> GetProgrammer(int id)
		{
			var programmer = rcpService.GetProgrammer(id);
			return Ok(programmer.ToDto());
		}

		[HttpGet]
		[Route(nameof(GetAllProgrammers))]
		public ActionResult<List<DtoProgrammer>> GetAllProgrammers()
		{
			var programmers = rcpService.GetAllProgrammers();

			var dto = programmers.Select(p => p.ToDto()).ToList();

			return Ok(dto);
		}
	}
}
