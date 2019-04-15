using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arslan.Net.Service.Demo.Services
{
    public class CounterService : ICounterService
    {
        private int _count = 0;

        public int Value() => _count;
        public int Decrease() => --_count;
        public int Increase() => ++_count;
        public int Reset() => _count=0;
    }
}
