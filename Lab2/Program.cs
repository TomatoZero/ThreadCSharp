using System;
using System.Diagnostics;

namespace Lab2{
    internal class Program{
        public static void Main(string[] args) {
            Console.WriteLine($"Thread num: ");
            var thread = Convert.ToInt32(Console.ReadLine());
            
            var watch = new Stopwatch();

            var dimension = 4000000;
            var arr = new MyArrClass(dimension);
            
            watch.Start();
            var min = arr.PartMin(0, dimension - 1);
            watch.Stop();

            Console.WriteLine($"min: {min} watch: {watch.ElapsedMilliseconds}");
            
            watch.Restart();
            watch.Start();
            
            var minParallel = arr.ParallelMin(thread);
            watch.Stop();
            Console.WriteLine($"Parallel min: {minParallel} watch: {watch.ElapsedMilliseconds}");

            // Console.ReadLine();
        }
    }
}