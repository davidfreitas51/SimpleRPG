using Entities;
using Helpful;
using Combat;
using Simple_RPG;

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
            foreach (string phrase in phrasesBeforeBattle) { Helpful.Utility.WriteTimeClear(phrase, 3500); }
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
                List<int> itemsLevel = new List<int>();

                blacksmithUpgrades.AddRange(new List<string> { "Armor", "Sword", "Magic", "Stunning Ray" });
                itemsLevel.AddRange(new List<int> { player.ArmorUpgrades, player.SwordUpgrades, player.MagicUpgrades });
                if ( player.AttackList.Count > 2 ) { blacksmithUpgrades.Remove("Stunning Ray"); }
                
                Helpful.Utility.WriteTimeClear($"Blacksmith\n\nWelcome! What brings you here?\n-----------------\nYour money: {player.Money}\n-----------------\n1 - Reforge | 2 - Exit\n", 0, true);
                string responseBlacksmith = Console.ReadLine();
                int indexDicctionary = 1;
                Dictionary<string, string> upgradesDicctionary = new Dictionary<string, string>();
                if (responseBlacksmith == "1")
                {
                    Helpful.Utility.WriteTimeClear($"Blacksmith\nYour money: {player.Money}\n-------------", 0, true);
                    foreach(string item in blacksmithUpgrades)
                    {
                        Console.Write($"{indexDicctionary} - {item}  =  ");
                        upgradesDicctionary[indexDicctionary.ToString()] = item;
                        if (indexDicctionary == 1) { Console.Write(((player.ArmorUpgrades * 20) +80)); }
                        else if (indexDicctionary == 2) { Console.Write(((player.SwordUpgrades * 20) + 80)); }
                        else if (indexDicctionary == 3) { Console.Write(((player.MagicUpgrades * 20) + 80)); }
                        else if (indexDicctionary == 4) { Console.Write((200)); }
                        Console.WriteLine(" gold coins");
                        indexDicctionary++;
                    }
                    Console.WriteLine($"5 - Quit");
                    string upgradeResponse = Console.ReadLine();
                    if (upgradesDicctionary.ContainsKey(upgradeResponse))
                    {
                        if (upgradeResponse == "1")
                        {
                            if (player.Money < ((player.ArmorUpgrades * 20) + 80)) { Helpful.Utility.WriteTimeClear("You don't have enough money!", 2000); }
                            else
                            {
                                player.MaxHealth += 20;
                                player.CurrentHealth += 20;
                                Helpful.Utility.WriteTimeClear("Alright, just a moment...", 2500, true);
                                Helpful.Utility.WriteTimeClear("There we go! Your armor has been upgraded!", 2500, false, true);
                                player.Money -= ((player.ArmorUpgrades * 20) + 80);
                                player.ArmorUpgrades += 1;
                            }
                        }
                        else if (upgradeResponse == "2")
                        {
                            if (player.Money < ((player.SwordUpgrades * 20) + 80)) { Helpful.Utility.WriteTimeClear("You don't have enough money!", 2000); }
                            else
                            {
                                Helpful.Utility.WriteTimeClear("Alright, just a moment...", 2500, true);
                                Helpful.Utility.WriteTimeClear("There we go! Your sword has been upgraded!", 2500, false, true);
                                Attacks.Attacks swordAttack = new Attacks.Attacks(player.AttackList[0].attackDamage + 20, 100, "swing the sword in attack!", "Sword atk.");
                                player.AttackList[0] = swordAttack;
                                player.Money -= ((player.SwordUpgrades * 20) + 80);
                                player.SwordUpgrades += 1;
                            }
                        }
                        else if (upgradeResponse == "3")
                        {
                            if (player.Money < ((player.MagicUpgrades * 20) + 80)) { Helpful.Utility.WriteTimeClear("You don't have enough money!", 2000); }
                            else
                            {
                                Helpful.Utility.WriteTimeClear("Alright, just a moment...", 2500, true);
                                Helpful.Utility.WriteTimeClear("There we go! Your magic spell has been upgraded!", 2500, false, true);
                                Attacks.Attacks magicAttack = new Attacks.Attacks(player.AttackList[1].attackDamage + 20, 100, "swing the sword in attack!", "Sword atk.");
                                player.AttackList[0] = magicAttack;
                                player.Money -= ((player.MagicUpgrades * 20) + 80);
                                player.MagicUpgrades += 1;
                            }
                        }
                        else if (upgradeResponse == "4" && player.AttackList.Count < 3)
                        {
                            if (player.Money < 200) { Helpful.Utility.WriteTimeClear("You don't have enough money!", 2000); }
                            else
                            {
                                Helpful.Utility.WriteTimeClear("This is a pretty powerful spell, but very occasional", 2500, true);
                                Helpful.Utility.WriteTimeClear("It stuns the enemy for 2 to 3 turns!\nStill want to buy it?\n1 - Yes\n2 - No", 0, false);
                                string inputStunAttack = Console.ReadLine();
                                if (inputStunAttack == "1")
                                {
                                    Helpful.Utility.WriteTimeClear("Here, it's yours!", 2000);
                                    player.Money -= 200;
                                    player.ArmorUpgrades += 1;
                                    Attacks.Attacks stunningRay = new Attacks.AttackEffect(0, 50, "channel a storm!", "Stunning Ray", "It stuns the opponent", 2, "stunned");
                                    player.AttackList.Add(stunningRay);
                                }
                                else if (inputStunAttack == "2") { }
                                else { Helpful.Utility.WriteTimeClear("Not recognized character", 2000);  }
                            }
                        }
                        else if (upgradeResponse == "5") { }
                        else {Helpful.Utility.WriteTimeClear("Not recognized character!", 2000);}
                    }
                }
                else if ( responseBlacksmith == "2") { Helpful.Utility.WriteTimeClear("Until our next forging, safe travels!", 2500, false, true); break; }
                else { Helpful.Utility.WriteTimeClear("Not recognized character!", 2000, false, true); }
            }
        }
        public static void Cave(Player player, Monster boss)
        {
            if (player.TotalUpgrades <= 10)
            {
                Helpful.Utility.WriteTimeClear("The aura in this cave is dark and dangerous. You'd better upgrade some more before venturing deeper.", 4500);
            }
            else
            {
                Helpful.Utility.WriteTimeClear("The cave\n\nAs you enter the cave, a chill runs down your spine.", 4500, true);
                Helpful.Utility.WriteTimeClear("Bloodstains mark the walls, and strange noises echo. ", 4500);
                Helpful.Utility.WriteTimeClear("Suddenly, silence falls, and a dark feeling surrounds you.", 4500);
                Helpful.Utility.WriteTimeClear("In that chilling moment, a creature appears.", 4500, false);
                Helpful.Utility.WriteTimeClear("Its terrifying presence makes you tremble, but you know it's time for the showdown.", 6500, false, true);
                Fight.Combat(player, boss);
                Helpful.Utility.WriteTimeClear($"{boss.CurrentHealth} ||| {player.CurrentHealth}", 5000);
                if (boss.CurrentHealth <= 0 && player.CurrentHealth > 0)
                {
                    Helpful.Utility.WriteTimeClear("Victorious, you stand over the defeated boss\nA sense of accomplishment washes over you\nThe echoes of battle fade\n\nCongratulations, brave adventurer!\nYou have triumphed over the formidable foe.\nYour courage and skill have prevailed.\nThe cave's darkness recedes, thanks to your valiant efforts.\n\nUntil the next challenge, well done!\n---------------------------\nEnter anything to quit\n\n", 0, true);
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
    }
}
