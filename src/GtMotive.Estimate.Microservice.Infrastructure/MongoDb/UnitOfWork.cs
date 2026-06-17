using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb
{
    /// <summary>
    /// MongoDB unit of work implementation.
    /// </summary>
    public sealed class UnitOfWork : IUnitOfWork
    {
        /// <inheritdoc/>
        public Task<int> Save()
        {
            return Task.FromResult(0);
        }
    }
}
