int t = int.Parse(Console.ReadLine()); // 4; 

//var strings = new List<string[]>
//{
//    new[] { ">= 30" },
//    new[] { ">= 18", "<= 23", ">= 20", "<= 27", "<= 21", ">= 28" },
//    new[] { "<= 25", ">= 20", ">= 25" },
//    new[] { "<= 15", ">= 30", "<= 24" }
//};

for (int i = 0; i < t; i++)
{
    int n = int.Parse(Console.ReadLine()); // strings[i].Length;

    int result, minTemp = 15, maxTemp = 30;
    bool impossible = false;

    for (int j = 0; j < n; j++)
    {
        string s = Console.ReadLine(); // strings[i][j];

        var (op, temp) = (s[0], int.Parse(s[2..]));

        if (!impossible)
        {
            if (op == '>') minTemp = Math.Max(minTemp, temp);
            else if (op == '<') maxTemp = Math.Min(maxTemp, temp);

            if (minTemp > maxTemp)
            {
                impossible = true;
                result = -1;
            }
            else
            {
                result = minTemp;
            }
        }
        else
        {
            result = -1;
        }
        Console.WriteLine(result == -1 ? "-1" : result.ToString());
    }

    Console.WriteLine();
}