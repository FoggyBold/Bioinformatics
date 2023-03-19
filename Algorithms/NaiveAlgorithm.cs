namespace Algorithms
{
    public static class NaiveAlgorithm
    {
        public static List<Tuple<int, int>> Execution(string mainStr, string subStr)
        {
            var count = 0;
            var res = new List<Tuple<int, int>>();

            for (var i = 0; i < mainStr.Length - subStr.Length + 1; i++)
            {
                var j = 0;
                for (; j < subStr.Length; j++)
                {
                    count++;
                    if (!(mainStr[i + j] == subStr[j]))
                    {
                        break;
                    }
                }
                if (j == subStr.Length)
                {
                    res.Add(Tuple.Create(i, count));
                }
            }

            return res;
        }
    }
}