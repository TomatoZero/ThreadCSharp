using System;

namespace Lab3
{
    public class Producer
    {
        private readonly Storage _storage;
        private readonly int _itemNum;
        private readonly int _id;

        public Producer(Storage storage, int itemNum, int id)
        {
            _storage = storage;
            _itemNum = itemNum;
            _id = id;
        }

        public void Run()
        {
            try
            {
                for (var i = 0; i < _itemNum; i++)
                {
                    Console.WriteLine($"Producer #{_id} See if the storage is full. Item #{i}");
                    _storage.FullWaitOne();
                    Console.WriteLine($"Producer #{_id} Near the storage Item #{i}");
                    _storage.AccessWaitOne();
                    Console.WriteLine($"Producer #{_id} In the storage Item #{i}");

                    _storage.PutItem($"Item {i}");
                    Console.WriteLine($"Producer #{_id} Put Item {i}");

                    Console.WriteLine($"Producer #{_id} Near the exit Item #{i}");
                    _storage.AccessRelease();
                    Console.WriteLine($"Producer #{_id} Left the storage Item #{i}");
                    Console.WriteLine($"Producer #{_id} EmptyRelease :  {i}");
                    _storage.EmptyRelease();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}