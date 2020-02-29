using Arslan.Net.Services;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Arslan.Net {

    public static class ServiceTestsExtensions {
        public static ICounterService GetCounterService(this ServiceTests self) {
            Service<ICounterService> service = default;
            return service.Value;
        }
    }

    public class ServiceTests {

        private Service<ICounterService> _counterService;

        public ServiceTests() {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<ICounterService, CounterService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            Service.Configure(t => serviceProvider.GetRequiredService(t));
        }


        public void Parameter_Injection(Service<ICounterService> counterService = default) {
            Assert.NotNull(counterService.Value);

            var service = counterService.Value;
            Assert.IsAssignableFrom<ICounterService>(service);

            service.Reset();
            Assert.Equal(1, service.Increase());
        }

        [Fact]
        public void Parameter_Injection_Test() {
            Parameter_Injection();
        }

        [Fact]
        public void Property_Injection_Test() {
            Assert.NotNull(_counterService.Value);

            var service = _counterService.Value;
            Assert.IsAssignableFrom<ICounterService>(service);

            service.Reset();
            Assert.Equal(1, service.Increase());
        }

        [Fact]
        public void Inline_Injection_Test() {
            Service<ICounterService> counterService = default;
            Assert.NotNull(counterService.Value);

            var service = counterService.Value;
            Assert.IsAssignableFrom<ICounterService>(service);

            service.Reset();
            Assert.Equal(1, service.Increase());
        }

        [Fact]
        public void Extension_Injection_Test() {
            var service = this.GetCounterService();
            Assert.NotNull(service);

            Assert.IsAssignableFrom<ICounterService>(service);

            service.Reset();
            Assert.Equal(1, service.Increase());
        }

        [Fact]
        public void Mackability_Test() {
            Parameter_Injection(new MockCounterService());
        }
    }
}
