using System;
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

            IMatchParameters parameters = new MatchParameters(3);
            Match match = new Match(parameters);           

            Console.WriteLine(match.Play());
            Console.ReadLine();
        }
    }
}
