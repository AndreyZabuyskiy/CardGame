using System;
using System.Collections.Generic;
using System.Text;
using CardGame.Cards;

namespace CardGame.Players
{
    class Player
    {
        public Queue<Card> Cards { get; set; } = new Queue<Card>();
        public int Score { get; set; }

        public void DrawCard(Card card)
        {
            Cards.Enqueue(Cards.Dequeue());
            Cards.Enqueue(card);
        }
        public Card PrintCurrentCard()
        {
            return Cards.Peek();
        }
        public Card GiveCard()
        {
            return Cards.Dequeue();
        }
    }
}
