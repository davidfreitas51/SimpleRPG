using Places;
using Combat;
using Entities;
using Helpful;
using System.Collections.Generic;

namespace Simple_RPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Attacks.Attacks swordAttack = new Attacks.Attacks(20, 75, "swing the sword in attack!", "Sword atk.");
            Attacks.Attacks kickAttack = new Attacks.Attacks(20, 75, "unleash magical energy and attacks with a spell!", "Magic atk.");
            Attacks.Attacks freezingRay = new Attacks.AttackEffect(0, 100, "channel icy power, casting a freezing ray!", "Freezing Ray", "It freezes the opponent!", 1, "frozen");
            Attacks.Attacks stunningRay = new Attacks.AttackEffect(0, 0, "channel a storm!", "Stunning Ray", "It stuns the opponent", 2, "stunned");

            List<Attacks.Attacks> playerAttack = Helpful.Utility.CreatingAttackLists(swordAttack, kickAttack, stunningRay);
            Player player = new Player(100, 100, 0, playerAttack, "Player");

            List<Attacks.Attacks>  stoneGuardianAttacks = Helpful.Utility.CreatingAttackLists(freezingRay);
            Monster stoneGuardian = new Monster(100, 100, Helpful.Utility.GenerateRandomNumber(80, 160), stoneGuardianAttacks, "Stone Guardian", "The earth trembles beneath an approaching monster..", "A stone creature strides purposefully toward you!!");

            List<Monster> dungeonEntities = new List<Monster>();
            dungeonEntities.Add(stoneGuardian);

            Fight.Combat(player, stoneGuardian);
            //Places.Places.Dungeon(player, dungeonEntities);

            Console.WriteLine("This is a test!!");
        }
    }
}
