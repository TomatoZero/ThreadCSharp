using System;

namespace Lab3{
    public class Consumer{
        private Storage _storage;
        private int _itemNum;
        private int _id;

        public Consumer(Storage storage, int itemNum, int id) {
            _storage = storage;
            _itemNum = itemNum;
            _id = id;
        }
        
        public void Run() {
            try {
                string item;
                for (var i = 0; i < _itemNum; i++) {
                    Console.WriteLine($"Consumer #{_id} See if the storage is empty : {i}");
                    _storage.EmptyWaitOne();
                    Console.WriteLine($"Consumer #{_id} Near the storage Item #{i}");
                    _storage.AccessWaitOne();
                    Console.WriteLine($"Consumer #{_id} In the storage Item #{i}");

                    item = _storage.TakeItem();
                    Console.WriteLine($"Consumer #{_id} Take Item {i}");

                    Console.WriteLine($"Consumer #{_id} Near the exit Item #{i}");
                    _storage.AccessRelease();
                    Console.WriteLine($"Consumer #{_id} Left the storage Item #{i}");
                    Console.WriteLine($"Consumer #{_id} FullRelease. Item #{i}");
                    _storage.FullRelease();
                }    
            }
            catch (Exception e) {
                throw new Exception(e.Message);
            }
        }
    }
}