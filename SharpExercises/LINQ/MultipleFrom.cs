using System;
using System.Collections.Generic;
using System.Linq;

namespace SharpExercises.LINQ
{
    internal class MultipleFrom
    {
        private static readonly char[] Figures = "23456789TJQKA".ToCharArray();
        private static readonly char[] Suites = "SHDC".ToCharArray();

        public static void LinqSyntax()
        {
            var cards = from fig in Figures from su in Suites select fig.ToString() + su;

            PrintCards(cards);
        }
        
        public static void MethodSyntax()
        {
            var cards = Figures.SelectMany(c => Suites, (fig, su) => fig.ToString() + su);

            PrintCards(cards);
        }

        private static void PrintCards(IEnumerable<string> cards)
        {
            foreach (var card in cards)
            {
                Console.WriteLine(card);
            }
        }
    }
}
