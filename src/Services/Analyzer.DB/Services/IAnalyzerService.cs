using Analyzer.DB.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Analyzer.DB.Services
{
	public interface IAnalyzerService
	{
		Task InsertProject(Project project);

		Project GetProjectByName(string name);

		Task SetConnectorToProject(ConnectorUsedInProject connector);

		List<SpecialMoment> GetSpecialMoments(DtoSpecialMomentContext momentContext);

		Task SaveSpecialMoment(SpecialMoment specialMoment);

		Task SavePipelineExecution(List<DtoSavePipelineExecution> pipelinesExecutions);
		Task SaveProgrammers(List<DtoProgrammer> programmers);
		Task SaveSkippedLogins(List<DtoSkippedLogin> skippedLogins);
		List<DtoPipelineExecution> GetPipelineExecutions(DtoPipelineContext pipelineContext);
		List<DtoPipelineExecution> GetProjectPipelineExecutions(int projectId);
		List<DtoPipelineContext> GetProjectContexts(int projectId);
		List<DtoProgrammer> GetProgrammers(int projectId);
		Task SaveProgrammersWorkingTimes(List<DtoSaveProgrammerWorkingTime> programmersWorkingTimes);
		List<DtoProgrammerWorkingTime> GetProgrammersWorkingTimes(int projectId);
	}
}
