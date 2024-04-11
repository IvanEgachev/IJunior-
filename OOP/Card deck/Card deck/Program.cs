using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;


namespace CardDeck
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            PLayer pLayer = new PLayer();

            Card card = new Card();

            card.ShowCard(deck.TakeCard());
           
        }
    }

    enum Cards
    {
        Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace
    }

    enum Suits
    {
        Hearts = 3, Spades = 6, Diamonds = 4, Clubs = 5
    }

    class Card
    {
        public Cards _name;
        public Suits _suits;

        public Card(){}
        public Card(Cards name, Suits suits)
        {
            _name = name;
            _suits = suits;
        }

        public void ShowCard(Card card)
        {
            Console.WriteLine($"{card._name} {(char)card._suits}");
        }
    }

    class Deck
    {
        List<Card> _cards = new List<Card>();

        public Deck()
        {
            Generator();
            Shuffle();
        }

        List<Card> Generator()
        {
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    _cards.Add(new Card((Cards)i, (Suits)j));
                }
            }

            return _cards;
        }

        List<Card> Shuffle()
        {
            Random random = new Random();
            int index;
            Card tempCard;

            for (int i = 0; i < _cards.Count; i++)
            {
                index = random.Next(i);
                tempCard = _cards[i];
                _cards[i] = _cards[index];
                _cards[index] = tempCard;
            }

            return _cards;
        }

        public Card TakeCard()
        {
            return _cards[0];
        }
    }

    class PLayer
    {
        List<Card> _cards = new List<Card>();

        public void ShowCards()
        {

            foreach (var item in _cards)
            {
                Console.WriteLine($"{item._name} {item._suits}");
            }
        }

       

    }
}