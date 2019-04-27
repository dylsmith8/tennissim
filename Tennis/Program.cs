using System;
using TennisSimulator;
using TennisSimulator.Helpers;

namespace Tennis
{
    class Program
    {
        static void Main(string[] args)
        {
            IMatchParameters parameters = new MatchParameters(3);
            Match match = new Match(parameters);           

            Console.WriteLine(match.Play());
            Console.ReadLine();
        }
    }
}
