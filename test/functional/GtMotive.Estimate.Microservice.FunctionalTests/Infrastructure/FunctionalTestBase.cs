using System.Threading.Tasks;
using Xunit;

namespace GtMotive.Estimate.Microservice.FunctionalTests.Infrastructure
{
    [Collection(TestCollections.Functional)]
#pragma warning disable CA1515 // Considere la posibilidad de hacer que los tipos públicos sean internos
    public abstract class FunctionalTestBase(CompositionRootTestFixture fixture) : IAsyncLifetime
#pragma warning restore CA1515 // Considere la posibilidad de hacer que los tipos públicos sean internos
    {
        public const int QueueWaitingTimeInMilliseconds = 1000;

        protected CompositionRootTestFixture Fixture { get; } = fixture;

        public virtual async Task InitializeAsync()
        {
            await Task.CompletedTask;
        }

        public virtual async Task DisposeAsync()
        {
            await Task.CompletedTask;
        }
    }
}
