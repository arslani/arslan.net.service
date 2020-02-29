namespace Arslan.Net.Services {
    public class CounterService : ICounterService {
        private int _count = 0;

        public int Value() => _count;
        public int Increase() => ++_count;
        public int Reset() => _count = 0;
    }
}
