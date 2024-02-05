﻿using System.Collections.Generic;
using Attacks;
using Combat;
using Helpful;

namespace Entities
{
    public abstract class Entity
    {
        public int CurrentHealth { get; set; }
        public int MaxHealth { get; set; }
        public int Money { get; set; }
        public bool Block {  get; set; }
        public List<Attacks.Attacks> AttackList { get; set; }
        public string Name { get; set; }
        public int Stun {  get; set; }
        public int Frozen { get; set; }
        public bool Affected { get; set; }

        public Entity(int currentHealth, int maxHealth, int money, List<Attacks.Attacks> attackList, string name)
        {
            this.CurrentHealth = currentHealth;
            this.MaxHealth = maxHealth;
            this.Money = money;
            this.Block = false;
            this.AttackList = attackList;
            this.Name = name;
            this.Stun = 0;
            this.Frozen = 0;
            this.Affected = false;
        }
    }
    public class Monster : Entity
    {
        public string presentingPhrase1 { get; set; }
        public string presentingPhrase2 { get; set; }

        public Monster(int health, int maxHealth, int money, List<Attacks.Attacks> attackList, string name, string presentingPhrase1, string presentingPhrase2) : base(health, maxHealth, money, attackList, name)
        {
            this.presentingPhrase1 = presentingPhrase1;
            this.presentingPhrase2 = presentingPhrase2;
        }
    }
    public class Player : Entity
    {
        public int TotalUpgrades { get; set; }
        public int SwordUpgrades { get; set; }
        public int ArmorUpgrades { get; set; }
        public int MagicUpgrades { get; set; }

        public Player(int health, int maxHealth, int money, List<Attacks.Attacks> attackList, string name) : base(health, maxHealth, money, attackList, name)
        {
            this.SwordUpgrades = 1;
            this.ArmorUpgrades = 1;
            this.MagicUpgrades = 1;
            this.TotalUpgrades = ArmorUpgrades + MagicUpgrades + SwordUpgrades;
        }
    }
}