using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame.Cards
{
    class Deck
    {
        public Card[] Cards { get; set; }
        public const int SIZE_DECK = 36;

        public Deck()
        {
            Cards = new Card[SIZE_DECK];
            Fill();
        }

        public Card this[int index]
        {
            get
            {
                return Cards[index];
            }
        }

        private void Fill()
        {
            int idx = 0;

            for (int i = (int)Card.TypeSuit.Diamonds; i <= (int)Card.TypeSuit.Clubs; ++i)
            {
                for (int j = (int)Card.TypeValue.six; j <= (int)Card.TypeValue.ace; ++j)
                {
                    Cards[idx++] = new Card
                    {
                        Suit = i,
                        Value = j
                    };
                }
            }
        }
        public void Show()
        {
            for(int i = 0; i < SIZE_DECK; ++i)
            {
                Console.WriteLine(Cards[i]);
                Console.WriteLine("---------------------------------------------");
            }
        }

        public void Shuffle()
        {          
            for(int i = 0; i < 50; ++i)
            {                
                Swap(new Random().Next(36), new Random().Next(36));
            }
        }
        private void Swap(int arg_1, int arg_2)
        {
            Card buff = Cards[arg_1];
            Cards[arg_1] = Cards[arg_2];
            Cards[arg_2] = buff;
        }
    }
}
