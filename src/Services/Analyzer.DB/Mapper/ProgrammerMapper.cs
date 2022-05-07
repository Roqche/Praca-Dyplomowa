using Analyzer.DB.Model;

namespace Analyzer.DB.Mapper
{
	public static class ProgrammerMapper
	{
		public static Programmer FromDto(this DtoProgrammer dto)
		{
			return new Programmer()
			{
				Email = dto.Email,
				FullName = dto.FullName,
				JobTitle = dto.JobTitle,
				Login = dto.Login,
				ProjectId = dto.ProjectId
			};
		}

		public static DtoProgrammer ToDto(this Programmer programmer)
		{
			return new DtoProgrammer()
			{
				Id = programmer.Id,
				Email = programmer.Email,
				FullName = programmer.FullName,
				JobTitle = programmer.JobTitle,
				Login = programmer.Login,
				ProjectId = programmer.ProjectId
			};
		}
	}
}
