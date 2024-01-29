int t = int.Parse(Console.ReadLine()); // 5; 

//var strings = new List<string[]>
//{
//    new[] { "3", "2", "1", "0", "-1", "0", "6", "6", "7" },
//    new[] { "1000" },
//    new[] { "1", "2", "3", "4", "5", "6", "7" },
//    new[] { "1", "3", "5", "7", "9", "11", "13" },
//    new[] { "100", "101", "102", "103", "19", "20", "21", "22", "42", "41", "40" }
//};

for (int i = 0; i < t; i++)
{
    int n = int.Parse(Console.ReadLine()); // strings[i].Length;   

    var result = DataCompression(Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse), n);

    Console.WriteLine(result.Count);
    Console.WriteLine(string.Join(" ", result));
}

static IReadOnlyList<int> DataCompression(int[] sequence, int n)
{
    var compressed = new List<int>();
    int i = 0;

    int direction = (i < n - 1) ? Math.Sign(sequence[i + 1] - sequence[i]) : 0;

    while (i < n)
    {
        int j = i;

        if (j < n - 1)
            direction = Math.Sign(sequence[j + 1] - sequence[j]);

        while (j < n - 1 && sequence[j + 1] - sequence[j] == direction && direction != 0)
            j++;

        int bi = sequence[i];
        int ci = (direction >= 0) ? j - i : i - j;

        compressed.Add(bi);
        compressed.Add(ci);

        i = j + 1;
    }
    return compressed;
}