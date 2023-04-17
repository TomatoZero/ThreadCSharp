using System.Threading;

namespace Lab4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var forkCount = 5;

            var table = new Table(forkCount);

            var philosophers = new Philosopher[forkCount];
            var threadPhilosophers = new Thread[forkCount];

            for (var i = 0; i < forkCount; i++)
            {
                philosophers[i] = new Philosopher(i, table);
                threadPhilosophers[i] = new Thread(philosophers[i].Run);
                threadPhilosophers[i].Start();
            }
        }
    }
}