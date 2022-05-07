using System;
using System.Threading;
using System.Threading.Tasks;

namespace Miscellaneous.Repository
{
	public interface IUnitOfWork : IDisposable
	{
		Task<int> SaveChangesAsync(CancellationToken cancelationToken = default);

		//Task<bool> SaveEntitiesAsync(CancellationToken cancelationToken = default);
	}
}