using Places;
using Combat;
using Entities;
using Helpful;

namespace Simple_RPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Attacks.Attacks swordAttack = new Attacks.Attacks(200, 75, "swing the sword in attack!", "Sword atk.");
            Attacks.Attacks kickAttack = new Attacks.Attacks(20, 75, "unleash magical energy and attacks with a spell!", "Magic atk.");
            Attacks.Attacks freezingRay = new Attacks.AttackEffect(0, 50, "channel icy power, casting a freezing ray!", "Freezing Ray", "It freezes the opponent!", 1, "frozen");
            Attacks.Attacks stunningRay = new Attacks.AttackEffect(0, 50, "channel a storm!", "Stunning Ray", "It stuns the opponent", 2, "stunned");

            List<Attacks.Attacks> playerAttack = Helpful.Utility.CreatingAttackLists(swordAttack, kickAttack, stunningRay);
            List<Attacks.Attacks> stoneGuardianAttacks = Helpful.Utility.CreatingAttackLists(freezingRay, swordAttack, kickAttack);

            Player player = new Player(1000, 100, 0, playerAttack, "Player");
            Monster stoneGuardian = new Monster(1000, 100, Helpful.Utility.GenerateRandomNumber(80, 160), stoneGuardianAttacks, "Stone Guardian", "The earth trembles beneath an approaching monster..", "A stone creature strides purposefully toward you!!");

            List<Monster> dungeonEntities = new List<Monster>();
            dungeonEntities.Add(stoneGuardian);
            while (true)
            {
                Console.WriteLine("Where you wanna go?\n-----------------------------\n   1 - Dungeon | 2 - Hospital\n3 - Blacksmith | 4 - Cave\n-----------------------------\n");
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
