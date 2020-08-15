using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame.Cards
{
    class Card : IComparable
    {
        public enum TypeSuit
        {
            Diamonds,   //Бубны
            Hearts,     //Червы/черви
            Spades,     //Пики
            Clubs       //Трефы
        }
        public enum TypeValue
        {
            six,        //6
            seven,      //7
            eight,      //8
            nine,       //9
            ten,        //10
            jack,       //Валет
            lady,       //Дама
            king,       //Король
            ace         //Туз
        }

        public int Suit { get; set; }
        public int Value { get; set; }

        public static bool operator >(Card first, Card second)
        {
            return first.Value > second.Value;
        }
        public static bool operator <(Card first, Card second)
        {
            return first.Value < second.Value;
        }
        public static bool operator >=(Card first, Card second)
        {
            return first.Value >= second.Value;
        }
        public static bool operator <=(Card first, Card second)
        {
            return first.Value <= second.Value;
        }
        public static bool operator ==(Card first, Card second)
        {
            return first.Value == second.Value;
        }
        public static bool operator !=(Card first, Card second)
        {
            return first.Value != second.Value;
        }

        public override string ToString()
        {
            return new ShowCard(this).Show();
        }

        public int CompareTo(object obj)
        {
            Card other = obj as Card;

            if(other is null)
            {
                return 1;
            }

            return Value.CompareTo(other.Value);
        }

        public override bool Equals(object obj)
        {
            return (obj as Card).Value == Value;
        }
    }
}
