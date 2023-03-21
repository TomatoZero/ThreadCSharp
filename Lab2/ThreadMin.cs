namespace Lab2{
    public class ThreadMin{
        private int _startIndex, _endIndex;
        private MyArrClass _arr;

        public ThreadMin(int startIndex, int endIndex, MyArrClass arr) {
            _startIndex = startIndex;
            _endIndex = endIndex;
            _arr = arr;
        }

        public void Run() {
            var min = _arr.PartMin(_startIndex, _endIndex);
            _arr.SetMinValue(min.Item1, min.Item2);
        }
    }
}