using ConsoleTables;

namespace Algorithms
{
    public class MatrixStar
    {
        public List<int> B { get; set; }
        public List<int> Bl { get; set; }
        public List<int> Bll { get; set; }

        public void print()
        {
            var firstLine = new List<string>();
            var secondLine = new List<string>();
            var thirdLine = new List<string>();
            var fourthLine = new List<string>();
            for (int i = 0; i < Bl.Count; i++)
            {
                firstLine.Add(i.ToString());
                if (i != B.Count)
                    secondLine.Add(B[i].ToString());
                else
                    secondLine.Add("-");
                thirdLine.Add(Bl[i].ToString());
                fourthLine.Add(Bll[i].ToString());
            }
            var table = new ConsoleTable(firstLine.ToArray());
            table.AddRow(secondLine.ToArray());
            table.AddRow(thirdLine.ToArray());
            table.AddRow(fourthLine.ToArray());

            table.Write();
            Console.WriteLine();
        }
    }

    public static class KMPStar
    {
        public static List<Tuple<int, int>> Execution(string mainStr, string subStr)
        {
            var count = 0;
            var res = new List<Tuple<int, int>>();

            var n = mainStr.Length;
            var m = subStr.Length;

            var i = 0;
            var j = 0;
            var matrix = GetUtilityInfo(subStr);
            matrix.print();

            while (i <= n - m + j)
            {
                var resMatch = Match(i, j, mainStr, subStr, ref count);
                i = resMatch.Item1;
                j = resMatch.Item2;
                if (j == m)
                    res.Add(Tuple.Create(i - m, count));

                if (j == 0)
                    i++;
                else
                {
                    j = matrix.Bll[j];
                    if (j == 0)
                        i++;
                }
            }

            res.Add(Tuple.Create(-1, count));
            return res;
        }

        private static MatrixStar GetUtilityInfo(string mainStr)
        {
            var n = mainStr.Length;
            var i = 1;
            var j = 0;
            var b = new List<int>();
            var bl = new List<int>();
            var bll = new List<int>();

            b.Add(0);
            bl.Add(0);
            bll.Add(0);
            bl.Add(1);

            while (i != n)
            {
                if (mainStr[i] == mainStr[j])
                {
                    b.Add(j + 1);
                    bl.Add(j + 2);
                    j++;
                    i++;
                }
                else if (j == 0)
                {
                    b.Add(0);
                    bl.Add(1);
                    i++;
                }
                else
                {
                    j = b[j - 1];
                }
            }

            for(var l = 1; l < n; l++)
            {
                var list = new List<int>();
                list.Add(0);
                var k = l;
                while(k > 0)
                {
                    if(bl[k] != b[k])
                        list.Add(bl[k]);
                    k = b[k] - 1;
                }
                bll.Add(list.Max());
            }
            bll.Add(bl[bl.Count - 1]);

            return new MatrixStar
            {
                B = b,
                Bl = bl,
                Bll = bll
            };
        }

        private static Tuple<int, int> Match(int i, int j, string mainStr, string subStr, ref int count)
        {
            while (j < subStr.Length)
            {
                count++;
                if (mainStr[i] != subStr[j])
                    return Tuple.Create(i, j);
                i++;
                j++;
            }
            return Tuple.Create(i, j);
        }
    }
}
