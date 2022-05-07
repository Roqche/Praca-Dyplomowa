using Analyzer.DB.Infrastructure;
using Analyzer.DB.Mapper;
using Analyzer.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Analyzer.DB.Services.Implementation
{
	public class AnalyzerService : IAnalyzerService
	{
		private readonly AnalyzerContext context;

		public AnalyzerService(AnalyzerContext context)
		{
			this.context = context;
		}

		public List<SpecialMoment> GetSpecialMoments(DtoSpecialMomentContext momentContext)
		{
			var pipelineContext = context.PipelinesContexts.FirstOrDefault(pc => pc.Context == momentContext.Context && pc.ProjectId == momentContext.ProjectId);
			if (pipelineContext != null)
			{
				return context.SpecialMoments.Where(sm => sm.ProjectId == pipelineContext.ProjectId && sm.ContextId == pipelineContext.Id).ToList();
			}
			else
			{
				throw new ArgumentException("Such project or context does not exist");
			}
		}

		public Task InsertProject(Project project)
		{
			if (context.Project.Where(p => p.ProjectName == project.ProjectName).Any())
			{
				throw new ArgumentException("Project exists!");
			}

			context.Project.Add(project);

			return context.SaveChangesAsync();
		}

		public Project GetProjectByName(string name)
		{
			return context.Project.FirstOrDefault(p => p.ProjectName == name);
		}

		public Task SaveSpecialMoment(SpecialMoment specialMoment)
		{
			context.SpecialMoments.Add(specialMoment);

			return context.SaveChangesAsync();
		}

		public Task SetConnectorToProject(ConnectorUsedInProject connector)
		{
			context.ConnectorsUsedInProjects.Add(connector);

			return context.SaveChangesAsync();
		}

		public Task SavePipelineExecution(List<DtoSavePipelineExecution> pipelinesExecutions)
		{
			AddPipelinesContextsToContext(pipelinesExecutions);

			AddPipelinesExecutionsToContext(pipelinesExecutions);

			return context.SaveChangesAsync();
		}

		private void AddPipelinesExecutionsToContext(List<DtoSavePipelineExecution> pipelinesExecutions)
		{
			var pipelinesContexts = GetExistingContexts();
			var projects = pipelinesExecutions.Select(p => p.ProjectName).Distinct().ToList();

			var pipelinesByProjectName = pipelinesExecutions.GroupBy(p => p.ProjectName);

			var pipelinesExecutionToSave = new List<PipelineExecution>();
			foreach (var pipelines in pipelinesByProjectName)
			{
				var projectName = pipelines.Key;
				var project = GetProjectByName(projectName);
				if (project != null)
				{
					var projectProgrammers = GetProgrammers_Private(project.Id);
					var skippedLogins = GetSkippedLogins(project.Id);

					foreach (var pipeline in pipelines)
					{
						if (!skippedLogins.Any(l => l.Login == pipeline.ProgrammerLogin))
						{
							var pipelineContext = pipelinesContexts.FirstOrDefault(c => c.Context == pipeline.Context);
							if (pipelineContext == null)
							{
								//Log Error
							}

							var programmer = projectProgrammers.FirstOrDefault(p => p.Login == pipeline.ProgrammerLogin && p.ProjectId == project.Id);
							if (programmer == null)
							{
								//Log Error
							}

							var pipelineExecution = new PipelineExecution()
							{
								ProjectId = project.Id,
								ContextId = pipelineContext.Id,
								ProgrammerId = programmer.Id,
								ExecutionNumber = pipeline.ExecutionNumber,
								Result = pipeline.Result,
								StartTime = pipeline.StartTime,
								Duration = pipeline.Duration,
							};

							pipelinesExecutionToSave.Add(pipelineExecution);
						}
					}
				}
				else
				{
					throw new ArgumentNullException($"There is no saved project which can be fitted to this name: {projectName}");
				}
			}

			context.PipelinesExecutions.AddRange(pipelinesExecutionToSave);
		}

		private List<SkippedLogin> GetSkippedLogins(int projectId)
		{
			return context.SkippedLogins.Where(context => context.ProjectId == projectId).ToList();
		}

		private List<Programmer> GetProgrammers_Private(int projectId)
		{
			return context.Programmers.Where(p => p.ProjectId == projectId).ToList();
		}

		private void AddPipelinesContextsToContext(List<DtoSavePipelineExecution> pipelinesExecutions)
		{
			var pipelinesContexts = GetContexts(pipelinesExecutions);
			var existingContexts = GetExistingContextsNames();

			var notSavedContexts = pipelinesContexts.Except(existingContexts);

			if (notSavedContexts.Any())
			{
				var contextsToSave = notSavedContexts.Select(c => new PipelineContext() { Context = c }).ToList();

				context.PipelinesContexts.AddRange(contextsToSave);
			}
		}

		private static List<string> GetContexts(List<DtoSavePipelineExecution> pipelinesExecutions)
		{
			return pipelinesExecutions.Select(pe => pe.Context).Distinct().ToList();
		}

		private List<string> GetExistingContextsNames()
		{
			return context.PipelinesContexts.Select(pc => pc.Context).ToList();
		}

		private List<PipelineContext> GetExistingContexts()
		{
			return new List<PipelineContext>(context.PipelinesContexts);
		}

		public Task SaveProgrammers(List<DtoProgrammer> programmers)
		{
			var existingProgrammers = new List<Programmer>(context.Programmers);

			var notSavedProgrammers = new List<DtoProgrammer>();
			foreach (var programmer in programmers)
			{
				if (!existingProgrammers.Any(p => p.ProjectId == programmer.ProjectId && p.Login == programmer.Login))
				{
					notSavedProgrammers.Add(programmer);
				}
			}

			if (notSavedProgrammers.Any())
			{
				var programmersToSave = programmers.Select(p => p.FromDto());

				context.Programmers.AddRange(programmersToSave);
			}

			return context.SaveChangesAsync();
		}

		public Task SaveSkippedLogins(List<DtoSkippedLogin> skippedLogins)
		{
			var existingLogins = new List<SkippedLogin>(context.SkippedLogins);
			foreach (var skippedLogin in skippedLogins)
			{
				if (!existingLogins.Any(l => l.Login == skippedLogin.Login && l.ProjectId == skippedLogin.ProjectId))
				{
					var loginToSave = new SkippedLogin
					{
						Login = skippedLogin.Login,
						ProjectId = skippedLogin.ProjectId
					};
					context.SkippedLogins.Add(loginToSave);
				}
			}

			return context.SaveChangesAsync();
		}

		public Task SaveProgrammersWorkingTimes(List<DtoSaveProgrammerWorkingTime> programmersWorkingTimes)
		{
			var projectsNames = programmersWorkingTimes.Select(p => p.ProjectName).Distinct().ToList();

			var projects = new List<Project>();
			foreach(var name in projectsNames)
			{
				var project = GetProjectByName(name);
				if(project != null)
				{
					projects.Add(project);
				}
			}

			var programmersWorkingTimesTakenIntoAccount = programmersWorkingTimes.Where(pwt => projects.Any(p => p.ProjectName == pwt.ProjectName)).ToList();

			var allProgrammers = projects.Select(project => GetProgrammers_Private(project.Id)).SelectMany(p => p).ToList();

			var transformedProgrammerWorkingTime = programmersWorkingTimesTakenIntoAccount.Select(pwt =>
			{
				var projectId = projects.First(p => p.ProjectName == pwt.ProjectName).Id;
				var programmerId = allProgrammers.First(p => p.ProjectId == projectId && p.Login == pwt.Login).Id;
				return new ProgrammerWorkingTime
				{
					ProjectId = projectId,
					ProgrammerId = programmerId,
					Date = pwt.Date,
					Time = pwt.Time,
				};
			}).ToList();

			context.ProgrammersWorkingTimes.AddRange(transformedProgrammerWorkingTime);

			return context.SaveChangesAsync();
		}

		public List<DtoPipelineExecution> GetPipelineExecutions(DtoPipelineContext pipelineContext)
		{
			var contextId = context.PipelinesContexts.FirstOrDefault(c => c.Context == pipelineContext.Context)?.Id;

			if (contextId.HasValue)
			{
				return context.PipelinesExecutions.Where(pe => pe.ContextId == contextId && pe.ProjectId == pipelineContext.ProjectId)
					?.Select(t => t.ToDto()).ToList();
			}
			else
			{
				return new List<DtoPipelineExecution>();
			}
		}

		public List<DtoPipelineExecution> GetProjectPipelineExecutions(int projectId)
		{
			return context.PipelinesExecutions.Where(pe => pe.ProjectId == projectId)
				?.Select(t => t.ToDto()).ToList();
		}

		public List<DtoPipelineContext> GetProjectContexts(int projectId)
		{
			return context.PipelinesContexts.Where(pc => pc.ProjectId == projectId)?.Select(t => t.ToDto()).ToList();
		}

		public List<DtoProgrammer> GetProgrammers(int projectId)
		{
			return context.Programmers.Where(p => p.ProjectId == projectId)?.Select(r => r.ToDto()).ToList();
		}

		public List<DtoProgrammerWorkingTime> GetProgrammersWorkingTimes(int projectId)
		{
			return context.ProgrammersWorkingTimes.Where(p => p.ProjectId == projectId)?.Select(r => r.ToDto()).ToList();
		}
	}
}
