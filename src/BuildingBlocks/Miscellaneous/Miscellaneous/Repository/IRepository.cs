﻿namespace Miscellaneous.Repository
{
	public interface IRepository<T>
	{
		IUnitOfWork UnitOfWork { get; }
	}
}
