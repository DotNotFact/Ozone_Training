// 2
// TD
// TH

// 0

// 3
// 7S
// 7C
// 7D

// 0

int t = 4; // int.Parse(Console.ReadLine());

var strings = new List<string[]>
{
    new[] { "TS TC", "AD AH" },
    new[] { "2H 3H", "9S 9C", "4D QS" },
    new[] { "4C 7H", "4H 4D", "6S 6H" },
    new[] { "2S 3H", "2C 2D", "3C 3D" },
};

char[] suits = {
    'C',
    'D',
    'S',
    'H'
};

var chars = new HashSet<char>();

for (int i = 0; i < t; i++)
{
    int n = strings[i].Length; // int.Parse(Console.ReadLine());
    var cards = new List<Card>();

    for (int j = 0; j < n; j++)
    {
        string[] s = strings[i][j].Split(' '); // Console.ReadLine().Split(' ');
        cards.Add(new Card(s[0], s[1]));
    }

    var possibleCards = GetPossibleCards(cards, cards[0]);
    Console.WriteLine(possibleCards.Count);

    foreach (Card card in possibleCards)
        Console.WriteLine(card.ToString());
}

static List<Card> GetPossibleCards(List<Card> cards, Card myCard)
{
    var possibleCards = new List<Card>();

    // Проверяем, можем ли мы выложить сет
    int count = 0;

    for (int i = 0; i < cards.Count; i++)
        if (myCard.Value == cards[i].Value)
            count++;

    if (count == 3)
        possibleCards.Add(new Card(myCard.Value, myCard.Suit));

    // Проверяем, можем ли мы выложить пару
    for (int i = 0; i < cards.Count; i++)
        if (myCard.Value == cards[i].Value)
            possibleCards.Add(cards[i]);

    // Если ни сет, ни пара невозможны, выкладываем старшую карту
    if (possibleCards.Count == 0)
        possibleCards.Add(GetHighestCard(cards));

    return possibleCards;
}

static Card GetHighestCard(List<Card> cards)
{
    int maxValue = 0;
    // int temp = 0;
    Card maxCard = null;

    var keyValuePairs = new Dictionary<char, int>()
{
    { '2', 2 },
    { '3', 3 },
    { '4', 4 },
    { '5', 5 },
    { '6', 6 },
    { '7', 7 },
    { '8', 8 },
    { '9', 9 },
    { 'T', 10 },
    { 'J', 11 },
    { 'Q', 12 },
    { 'K', 13 },
    { 'A', 14 },
};

    for (int i = 0; i < cards.Count; i++)
    {
        char first = cards[i].Value[0];
        if (keyValuePairs.TryGetValue(first, out int temp))
        {
            temp = keyValuePairs[first];

            if (temp > maxValue)
            {
                maxValue = temp;
                maxCard = cards[i];
            }
        }
        else if (temp > maxValue)
        {
            maxValue = temp;
            maxCard = cards[i];
        }

    }
    return maxCard;
}

class Card
{ 
    public string Value;
    public string Suit;

    public Card(string value, string suit)
    {
        Value = value;
        Suit = suit;
    }

    public void Reverse()
    {

    }

    public override string ToString()
    {
        return $"{Value}{Suit}";
    }
}