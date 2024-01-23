// int.TryParse(Console.ReadLine(), out int size); 
var size = int.Parse(Console.ReadLine());

for (int i = 0; i < size; i++)
{
    string[] ships = Console.ReadLine().Split(' ');
    int[] field = Array.ConvertAll(ships, int.Parse);
    Console.WriteLine(CheckIsValid(field));
}

static string CheckIsValid(int[] ships)
{
    int[] count = new int[5];

    foreach (int ship in ships)
        count[ship]++;

    var result = (count[1] == 4) && (count[2] == 3) && (count[3] == 2) && (count[1] == 4) ? "Yes" : "No";
    return result;
}