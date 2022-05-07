using RCP.DB.Model;

namespace RCP.DB.Mapper
{
	public static class ProgrammerMapper
	{
		public static Programmer FromDto(this DtoSaveProgrammer dto, int projectId)
		{
			return new Programmer()
			{
				Email = dto.Email,
				FullName = dto.FullName,
				JobTitle = dto.JobTitle,
				Login = dto.Login,
				ProjectId = projectId
			};
		}

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
				Email = programmer.Email,
				FullName = programmer.FullName,
				Id = programmer.Id,
				JobTitle = programmer.JobTitle,
				Login = programmer.Login,
				ProjectId = programmer.ProjectId
			};
		}
	}
}
