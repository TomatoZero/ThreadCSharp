using System;
using System.Threading;

namespace Lab4
{
    public class Philosopher
    {
        private int _id;
        private Table _table;

        public int Id
        {
            get => _id;
        }

        public int Myi { get; set; }
        
        public Philosopher(int id, Table table)
        {
            _id = id;
            _table = table;
        }
        
        public void Run()
        {
            for (var i = 0; i < 10; i++)
            {
                Myi = i;
                Console.WriteLine($"Philosopher {_id} thinking {i} time");
                Thread.Sleep(100);
                
                Console.WriteLine($"Philosopher {_id} want eat {i} time");
                _table.RequestFork(this);

                Console.WriteLine($"Philosopher {_id} eats {i} time");
                Thread.Sleep(100);
                
                _table.PutForks(this);
            }
        }
    }
}