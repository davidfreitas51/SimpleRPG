using Entities;
using Helpful;
using Combat;

namespace Places
{
    internal static class Places
    {
        public static void Dungeon(Player player, List<Monster> dungeonEntities)
        {
            Monster enemy = dungeonEntities[Helpful.Utility.GenerateRandomNumber(0, dungeonEntities.Count)];
            List<string> phrasesBeforeBattle = new List<string>();
            Console.Clear();
            phrasesBeforeBattle.AddRange(new[] { "You step into the ominous depths of the dungeons..", "Suddenly, a noise catches your attention..", enemy.presentingPhrase1, enemy.presentingPhrase2 });
            foreach (string phrase in phrasesBeforeBattle) { Helpful.Utility.WriteTimeClear(phrase, 3000); }
            Fight.Combat(player, enemy);
        }
        public static void Hospital(Player player)
        {
            while (true)
            {
                Helpful.Utility.WriteTimeClear($"Hospital\n\nGreetings! What you wanna do?\n-----------------\nYour HP: {player.MaxHealth}/{player.CurrentHealth}\n-----------------\n1 - Heal (10 gold) | 2 - Exit\n", 0, true);
                string responseHospital = Console.ReadLine();
                if (responseHospital == "1")
                {
                    Helpful.Utility.WriteTimeClear("Okay, here...", 3000, true);
                    Helpful.Utility.WriteTimeClear("You are healed now!", 2000);
                    player.Money -= 10;
                    player.CurrentHealth = player.MaxHealth;
                }
                else if (responseHospital == "2")
                {
                    Helpful.Utility.WriteTimeClear("Okay, see you...", 2000, false, true);
                    break;
                }
                else { Helpful.Utility.WriteTimeClear("Character not recognized", 2000, false, true); }
            }
        }
        public static void Blacksmith(Player player)
        {
            while (true)
            {
                Helpful.Utility.WriteTimeClear($"Blacksmith\n\nWelcome! What brings you here?\n-----------------\nYour money: {player.Money}\n-----------------\n1 - Reforge | 2 - Exit\n", 0, true);
                string responseBlacksmith = Console.ReadLine();
                if (responseBlacksmith == "1")
                {
                    //blablabla
                }
            }
        }
    }
}
