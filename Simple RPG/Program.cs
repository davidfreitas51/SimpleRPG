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
            Attacks.Attacks swordAttack = new Attacks.Attacks(150, 85, "swing the sword in attack!", "Sword atk.");
            Attacks.Attacks magicAttack = new Attacks.Attacks(25, 75, "unleash magical energy and attacks with a spell!", "Magic atk.");
            Attacks.Attacks stunningRay = new Attacks.AttackEffect(0, 50, "channel a storm!", "Stunning Ray", "It stuns the opponent", 2, "stunned");
            Attacks.Attacks freezingRay = new Attacks.AttackEffect(0, 50, "channel icy power, casting a freezing ray!", "Freezing Ray", "It freezes the opponent!", 1, "frozen");
            Attacks.Attacks shadowsSpeed = new Attacks.AttackEffect(10, 75, "strikes with swift shadow kicks", "Shadow Speed", "It keeps attacking!", 3, "");
            
            List<Attacks.Attacks> playerAttack = Helpful.Utility.CreatingAttackLists(swordAttack, magicAttack);
            List<Attacks.Attacks> stoneGuardianAttacks = Helpful.Utility.CreatingAttackLists(swordAttack);
            List<Attacks.Attacks> shadowStalkerAttacks = Helpful.Utility.CreatingAttackLists(swordAttack);
            List<Attacks.Attacks> embergeistAttacks = Helpful.Utility.CreatingAttackLists(swordAttack);

            Player player = new Player(100, 100, playerAttack, "Player", 0);
            Monster stoneGuardian = new Monster(100, 100, stoneGuardianAttacks, "Stone Guardian", "The earth trembles beneath an approaching monster..", "A stone creature strides purposefully towards you!!", Helpful.Utility.GenerateRandomNumber(80, 160));
            Monster shadowStalker = new Monster(100, 100, shadowStalkerAttacks, "Shadow Stalker", "You witness your own shadow expanding...", "An unsettling dark figure forms in front of you!", Helpful.Utility.GenerateRandomNumber(80, 160));
            Monster embergeist = new Monster(100, 100, embergeistAttacks, "Embergeist", "Your torch unexpectedly flares, making you to drop it.", "The flame creates a tornado of a fiery beast!", Helpful.Utility.GenerateRandomNumber(80, 160));

            List<Monster> dungeonEntities = new List<Monster>();
            dungeonEntities.Add(stoneGuardian);
            dungeonEntities.Add(shadowStalker);
            dungeonEntities.Add(embergeist);
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
                        Places.Places.Cave(player, stoneGuardian);
                        break;
                    default:
                        Helpful.Utility.WriteTimeClear("Opção inválida!", 2000, false, true);
                        break;
                }
            }
        }
    }
}
