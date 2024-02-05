using System;
using System.Reflection;
using System.Threading;
using Attacks;
using Entities;

namespace Helpful
{
    static class Utility
    {
        public static int GenerateRandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        public static void WriteTimeClear(string phrase, int time, bool firstClear = false, bool finalClear = false)
        {
            if (firstClear)
            { Console.Clear(); }
            Console.WriteLine(phrase);
            Thread.Sleep(time);
            if (finalClear) { Console.Clear(); }
        }
        public static List<Attacks.Attacks> CreatingAttackLists(Attacks.Attacks wantedAttack1, Attacks.Attacks wantedAttack2 = null, Attacks.Attacks wantedAttack3 = null, Attacks.Attacks wantedAttack4 = null, Attacks.Attacks wantedAttack5 = null, Attacks.Attacks wantedAttack6 = null, Attacks.Attacks wantedAttack7 = null, Attacks.Attacks wantedAttack8 = null, Attacks.Attacks wantedAttack9 = null, Attacks.Attacks wantedAttack10 = null)
        {
            Attacks.Attacks[] wantedAttacks = { wantedAttack1, wantedAttack2, wantedAttack3, wantedAttack4, wantedAttack5, wantedAttack6, wantedAttack7, wantedAttack8, wantedAttack9, wantedAttack10 };
            List<Attacks.Attacks> attacksList = new List<Attacks.Attacks>();
            foreach (Attacks.Attacks attack in wantedAttacks)
            {
                if (attack != null) { attacksList.Add(attack); }
            }
            return attacksList;
        }
    }
}