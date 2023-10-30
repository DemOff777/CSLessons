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

            CardDeck playDeck  = new CardDeck();

            Players players = new Players();

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
                        players.TakePlayerCards(players.TryTakePlayer(), playDeck.TryGiveCard());
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
                }
            }
        }
    }

    class Player
    {       
        public Player(string playersName, List<Card> cardsInHand)
        {
            PlayerName = playersName;
            CardsInHand = cardsInHand;
        }

        public string PlayerName { get; private set; }
        public List<Card> CardsInHand { get; private set; } = new List<Card>();

        public void ShowPlayerData()
        {
            Console.WriteLine($"Имя игрока - {PlayerName}");
            
            if( CardsInHand.Count > 0)
            {
                Console.WriteLine($"В руке находятся карты:");

                foreach (Card card in CardsInHand)
                {
                    card.ShowCard();
                }
            }
            else
            {
                Console.WriteLine("Карты в руке отсутствуют");
            }
        }
    }

    class Players
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
                player.ShowPlayerData();
            }
        }

        public string TryTakePlayer()
        {
            Console.WriteLine("Введите имя игрока");

            string playerNameInput;

            bool isPlayerTaked = false;

            playerNameInput = Console.ReadLine();

            for (int i = 0; i < _players.Count; i++)
            {
                if (_players[i].PlayerName.ToLower() == playerNameInput.ToLower())
                {
                    playerNameInput = _players[i].PlayerName;
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
                if (_players[i].PlayerName == playerName)
                {
                    _players[i].CardsInHand.AddRange(cards);
                }
            }
        }
    }

    class CardDeck
    {
        List<Card> _cardDeck = new List<Card>();

        public void FillDeck()
        {
            _cardDeck.Add(new Card("Шестерка Треф"));
            _cardDeck.Add(new Card("Семерка Треф"));
            _cardDeck.Add(new Card("Восьмерка Треф"));
            _cardDeck.Add(new Card("Девятка Треф"));
            _cardDeck.Add(new Card("Десятка Треф"));
            _cardDeck.Add(new Card("Валет Треф"));
            _cardDeck.Add(new Card("Дама Треф"));
            _cardDeck.Add(new Card("Король Треф"));
            _cardDeck.Add(new Card("Туз Треф"));
            _cardDeck.Add(new Card("Шестерка Пик"));
            _cardDeck.Add(new Card("Семерка Пик"));
            _cardDeck.Add(new Card("Восьмерка Пик"));
            _cardDeck.Add(new Card("Девятка Пик"));
            _cardDeck.Add(new Card("Десятка Пик"));
            _cardDeck.Add(new Card("Валет Пик"));
            _cardDeck.Add(new Card("Дама Пик"));
            _cardDeck.Add(new Card("Король Пик"));
            _cardDeck.Add(new Card("Туз Пик"));
            _cardDeck.Add(new Card("Шестерка Червей"));
            _cardDeck.Add(new Card("Семерка Червей"));
            _cardDeck.Add(new Card("Восьмерка Червей"));
            _cardDeck.Add(new Card("Девятка Червей"));
            _cardDeck.Add(new Card("Десятка Червей"));
            _cardDeck.Add(new Card("Валет Червей"));
            _cardDeck.Add(new Card("Дама Червей"));
            _cardDeck.Add(new Card("Король Червей"));
            _cardDeck.Add(new Card("Туз Червей"));
            _cardDeck.Add(new Card("Шестерка Бубей"));
            _cardDeck.Add(new Card("Семерка Бубей"));
            _cardDeck.Add(new Card("Восьмерка Бубей"));
            _cardDeck.Add(new Card("Девятка Бубей"));
            _cardDeck.Add(new Card("Десятка Бубей"));
            _cardDeck.Add(new Card("Валет Бубей"));
            _cardDeck.Add(new Card("Дама Бубей"));
            _cardDeck.Add(new Card("Король Бубей"));
            _cardDeck.Add(new Card("Туз Бубей"));
        }

        public void MixDeck()
        {
            Random random = new Random();

            Card temporaryCardRank;

            int temporaryCardIndex;

            for (int i = 0; i < _cardDeck.Count; i++)
            {
                temporaryCardRank = _cardDeck[i];
                temporaryCardIndex = random.Next(_cardDeck.Count);
                _cardDeck[i] = _cardDeck[temporaryCardIndex];
                _cardDeck[temporaryCardIndex] = temporaryCardRank;
            }
        }

        public void ShowDeck()
        {
            foreach (Card card in _cardDeck)
            {
                card.ShowCard();
            }
        }

        public List<Card> TryGiveCard()
        {
            List<Card> cards = new List<Card>();

            Console.WriteLine("Введите количество забираемых из колоды карт");
            
            int.TryParse(Console.ReadLine(), out int userInput);

            if (_cardDeck.Count >= userInput)
            {
                for (int i = 0; i < userInput; i++)
                {
                    cards.Add(_cardDeck[0]);
                    _cardDeck.RemoveAt(0);
                }
            }
            else
            {
                Console.WriteLine("Недостаточно карт");
            }

            return cards;
        }
    }
    
    class Card
    {
        private string _rank;

        public Card(string rank)
        {
            _rank = rank;
        }

        public void ShowCard()
        {
            Console.WriteLine($"|{_rank}|");
        }
    }
}
