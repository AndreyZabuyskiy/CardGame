using System;
using CardGame.Cards;
using System.Collections.Generic;
using CardGame.Players;
using CardGame.Games;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            new Game().Start();
        }
    }
}
