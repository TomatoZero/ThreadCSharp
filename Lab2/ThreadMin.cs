namespace Lab2
{
    public class ThreadMin
    {
        private readonly int _startIndex;
        private readonly int _endIndex;
        private readonly MyArrClass _arr;

        public ThreadMin(int startIndex, int endIndex, MyArrClass arr)
        {
            _startIndex = startIndex;
            _endIndex = endIndex;
            _arr = arr;
        }

        public void Run()
        {
            var min = _arr.PartMin(_startIndex, _endIndex);
            _arr.SetMinValue(min.Item1, min.Item2);
        }
    }
}