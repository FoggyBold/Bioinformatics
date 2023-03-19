namespace Algorithms
{
    public static class NaiveAlgorithm
    {
        public static List<Tuple<int, int>> Execution(string mainStr, string subStr)
        {
            var count = 0;
            var res = new List<Tuple<int, int>>();

            if (mainStr.Length < subStr.Length)
            {
                throw new ArgumentException("Длина основной строки должна быть больше длины подстроки!");
            }

            for (var i = 0; i + subStr.Length - 1 < mainStr.Length; i++)
            {
                bool isCompleteCoincidence = true;
                for (var j = 0; j < subStr.Length; j++)
                {
                    isCompleteCoincidence = mainStr[i + j] == subStr[j];
                    count++;
                    if (!isCompleteCoincidence)
                    {
                        break;
                    }
                }
                if (isCompleteCoincidence)
                {
                    res.Add(Tuple.Create(i, count));
                }
            }

            return res;
        }
    }
}