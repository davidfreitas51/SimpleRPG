using Places;
using Combat;
using Entities;
using Helpful;
using System;

namespace Simple_RPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Attacks.Attacks swordAttack = new Attacks.Attacks(15, 85, "swing the sword in attack!", "Sword atk.");
            Attacks.Attacks magicAttack = new Attacks.Attacks(25, 75, "unleash magical energy and attacks with a spell!", "Magic atk.");
            Attacks.Attacks freezingRay = new Attacks.AttackEffect(0, 50, "channel icy power, casting a freezing ray!", "Freezing Ray", "It freezes the opponent!", 1, "frozen");
            Attacks.Attacks stunningRay = new Attacks.AttackEffect(0, 50, "channel a storm!", "Stunning Ray", "It stuns the opponent", 2, "stunned");
            Attacks.Attacks shadowsSpeed = new Attacks.AttackEffect(10, 75, "strikes with swift shadow kicks", "Shadow Speed", "It keeps attacking!", 3, "");
            Attacks.Attacks arcaneCrush = new Attacks.AttackEffect(1, 80, "starts casting a powerful spell", "Arcane Crush", "It starts casting a powerful spell", 4, "");
            List<Attacks.Attacks> playerAttack = Helpful.Utility.CreatingAttackLists(swordAttack, magicAttack);
            List<Attacks.Attacks> stoneGuardianAttacks = Helpful.Utility.CreatingAttackLists(arcaneCrush);

            Player player = new Player(100, 100, playerAttack, "Player", 0);
            Monster stoneGuardian = new Monster(100, 1, stoneGuardianAttacks, "Stone Guardian", "The earth trembles beneath an approaching monster..", "A stone creature strides purposefully toward you!!", Helpful.Utility.GenerateRandomNumber(80, 160));

            List<Monster> dungeonEntities = new List<Monster>();
            dungeonEntities.Add(stoneGuardian);
            Fight.Combat(player, stoneGuardian);
            while (true)
            {
                Console.WriteLine($"Where you wanna go?\n-----------------------------\n   1 - Dungeon | 2 - Hospital\n3 - Blacksmith | 4 - Cave\n-----------------------------\nHP: {player.MaxHealth}/{player.CurrentHealth} | Money: {player.Money}");
                string responseMenu = Console.ReadLine();
                switch (responseMenu)
                {
                    case "1":
                        Places.Places.Dungeon(player, dungeonEntities);
                        break;
                    case "2":
                        Places.Places.Hospital(player);
                        break;
                    case "3":
                        Places.Places.Blacksmith(player);
                        break;
                    case "4":
                        break;
                    default:
                        Helpful.Utility.WriteTimeClear("Opção inválida!", 2000, false, true);
                        break;
                }
            }
        }
    }
}
