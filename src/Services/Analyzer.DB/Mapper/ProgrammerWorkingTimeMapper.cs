using Analyzer.DB.Model;

namespace Analyzer.DB.Mapper
{
	public static class ProgrammerWorkingTimeMapper
	{
		public static DtoProgrammerWorkingTime ToDto(this ProgrammerWorkingTime programmerWorkingTime)
		{
			return new DtoProgrammerWorkingTime()
			{
				Id = programmerWorkingTime.Id,
				ProjectId = programmerWorkingTime.ProjectId,
				Date = programmerWorkingTime.Date,
				ProgrammerId = programmerWorkingTime.ProgrammerId,
				Time = programmerWorkingTime.Time,
			};
		}
	}
}
