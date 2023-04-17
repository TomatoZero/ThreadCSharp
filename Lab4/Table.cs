using System;
using System.Threading;

namespace Lab4
{
    public class Table
    {
        private readonly Semaphore[] _forks;
        private Semaphore _waiter = new Semaphore(2, 2);

        public Table(int forksCount)
        {
            _forks = new Semaphore[forksCount];

            for (int i = 0; i < forksCount; i++)
                _forks[i] = new Semaphore(1, 1);
        }

        private (Semaphore, Semaphore) GetForks(int id)
        {
            (Semaphore, Semaphore) list;
            list.Item1 = _forks[id];

            if (id == 0) list.Item2 = _forks[_forks.Length - 1];
            else list.Item2 = _forks[id - 1];

            return list;
        }

        public void RequestFork(Philosopher philosopher)
        {
            var (leftFork, rightFork) = GetForks(philosopher.Id);

            while (true)
            {
                _waiter.WaitOne();
                Console.WriteLine($"The waiter came up to the philosopher {philosopher.Id} {philosopher.Myi} time");

                if (leftFork.WaitOne(10))
                {
                    Console.WriteLine($"Philosopher {philosopher.Id} took left fork {philosopher.Myi} time");
                    if (rightFork.WaitOne(10))
                    {
                        Console.WriteLine($"Philosopher {philosopher.Id} took right fork {philosopher.Myi} time");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Philosopher {philosopher.Id} " +
                                          "put left fork and the waiter moved away because right fork was taken" +
                                          $" {philosopher.Myi} time");
                        leftFork.Release();
                        _waiter.Release();
                        Thread.Sleep(100);
                    }
                }
                else
                {
                    Console.WriteLine($"The waiter moved away from the Philosopher {philosopher.Id}" +
                                      $" because right fork was taken {philosopher.Myi} time");
                    _waiter.Release();
                    Thread.Sleep(100);
                }
            }
        }


        public void PutForks(Philosopher philosopher)
        {
            var (leftFork, rightFork) = GetForks(philosopher.Id);
            
            Console.WriteLine($"Philosopher {philosopher.Id} put down both forks, and the waiter moved away {philosopher.Myi} time");
            leftFork.Release();
            rightFork.Release();
            _waiter.Release();
        }
    }
}