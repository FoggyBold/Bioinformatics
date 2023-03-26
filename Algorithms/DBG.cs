namespace Algorithms
{
    public static class DBG
    {
        public static List<int> Execution(string mainStr, string subStr, List<char> alphabet)
        {
            var res = new List<int>();
            var m = subStr.Length;
            var n = mainStr.Length;
            var s = StartS(m);
            var t = CountT(subStr, alphabet);
            for(var i = 0; i < n; ++i)
            {
                s = CountS(s, t, alphabet, mainStr[i]);
                if(s[m] == 0)
                    res.Add(i - m + 1);
            }
            return res;
        }

        private static int[] StartS(int m)
        {
            var s = new int[m + 1];
            s[0] = 0;
            for (var i = 1; i <= m; i++)
                s[i] = 1;
            return s;
        }

        private static int[,] CountT(string subStr, List<char> alphabet)
        {
            var t = new int[alphabet.Count, subStr.Length];
            for(var i = 0; i < alphabet.Count; ++i)
            {
                for (var j = 0; j < subStr.Length; ++j)
                {
                    t[i, j] = subStr[j] == alphabet[i] ? 0 : 1;
                }
            }
            return t;
        }

        private static int[] CountS(int[] prevS, int[,] t, List<char> alphabet, char currElement)
        {
            var s = new int[prevS.Length];
            s[0] = 0;
            var index = alphabet.IndexOf(currElement);
            for (var i = 1; i < s.Length; i++)
            {
                s[i] = prevS[i - 1] | t[index, i - 1];
            }
            return s;
        }
    }
}
