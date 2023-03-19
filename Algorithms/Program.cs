using ConsoleTables;

do
{
    Console.Write("Основная строка: ");
    var mainStr = Console.ReadLine();
    Console.Write("Подстрока: ");
    var subStr = Console.ReadLine();

    try
    {
        var res = Algorithms.NaiveAlgorithm.Execution(mainStr, subStr);

        var firstLine = new List<string>();
        var secondLine = new List<string>();
        for (int i = 0; i < mainStr.Length; i++)
        {
            firstLine.Add(i.ToString());
            secondLine.Add(mainStr[i].ToString());
        }
        var table = new ConsoleTable(firstLine.ToArray());
        table.AddRow(secondLine.ToArray());

        table.Write();
        Console.WriteLine();

        foreach (var item in res)
        {
            Console.WriteLine($"Индекс вхождения: {item.Item1}, Кол-во сравнений: {item.Item2}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }

    Console.WriteLine("Завершить работу? (Esc)");
} while (Console.ReadKey().KeyChar != (char)ConsoleKey.Escape);