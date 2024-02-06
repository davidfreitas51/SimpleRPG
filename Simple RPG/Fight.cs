using Entities;
using Helpful;
using Places;
using System.Numerics;
using System;

namespace Combat
{
    public static class Fight
    {
        public static int TestAccuracy(int accuracy)
        {
            int probability = Helpful.Utility.GenerateRandomNumber(0, 101);
            if (probability >= 92)
            {
                Helpful.Utility.WriteTimeClear("It's a CRITICAL!!!\n", 3000);
                return 2;
            }
            else if (probability >= (100 - accuracy))
            {
                Helpful.Utility.WriteTimeClear("It hits!\n", 3000);
                return 1;
            }
            else
            {
                Helpful.Utility.WriteTimeClear("It misses!\n", 3000);
                Helpful.Utility.WriteTimeClear("Nothing happens!", 2000, false, true);
                return 0;
            }
        }
        public static void attackWithEffects(Entities.Entity caster, Entities.Entity target, int currentAttack)
        {
            if (caster.AttackList[currentAttack] is Attacks.AttackEffect)
            {
                Attacks.AttackEffect creatureAttackEffect = (Attacks.AttackEffect)caster.AttackList[currentAttack];
                Helpful.Utility.WriteTimeClear(creatureAttackEffect.effect, 3000, false, true);
                target.Affected = true;
                if (creatureAttackEffect.effectType == 1) { target.Frozen = Helpful.Utility.GenerateRandomNumber(1, 3); }
                else if (creatureAttackEffect.effectType == 2) { target.Stun = Helpful.Utility.GenerateRandomNumber(1, 3); }
            }
        }
        public static void lowerEffectTime(Entities.Entity entity)
        {
            if (entity.Frozen > 0)
            {
                entity.Frozen--;
                if (entity.Frozen == 0)
                {
                    Helpful.Utility.WriteTimeClear("It breaks the ice!", 3000);
                    entity.Affected = false;
                }
            }
            else if (entity.Stun > 0)
            {
                entity.Stun -= 1;
                if (entity.Stun == 0)
                { 
                    Helpful.Utility.WriteTimeClear("It gets rid of the stun!", 3000);
                    entity.Affected = false;
                }
            }
        }
        public static void Combat(Player player, Entities.Entity enemy)
        {
            Helpful.Utility.WriteTimeClear($"An {enemy.Name} appears!\n", 0, true);
            while (player.CurrentHealth > 0 && enemy.CurrentHealth > 0)
            {
                player.Block = false;
                int enemyCurrentAttack = 0;
                int numOptions = 1;
                int turn = 0;
                Dictionary<string, Attacks.Attacks> attackDicctionary = new Dictionary<string, Attacks.Attacks>();
                Console.WriteLine($"What you wanna do?\n-------------------\nPlayer: {player.MaxHealth}/{player.CurrentHealth}\n{enemy.Name}: {enemy.MaxHealth}/{enemy.CurrentHealth}");
                foreach (Attacks.Attacks attack in player.AttackList)
                {
                    Console.WriteLine($"{numOptions} - {attack.attackName}");
                    attackDicctionary.Add(numOptions.ToString(), attack);
                    numOptions++;
                }
                Console.WriteLine($"{numOptions} - Info");
                string playerAction = Console.ReadLine();
                if (attackDicctionary.ContainsKey(playerAction))
                {
                    turn++;
                    if (player.Affected)
                    {
                        Helpful.Utility.WriteTimeClear($"\nYou are affected by {enemy.AttackList[enemyCurrentAttack].attackName}!", 3000, false, true);
                        lowerEffectTime(player);
                        Helpful.Utility.WriteTimeClear("Nothing else happens.", 2000, false, true);
                    }
                    else
                    {
                        Helpful.Utility.WriteTimeClear($"Player's action:\n\nYou {attackDicctionary[playerAction].attackDescription}", 3000, true);
                        int playerPrecision = Fight.TestAccuracy(attackDicctionary[playerAction].attackAccuracy);
                        if (playerPrecision > 0)
                        {
                            if (enemy.Block) { Helpful.Utility.WriteTimeClear("The enemy was blocking!\nYou deal 0 points of damage", 3000, false, true); }
                            else
                            {
                                Helpful.Utility.WriteTimeClear($"Your attack causes {attackDicctionary[playerAction].attackDamage * playerPrecision} points of damage!", 3000, false, true); enemy.CurrentHealth -= attackDicctionary[playerAction].attackDamage * playerPrecision;
                                attackWithEffects(player, enemy, Convert.ToInt32(playerAction) - 1);
                            }
                        }
                    }
                }
                else if (playerAction == (numOptions).ToString())
                {
                    numOptions = 1;
                    Helpful.Utility.WriteTimeClear($"What information you wanna see?", 0, true);
                    foreach (Attacks.Attacks attack in attackDicctionary.Values)
                    {
                        Console.WriteLine($"{numOptions} - {attackDicctionary[numOptions.ToString()].attackName}");
                        numOptions++;
                    }
                    string requiredInfo = Console.ReadLine();
                    if (attackDicctionary.ContainsKey(requiredInfo)) { Helpful.Utility.WriteTimeClear($"\n{attackDicctionary[requiredInfo].attackName}: You {attackDicctionary[requiredInfo].attackDescription}\nAccuracy - {attackDicctionary[requiredInfo].attackAccuracy}\nDamage - {attackDicctionary[requiredInfo].attackDamage}", 5000, false, true); }
                    else { Helpful.Utility.WriteTimeClear("Character not recognized!", 2000, false, true); }
                }
                else { Helpful.Utility.WriteTimeClear("Character not recognized!", 2000, false, true); }

                if (enemy.CurrentHealth > 0 && turn == 1)
                {
                    enemy.Block = false;
                    enemyCurrentAttack = Helpful.Utility.GenerateRandomNumber(0, enemy.AttackList.Count);
                    Helpful.Utility.WriteTimeClear($"{enemy.Name}'s action:\n", 0, true);
                    if (enemy.Affected)
                    {
                        Helpful.Utility.WriteTimeClear($"The enemy was affected by {player.AttackList[Convert.ToInt32(playerAction)-1].attackName}", 3000);
                        lowerEffectTime(enemy);
                        Helpful.Utility.WriteTimeClear("Nothing else happens.", 2000, false, true);
                    }
                    else
                    {
                        Helpful.Utility.WriteTimeClear($"It {enemy.AttackList[enemyCurrentAttack].attackDescription}", 3000);
                        int enemyPrecision = TestAccuracy(enemy.AttackList[enemyCurrentAttack].attackAccuracy);
                        if (enemyPrecision > 0)
                        {
                            if (player.Block) { Helpful.Utility.WriteTimeClear("The player was blocking!\nIt deals 0 points of damage", 3000, false, true); }
                            else
                            {
                                Helpful.Utility.WriteTimeClear($"The enemy causes {enemy.AttackList[enemyCurrentAttack].attackDamage * enemyPrecision} points of damage", 3000, false, true);
                                player.CurrentHealth -= enemy.AttackList[enemyCurrentAttack].attackDamage * enemyPrecision;
                                attackWithEffects(enemy, player, enemyCurrentAttack);
                            }
                        }
                    }
                }
                if (enemy.CurrentHealth > 0 && player.CurrentHealth <= 0)
                {
                    player.Frozen = player.Stun = 0;
                    player.Affected = false;
                }
                else if (enemy.CurrentHealth <= 0 && player.CurrentHealth > 0)
                {
                    Helpful.Utility.WriteTimeClear($"The {enemy.Name} was defeated by the player, dropping {enemy.Money} gold coins!\nGood job!", 5000, true, true);
                    player.Money += enemy.Money;
                }
            }
        }
    }
}