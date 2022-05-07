using RCP.DB.Infrastructure;
using RCP.DB.Mapper;
using RCP.DB.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RCP.DB.Services.Implementation
{
	public class RcpService : IRcpService
	{
		private readonly RcpContext context;

		public RcpService(RcpContext context)
		{
			this.context = context;
		}

		public Task SaveJenkinsJobs(IEnumerable<JenkinsJob> jobs)
		{
			context.JenkinsJobs.AddRange(jobs);
			return context.SaveChangesAsync();
		}

		public List<JenkinsJob> GetAllJenkinsJobs()
		{
			return new List<JenkinsJob>(context.JenkinsJobs);
		}

		public List<JenkinsJob> GetJenkinsJobs(DtoGetJenkinsJob getJenkinsJob)
		{
			return context.JenkinsJobs.Where(j => j.JobName == getJenkinsJob.JobName && j.ProjectName == getJenkinsJob.ProjectName)?.ToList();
		}

		public Task ClearJenkinsJobTable()
		{
			context.JenkinsJobs.RemoveRange(context.JenkinsJobs);
			return context.SaveChangesAsync();
		}

		public List<JenkinsJob> GetProgrammersJenkinsJobs(DtoGetJenkinsJob getJenkinsJob)
		{
			return context.JenkinsJobs.Where(j => j.JobName == getJenkinsJob.JobName && j.ProjectName == getJenkinsJob.ProjectName && j.Culprit == getJenkinsJob.ProgrammerLogin)?.ToList();
		}

		public Project GetProject(int id)
		{
			return context.Projects.FirstOrDefault(p => p.Id == id);
		}

		public Project GetProject(string name)
		{
			return context.Projects.FirstOrDefault(p => p.Name == name);
		}

		public Task SaveProject(string projectName)
		{
			var project = new Project()
			{
				Name = projectName
			};

			context.Projects.Add(project);
			return context.SaveChangesAsync();
		}

		public Programmer GetProgrammer(string login)
		{
			return context.Programmers.FirstOrDefault(p => p.Login == login);
		}

		public Programmer GetProgrammer(int id)
		{
			return context.Programmers.FirstOrDefault(p => p.Id == id);
		}

		public List<Programmer> GetAllProgrammers()
		{
			return new List<Programmer>(context.Programmers);
		}

		public Task SaveProgrammers(List<DtoSaveProgrammer> saveProgrammers)
		{
			var programmers = new List<Programmer>();

			var existingProgrammers = GetAllProgrammers();

			foreach (var dto in saveProgrammers)
			{
				var project = GetProject(dto.ProjectName);
				if (!existingProgrammers.Any(p => p.Login == dto.Login && p.ProjectId == project.Id))
				{
					var programmer = dto.FromDto(project.Id);
					programmers.Add(programmer);
				}
			}

			context.Programmers.AddRange(programmers);

			return context.SaveChangesAsync();
		}

		public Task SaveManyProgrammersWorkingTimes(IEnumerable<ProgrammerWorkingTime> programmersWorkingTimes)
		{
			context.ProgrammersWorkingTime.AddRange(programmersWorkingTimes);
			return context.SaveChangesAsync();
		}

		public Task SaveProgrammerWorkingTime(ProgrammerWorkingTime programmerWorkingTime)
		{
			return SaveManyProgrammersWorkingTimes(new List<ProgrammerWorkingTime>() { programmerWorkingTime });
		}

		public List<ProgrammerWorkingTime> GetProgrammersWorkingTimes()
		{
			return context.ProgrammersWorkingTime.ToList();
		}
	}
}
