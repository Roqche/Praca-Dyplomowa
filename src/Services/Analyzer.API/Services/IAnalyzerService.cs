using Analyzer.API.Services.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Analyzer.API.Services
{
	public interface IAnalyzerService
	{
		Task<List<DtoSpecialMoment>> GetSpecialMoments(DtoPipelineContext specialMomentContext);
		Task SavePipelinesExecutions(List<DtoSavePipelineExecution> pipelinesExecutions);
		Task SaveProgrammers(List<DtoProgrammer> programmers);
		Task SaveProgrammersWorkingTimes(List<DtoSaveProgrammerWorkingTime> programmersWorkingTimes);
		Task<List<DtoPipelineExecution>> GetPipelineExecutions(DtoPipelineContext pipelineContext);
		Task<List<DtoPipelineExecution>> GetProjectPipelineExecutions(int projectId);
		Task<List<DtoPipelineContext>> GetProjectContexts(int projectId);
		Task<List<DtoProgrammer>> GetProgrammers(int projectId);
		Task<List<DtoProgrammerWorkingTime>> GetProgrammersWorkingTimes(int projectId);
	}
}
