using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame.Cards
{
    class ShowCard
    {
        public Dictionary<int, string> StrValue { get; set; } = new Dictionary<int, string>
        {
            { (int)Card.TypeValue.six, "Шестерка" },
            { (int)Card.TypeValue.seven, "Семерка" },
            { (int)Card.TypeValue.eight, "Восьмерка" },
            { (int)Card.TypeValue.nine, "Девятка" },
            { (int)Card.TypeValue.ten, "Десятка" },
            { (int)Card.TypeValue.jack, "Валет" },
            { (int)Card.TypeValue.lady, "Дама" },
            { (int)Card.TypeValue.king, "Король" },
            { (int)Card.TypeValue.ace, "Туз" }
        };
        public Dictionary<int, string> StrSuit { get; set; } = new Dictionary<int, string>
        {
            {(int)Card.TypeSuit.Diamonds, "Бубна" },
            {(int)Card.TypeSuit.Hearts, "Черва" },
            {(int)Card.TypeSuit.Spades, "Пика" },
            {(int)Card.TypeSuit.Clubs, "Трефа" }
        };
        public Card card { get; set; }

        public ShowCard(Card _card)
        {
            card = _card;
        }

        public string Show()
        {
            return $"{StrValue[card.Value]} ({StrSuit[card.Suit]})";
        }
    }
}
