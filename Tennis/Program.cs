using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisSimulator;
using TennisSimulator.Helpers;

namespace Tennis
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initial assumptions:

            // 1. Only two players (i.e. singles match)
            // 2. Does not take into account who 'serves'
            // 3. Random player wins a rally

            MatchParameters parameters = new MatchParameters();
            Game game = new Game();

            Console.WriteLine(game.Play(parameters));

            Console.ReadLine();
        }
    }
}
