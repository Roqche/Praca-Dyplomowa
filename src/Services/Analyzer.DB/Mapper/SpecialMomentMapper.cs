using Analyzer.DB.Model;

namespace Analyzer.DB.Mapper
{
	public static class SpecialMomentMapper
	{
		public static DtoSpecialMoment ToDto(this SpecialMoment specialMoment)
		{
			return new DtoSpecialMoment()
			{
				Appeared = specialMoment.Appeared,
				ContextId = specialMoment.ContextId,
				Name = specialMoment.Name,
				ProjectId = specialMoment.ProjectId
			};
		}
	}
}
