using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arslan.Net.Service.Demo.Services
{
    public interface ICounterService
    {
        int Value();
        int Decrease();
        int Increase();
        int Reset();
    }
}
