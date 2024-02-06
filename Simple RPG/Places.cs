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

        public static void Hospital(Player player, bool dead = false)
        {
            if (dead)
            {
                Helpful.Utility.WriteTimeClear("Oh no... this is not good...", 2000, true);
                Helpful.Utility.WriteTimeClear("Here, let me lend you my aid..", 2000);
                Helpful.Utility.WriteTimeClear("Adventurer, your wounds were grave, and it required 50 gold coins to mend them....", 3500);
                Helpful.Utility.WriteTimeClear("But fear not, for you are now restored to full health.", 3000, false, true);
                player.CurrentHealth = player.MaxHealth;
                player.Money -= 50;
                if (player.Money < 0) { player.Money = 0; }
            }
            else
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
                        Helpful.Utility.WriteTimeClear("Stay well, and return in good health.", 2000, false, true);
                        break;
                    }
                    else { Helpful.Utility.WriteTimeClear("Character not recognized", 2000, false, true); }
                }
            }
        }

        public static void Blacksmith(Player player)
        {
            while (true)
            {
                List<string> blacksmithUpgrades = new List<string>();
                blacksmithUpgrades.AddRange(new List<string> { "Armor", "Sword", "Magic", "Stunning Ray" });
                Helpful.Utility.WriteTimeClear($"Blacksmith\n\nWelcome! What brings you here?\n-----------------\nYour money: {player.Money}\n-----------------\n1 - Reforge | 2 - Exit\n", 0, true);
                string responseBlacksmith = Console.ReadLine();

                if (responseBlacksmith == "1")
                {
                    Helpful.Utility.WriteTimeClear($"Blacksmith\n\nWhat you want to reforge?\n", 0);
                    foreach (string itemUpgrade in blacksmithUpgrades)
                    {
                        Console.WriteLine(itemUpgrade);
                    }
                    string responseBlacksmithUpgrades = Console.ReadLine();
                }
                else if(responseBlacksmith == "2")
                {
                    Helpful.Utility.WriteTimeClear("Safe travels, adventurer. 'Til the next hammer's song!", 2000, false, true);
                    break;
                }
                else { Helpful.Utility.WriteTimeClear("Not recognized character!", 2000);  }
            }
        }
    }
}
