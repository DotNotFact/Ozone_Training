int t = int.Parse(Console.ReadLine()); // 7

//var ints = new int[]
//{
//    8,
//    8,
//    8,
//    10,
//    10,
//    3,
//    100,
//};

//var strings1 = new string[]
//{
//    "7",
//    "1,7,1",
//    "1-5,1,7-7",
//    "1-5",
//    "1,2,3,4,5,6,8,9,10",
//    "1-2",
//    "1-2,3-7,10-20,100",
//};

for (int i = 0; i < t; i++)
{
    int k = int.Parse(Console.ReadLine()); // ints[i]; 
    string printedPages = Console.ReadLine(); // strings1[i];

    string result = GetPagesToPrint(k, printedPages);
    Console.WriteLine(result);
}

static string GetPagesToPrint(int k, string printedPages)
{
    var printed = new HashSet<int>();

    foreach (var part in printedPages.Split(','))
    {
        if (part.Contains('-'))
        {
            var range = part.Split('-').Select(int.Parse).ToArray();

            for (int i = range[0]; i <= range[1]; i++)
                printed.Add(i);
        }
        else
        {
            printed.Add(int.Parse(part));
        }
    }

    var pagesToPrint = new List<string>();

    for (int i = 1; i <= k; i++)
    {
        if (!printed.Contains(i))
        {
            int start = i;

            while (i <= k && !printed.Contains(i))
                i++;

            int end = i - 1;

            if (start == end)
                pagesToPrint.Add(start.ToString());
            else
                pagesToPrint.Add($"{start}-{end}");
        }
    }

    return string.Join(",", pagesToPrint);
}