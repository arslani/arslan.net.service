using Arslan.Net.Service.Demo.Services;
using Microsoft.AspNetCore.Mvc;

namespace Arslan.Net.Service.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CounterController : ControllerBase
    {
        private readonly ICounterService _counter;


        // Constructor Injection
        public CounterController(Service<ICounterService> counter =default) {
            _counter = (CounterService)counter;

            Service<ICounterService> counter1 = new CounterService(); 
        }


        // Property Injection
        public Service<ICounterService> _counterProperty { get; set; }

        [HttpGet]
        public int Get() => _counter.Value();

        [HttpGet("Decrease")]   // Argument Injection
        public int Decrease(Service<ICounterService> counter = default) => counter.Value.Decrease();

        [HttpGet("Increase")]
        public int Increase() => _counterProperty.Value.Increase();

        [HttpGet("Reset")]
        public int Reset() {
            Service<ICounterService> counter = default;
           return counter.Value.Reset();
        }
    }
}
