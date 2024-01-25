var t = int.Parse(Console.ReadLine()); // 5 // int.TryParse(Console.ReadLine(), out int size); 

//string[] s1 = {
//    "2, 1, 3, 1, 2, 3, 1, 1, 4, 2",
//    "1, 1, 1, 2, 2, 2, 3, 3, 3, 4",
//    "1, 1, 1, 1, 2, 2, 2, 3, 3, 4",
//    "4, 3, 3, 2, 2, 2, 1, 1, 1, 1",
//    "4, 4, 4, 4, 4, 4, 4, 4, 4, 4",
//};

for (int i = 0; i < t; i++)
{
    string[] ships = Console.ReadLine().Split(' ');
    int[] field = Array.ConvertAll(ships, int.Parse);

    string result = CheckIsValid(field);
    Console.WriteLine(result);
}

static string CheckIsValid(int[] ships)
{
    int[] count = new int[5];

    foreach (int ship in ships)
        count[ship]++;

    var result = ((count[1] == 4) && (count[2] == 3) && (count[3] == 2) && (count[1] == 4)) ? "Yes" : "No";
    return result;
}