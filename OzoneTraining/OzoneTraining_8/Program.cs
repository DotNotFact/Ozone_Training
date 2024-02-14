// 2
// TD
// TH

// 0

// 3
// 7S
// 7C
// 7D

// 0

internal class Poker
{
    private static void Main(string[] args)
    {
        int t = 4; // int.Parse(Console.ReadLine());

        // 2 3 4 5 6 7 8 9 T J Q K A 
        // S C D H

        var strings = new List<string[]>
        {
            new[] { "TS TC", "AD AH" },
            new[] { "2H 3H", "9S 9C", "4D QS" },
            new[] { "4C 7H", "4H 4D", "6S 6H" },
            new[] { "2S 3H", "2C 2D", "3C 3D" },
        };

        for (int i = 0; i < t; i++)
        {
            int n = strings[i].Length; // int.Parse(Console.ReadLine());

            var pokerPlayers = new List<PokerPlayer>();

            for (int j = 0; j < n; j++)
            {
                string[] s = strings[i][j].Split(' '); // Console.ReadLine().Split(' ');

                for (int v = 0; v < s.Length; v++)
                    pokerPlayers.Add(new PokerPlayer(new Card(s[v][0], s[v][1])));
            }

            var possibleCards = GetPossibleCards(pokerPlayers);
            Console.WriteLine(possibleCards.Count);

            foreach (Card card in possibleCards)
                Console.WriteLine(card.ToString());
        }

        static List<Card> GetPossibleCards(List<PokerPlayer> cards)
        {
            var possibleCards = new List<Card>(); 

            // Проверяем, можем ли мы выложить сет
            int count = 0;

            for (int i = 0; i < cards.Count; i++)
                if (cards[0].Cards[0].Value == cards[i].Cards[i].Value)
                    count++;

            if (count == 3)
                possibleCards.Add(new Card(cards[0].Cards[0].Value, cards[0].Cards[0].Suit));

            // Проверяем, можем ли мы выложить пару
            for (int i = 0; i < cards.Count; i++)
                if (cards[0].Cards[0].Value == cards[i].Cards[i].Value)
                    possibleCards.Add(cards[i].Cards[i]);

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
                char first = cards[i].Value;

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
    }
}

internal class PokerPlayer
{
    public List<Card> Cards { get; set; } = new();

    public PokerPlayer(Card card)
    {
        Cards.Add(card);
    }
}

internal class Card
{
    public char Value;
    public char Suit;

    public Card(char value, char suit)
    {
        Value = value;
        Suit = suit;
    }

    public override string ToString()
    {
        return $"{Value}{Suit}";
    }
}
