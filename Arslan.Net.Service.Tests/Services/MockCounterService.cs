namespace Arslan.Net.Services {
    public class MockCounterService : ICounterService {
        private int _count = 0;

        public int Increase() => ++_count;
        public int Reset() => _count = 0;
        public int Value() => _count;
    }
}