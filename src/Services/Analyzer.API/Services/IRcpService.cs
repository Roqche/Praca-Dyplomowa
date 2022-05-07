using Analyzer.API.Services.Model;
using Analyzer.API.Services.Model.RCP;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Analyzer.API.Services
{
	public interface IRcpService
	{
		Task<List<DtoProgrammer>> GetAllProgrammers();

		Task<List<DtoJenkinsJob>> GetJenkinsJobs();

		Task<List<DtoSaveProgrammerWorkingTime>> GetProgrammersWorkingTimes();
	}
}
