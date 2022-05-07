using RCP.DB.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RCP.DB.Services
{
	public interface IRcpService
	{
		Task SaveJenkinsJobs(IEnumerable<JenkinsJob> jobs);

		List<JenkinsJob> GetAllJenkinsJobs();

		List<JenkinsJob> GetJenkinsJobs(DtoGetJenkinsJob getJenkinsJob);

		List<JenkinsJob> GetProgrammersJenkinsJobs(DtoGetJenkinsJob getJenkinsJob);

		Task ClearJenkinsJobTable();

		Task SaveProject(string projectName);

		Project GetProject(string name);

		Project GetProject(int id);

		Task SaveProgrammers(List<DtoSaveProgrammer> saveProgrammers);

		List<Programmer> GetAllProgrammers();

		Programmer GetProgrammer(string login);

		Programmer GetProgrammer(int id);

		Task SaveProgrammerWorkingTime(ProgrammerWorkingTime programmerWorkingTime);

		Task SaveManyProgrammersWorkingTimes(IEnumerable<ProgrammerWorkingTime> programmersWorkingTimes);

		List<ProgrammerWorkingTime> GetProgrammersWorkingTimes();
	}
}
