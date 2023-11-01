using System;
using System.Collections.Generic;

namespace Задание6_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandTakePlayer = "1";
            const string CommandAddPlayer = "2";
            const string CommandShowPlayers = "3";
            const string CommandShowDeck = "4";
            const string CommandExit = "5";

            Deck playDeck  = new Deck();

            GamingTable players = new GamingTable();

            playDeck.FillDeck();
            playDeck.MixDeck();

            bool isWork = true;
            bool isFirstRun = true;

            while (isWork)
            {
                if (isFirstRun)
                {
                    isFirstRun = false;
                    players.AddPlayer();
                }
                   
                Console.WriteLine($"Взять карты игроку - {CommandTakePlayer}");
                Console.WriteLine($"Добавить игрока - {CommandAddPlayer}");
                Console.WriteLine($"Показать всех игроков - {CommandShowPlayers}");
                Console.WriteLine($"Показать колоду - {CommandShowDeck}");
                Console.WriteLine($"Выход - {CommandExit}");
                string userInput = Console.ReadLine();

                switch(userInput)
                {
                    case(CommandTakePlayer):
                        players.TakePlayerCards(players.TryTakePlayer(), playDeck.TryGiveCards());
                        break;
                    case(CommandAddPlayer):
                        players.AddPlayer();
                        break;
                    case(CommandShowPlayers):
                        players.ShowPlayers();
                        break;
                    case (CommandShowDeck):
                        playDeck.ShowDeck();
                        break;
                    case (CommandExit):
                        isWork = false; 
                        break;
                    default:
                        Console.WriteLine("Неверный формат ввода");
                        break;
                }
            }
        }
    }

    public class Player
    {
        private List<Card> _cardsInHand;

        public Player(string playersName, List<Card> cardsInHand)
        {
            Name = playersName;
            _cardsInHand = cardsInHand;
        }

        public string Name { get; private set; }       

        public void ShowData()
        {
            Console.WriteLine($"Имя игрока - {Name}");
            
            if( _cardsInHand.Count > 0)
            {
                Console.WriteLine($"В руке находятся карты:");

                foreach (Card card in _cardsInHand)
                {
                    card.ShowCard();
                }
            }
            else
            {
                Console.WriteLine("Карты в руке отсутствуют");
            }
        }

        public void TakeCards(List<Card> cards)
        {
            _cardsInHand = cards;
        }
    }

    public class GamingTable
    {
        List<Player> _players = new List<Player>();

        public void AddPlayer()
        {
            Console.WriteLine("Введите имя игрока");
            string userName = Console.ReadLine();
            _players.Add(new Player(userName, new List<Card>()));
        }

        public void ShowPlayers()
        {
            foreach (Player player in _players)
            {
                player.ShowData();
            }
        }

        public string TryTakePlayer()
        {
            ShowPlayers();

            Console.WriteLine("Введите имя игрока");

            string playerNameInput;

            bool isPlayerTaked = false;

            playerNameInput = Console.ReadLine();

            for (int i = 0; i < _players.Count; i++)
            {
                if (_players[i].Name.ToLower() == playerNameInput.ToLower())
                {
                    playerNameInput = _players[i].Name;
                    isPlayerTaked = true;
                }
            }

            if (isPlayerTaked == false)
            {
                Console.WriteLine("Имя не найдено");
            }

            return playerNameInput;
        }

        public void TakePlayerCards(string playerName, List<Card> cards)
        {
            for (int i = 0; i < _players.Count; i++)
            {
                if (_players[i].Name == playerName)
                {
                    _players[i].TakeCards(cards);
                }
            }
        }
    }

    public class Deck
    {
        List<Card> _cards = new List<Card>();

        public void FillDeck()
        {
            string six = "Шестерка";
            string seven = "Семерка";
            string eigth = "Восьмерка";
            string nine = "Девятка";
            string ten = "Десятка";
            string jack = "Валет";
            string queen = "Дама";
            string king = "Король";
            string ace = "Туз";
            string clubs = "Треф";
            string diamonds = "Бубей";
            string hearts = "Червей";
            string spades = "Пик";

            _cards.Add(new Card(six, clubs));
            _cards.Add(new Card(seven, clubs));
            _cards.Add(new Card(eigth, clubs));
            _cards.Add(new Card(nine, clubs));
            _cards.Add(new Card(ten, clubs));
            _cards.Add(new Card(jack, clubs));
            _cards.Add(new Card(queen, clubs));
            _cards.Add(new Card(king, clubs));
            _cards.Add(new Card(ace, clubs));
            _cards.Add(new Card(six, diamonds));
            _cards.Add(new Card(seven, diamonds));
            _cards.Add(new Card(eigth, diamonds));
            _cards.Add(new Card(nine, diamonds));
            _cards.Add(new Card(ten, diamonds));
            _cards.Add(new Card(jack, diamonds));
            _cards.Add(new Card(queen, diamonds));
            _cards.Add(new Card(king, diamonds));
            _cards.Add(new Card(ace, diamonds));
            _cards.Add(new Card(six, hearts));
            _cards.Add(new Card(seven, hearts));
            _cards.Add(new Card(eigth, hearts));
            _cards.Add(new Card(nine, hearts));
            _cards.Add(new Card(ten, hearts));
            _cards.Add(new Card(jack, hearts));
            _cards.Add(new Card(queen, hearts));
            _cards.Add(new Card(king, hearts));
            _cards.Add(new Card(ace, hearts));
            _cards.Add(new Card(six, spades));
            _cards.Add(new Card(seven, spades));
            _cards.Add(new Card(eigth, spades));
            _cards.Add(new Card(nine, spades));
            _cards.Add(new Card(ten, spades));
            _cards.Add(new Card(jack, spades));
            _cards.Add(new Card(queen, spades));
            _cards.Add(new Card(king, spades));
            _cards.Add(new Card(ace, spades));
        }

        public void MixDeck()
        {
            Random random = new Random();

            Card temporaryCardRank;

            int temporaryCardIndex;

            for (int i = 0; i < _cards.Count; i++)
            {
                temporaryCardRank = _cards[i];
                temporaryCardIndex = random.Next(_cards.Count);
                _cards[i] = _cards[temporaryCardIndex];
                _cards[temporaryCardIndex] = temporaryCardRank;
            }
        }

        public void ShowDeck()
        {
            foreach (Card card in _cards)
            {
                card.ShowCard();
            }
        }

        public List<Card> TryGiveCards()
        {
            List<Card> cards = new List<Card>();

            Console.WriteLine("Введите количество забираемых из колоды карт");
            
            int.TryParse(Console.ReadLine(), out int userInput);

            if (_cards.Count >= userInput)
            {
                for (int i = 0; i < userInput; i++)
                {
                    cards.Add(_cards[0]);
                    _cards.RemoveAt(0);
                }
            }
            else
            {
                Console.WriteLine("Недостаточно карт");
            }

            return cards;
        }
    }
    
    public class Card
    {
        private string _rank;
        private string _suite;

        public Card(string rank, string suite)
        {
            _rank = rank;
            _suite = suite;
        }

        public void ShowCard()
        {
            Console.WriteLine($"|{_rank}|");
        }
    }
}
