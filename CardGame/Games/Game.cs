using System;
using System.Collections.Generic;
using System.Text;
using CardGame.Players;
using CardGame.Cards;

namespace CardGame.Games
{
    class Game
    {
        public Player Player_1 { get; set; } = new Player();
        public Player Player_2 { get; set; } = new Player();
        public Deck Deck { get; set; } = new Deck();

        public void Start()
        {
            ConfigureDefaultSettings();

            while (true)
            {
                CheckVictory();             

                switch (GetCommand())
                {
                    case 0:
                        return;

                    case 1:
                        CompareCards();
                        break;

                    case 2:
                        SimulateGame();
                        break;
                }
            }
        }

        private void FillPlayer_1()
        {
            for (int i = 0; i < Deck.SIZE_DECK / 2; ++i)
            {
                Player_1.Cards.Enqueue(Deck[i]);
            }
        }
        private void FillPlayer_2()
        {
            for (int i = Deck.SIZE_DECK / 2; i < Deck.SIZE_DECK; ++i)
            {
                Player_2.Cards.Enqueue(Deck[i]);
            }
        }

        private void ConfigureDefaultSettings()
        {
            Deck.Shuffle();
            FillPlayer_1();
            FillPlayer_2();
        }
        private void PrintField()
        {
            Console.Clear();
            Console.WriteLine($"Счет: {Player_1.Score} : {Player_2.Score}\n");
            Console.WriteLine("Первый игрок:\t\t\t\tВторой игрок:");
            Console.WriteLine($"Количество карт: {Player_1.Cards.Count}\t\t\tКоличество карт: {Player_2.Cards.Count}\n");
            Console.WriteLine($"{Player_1.PrintCurrentCard()}\t\t\t{Player_2.PrintCurrentCard()}\n");
        }
        private void PrintMenu()
        {
            Console.Write("[1] Следующий ход;\n" +
                "[2] Симулировать игру;\n" +
                "[0] Выход\n" + "->");
        }
        private int GetCommand()
        {
            PrintField();
            PrintMenu();

            return GetIntValue();
        }
        private void SimulateGame()
        {
            while (true)
            {
                if (Player_1.Cards.Count != 36 && Player_2.Cards.Count != 36)
                {
                    PrintField();
                    CompareCards();
                    System.Threading.Thread.Sleep(250);
                }
                else
                {
                    break;
                }
            }
        }

        private void CompareCards()
        {
            if (Player_1.PrintCurrentCard().Value == (int)Card.TypeValue.six && Player_2.PrintCurrentCard().Value == (int)Card.TypeValue.ace)
            {
                Player_1.DrawCard(Player_2.GiveCard());
            }
            else if (Player_1.PrintCurrentCard().Value == (int)Card.TypeValue.ace && Player_2.PrintCurrentCard().Value == (int)Card.TypeValue.six)
            {
                Player_2.DrawCard(Player_1.GiveCard());
            }
            else if (Player_1.PrintCurrentCard() >= Player_2.PrintCurrentCard())
            {
                Player_1.DrawCard(Player_2.GiveCard());
            }
            else
            {
                Player_2.DrawCard(Player_1.GiveCard());
            }
        }

        private void CheckVictory()
        {
            if (Player_1.Cards.Count == 36)
            {
                Player_1.Score++;
                Player_1.Cards.Clear();
                Console.Clear();
                Console.WriteLine("Победил игрок 1;");
                ConfigureDefaultSettings();
                Console.ReadLine();
            }
            else if (Player_2.Cards.Count == 36)
            {
                Player_2.Score++;
                Player_2.Cards.Clear();
                Console.Clear();
                Console.WriteLine("Победил игрок 2;");
                ConfigureDefaultSettings();
                Console.ReadLine();
            }
        }

        private int GetIntValue()
        {
            while(true)
            {
                try
                {
                    return int.Parse(Console.ReadLine());
                }
                catch(FormatException)
                {
                    Console.WriteLine("Повторите ввод!");
                }
            }
        }
    }
}
