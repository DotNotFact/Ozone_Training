int t = int.Parse(Console.ReadLine()); // 10

// string[] s1 = {
//    "10 9 2022",
//    "21 9 2022",
//    "29 2 2022",
//    "31 2 2022",
//    "29 2 2000",
//    "29 2 2100",
//    "31 11 1999",
//    "31 12 1999",
//    "29 2 2024",
//    "29 2 2023"
// };

for (int i = 0; i < t; i++)
{
    string[] temp = Console.ReadLine().Split(' ');
    int[] date = temp.Select(int.Parse).ToArray();

    bool isDateValid = IsValidDate(date[0], date[1], date[2]);

    Console.WriteLine(isDateValid ? "Yes" : "No");
}

static bool IsValidLeapYear(int y)
{
    return ((y % 4 == 0) && (y % 100 != 0)) || (y % 400 == 0);
}

static bool IsValidDate(int d, int m, int y)
{
    if (((d < 1) && (d > 31)) && ((m < 1) && (m > 12)) && ((y < 1950) && (y > 2300)))
        return false;

    if (m == 2)
        return d <= (IsValidLeapYear(y) ? 29 : 28);

    if ((m == 4) || (m == 6) || (m == 9) || (m == 11))
        return d <= 30;

    return true;
}