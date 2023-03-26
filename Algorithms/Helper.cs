namespace Algorithms
{
    public static class Helper
    {
        public static List<char> GetAlphabet(string str)
        {
            var res = new List<char>();
            foreach (char c in str)
            {
                if(!res.Contains(c))
                    res.Add(c);
            }
            return res;
        }
    }
}
