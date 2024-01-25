using System.Text.RegularExpressions;

int t = int.Parse(Console.ReadLine()); // 6

//string[] s1 = {
//    "R48FAO00OOO0OOA99OKA99OK" ,
//    "R48FAO00OOO0OOA99OKA99O",
//    "A9PQ",
//    "A9PQA",
//    "A99AAA99AAA99AAA99AA",
//    "AP9QA",
//};

for (int i = 0; i < t; i++)
{
    string s = Console.ReadLine();
    string result = CheckAutoNumber(s);

    Console.WriteLine(result);
}

static string CheckAutoNumber(string s)
{
    string pattern = @"([A-Z][0-9]{2}[A-Z]{2})|([A-Z][0-9][A-Z]{2})";
    MatchCollection matches = Regex.Matches(s, pattern);

    string result = string.Empty;

    foreach (Match match in matches.Cast<Match>())
        result += match.Value + " ";

    return result.Replace(" ", "") == s ? result : "-";
}