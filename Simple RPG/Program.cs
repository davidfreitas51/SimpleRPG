using Places;
using Combat;
using Entities;
using Helpful;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Simple_RPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Attacks.Attacks swordAttack = new Attacks.Attacks(15, 85, "swing the sword in attack!", "Sword atk.");
            Attacks.Attacks magicAttack = new Attacks.Attacks(25, 75, "unleash magical energy and attacks with a spell!", "Magic atk.");
            Attacks.Attacks tempestLock = new Attacks.AttackEffect(0, 50, "channel the storm! Envelops the foe in electrifying stillness.", "Tempest Lock", "It stuns the opponent", 2, "stunned");

            Attacks.Attacks earthquake = new Attacks.Attacks(40, 60, "unleashes shockwaves from the earth!", "Earthquake");
            Attacks.Attacks stoneHail = new Attacks.Attacks(20, 80, "punches the floor, sending a cascade of rocks from above!", "Stone Hail");
            Attacks.Attacks groundBreaking = new Attacks.AttackEffect(10, 65, "slams the ground into two, breaking the dungeon into a large canyon", "Ground Breaking", "It stuns the opponent", 2, "stunned");

            Attacks.Attacks shadowSlash = new Attacks.Attacks(20, 90, "strikes you using a painful shadow whip!", "Shadow Slash");
            Attacks.Attacks selfDamage = new Attacks.Attacks(30, 85, "takes control of your shadow, giving yourself a deadly blow!", "Self Damage");
            Attacks.Attacks shadowsSpeed = new Attacks.AttackEffect(10, 80, "strikes with swift shadow attacks", "Shadow Speed", "It keeps attacking!", 3, "");

            Attacks.Attacks infernalWhirlwind = new Attacks.Attacks( 30, 75, "starts to swirl into a tornado, engulfing you!", "Infernal Whirlwind");
            Attacks.Attacks flameStrike = new Attacks.Attacks( 20, 80, "suddenly strikes you with a slash of fire!", "Flame Strike");
            Attacks.Attacks ignite = new Attacks.Attacks( 35, 85, "causes the floor to spontaneously erupt into flames!", "Ignite");


            Attacks.Attacks shadowStrike = new Attacks.Attacks(15, 85, "lashes out with it's shadow infused staff", "Shadow Strike");
            Attacks.Attacks boltBarrage = new Attacks.Attacks(10, 85, "staff starts to power up, sending magic bolts your way!", "Bolt Barrage");
            Attacks.Attacks spectralBlades = new Attacks.Attacks(20, 80, "summons spectral blades, launching them against the opponent.", "Spectral Blades");

            Attacks.Attacks abyssalBlade =  new Attacks.Attacks(30, 70, "attacks with the sword glowing with a black and purple darkness aura!", "Abyssal Blade");
            Attacks.Attacks nightmareWhispers = new Attacks.Attacks(35, 65, "sends haunting whispers into the foe's mind", "Nightmare Whispers");

            Attacks.Attacks eclipseBeam = new Attacks.Attacks(40, 80, "channels an eclipse's power into a laser, striking the opponent!", "Eclipse Beam");
            Attacks.Attacks magicMissiles = new Attacks.AttackEffect(10, 85, "magic missiles", "Magic Missiles", "The missiles keep hitting!", 3, "");
            Attacks.Attacks frostbiteGrasp = new Attacks.AttackEffect(0, 60, "freezes its surroundings, trapping all in an icy grip!", "Frostbite Grasp", "It freezes the opponent!", 1, "frozen");
            
            List<Attacks.Attacks> playerAttack = Helpful.Utility.CreatingAttackLists(swordAttack, magicAttack);
            List<Attacks.Attacks> stoneGuardianAttacks = Helpful.Utility.CreatingAttackLists(earthquake, stoneHail, groundBreaking);
            List<Attacks.Attacks> shadowStalkerAttacks = Helpful.Utility.CreatingAttackLists(shadowSlash, selfDamage, shadowsSpeed);
            List<Attacks.Attacks> embergeistAttacks = Helpful.Utility.CreatingAttackLists(infernalWhirlwind, flameStrike, ignite);
            List<Attacks.Attacks> shadowWardAttacks = Helpful.Utility.CreatingAttackLists(shadowStrike, boltBarrage, spectralBlades, abyssalBlade, nightmareWhispers, eclipseBeam, magicMissiles, frostbiteGrasp);

            Player player = new Player(100, 100, playerAttack, "Player", 0);
            Monster stoneGuardian = new Monster(140, 140, stoneGuardianAttacks, "Stone Guardian", "The earth trembles beneath an approaching monster..", "A stone creature strides purposefully towards you!!", Helpful.Utility.GenerateRandomNumber(80, 160));
            Monster shadowStalker = new Monster(100, 100, shadowStalkerAttacks, "Shadow Stalker", "You witness your own shadow expanding...", "An unsettling dark figure forms in front of you!", Helpful.Utility.GenerateRandomNumber(80, 160));
            Monster embergeist = new Monster(70, 70, embergeistAttacks, "Embergeist", "Your torch unexpectedly flares, making you to drop it.", "The flame creates a tornado of a fiery beast!", Helpful.Utility.GenerateRandomNumber(80, 160));
            Monster shadowWard = new Monster(500, 500, shadowWardAttacks, "Shadow Ward", "", "", 1500);

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
                        Places.Places.Cave(player, shadowWard);
                        break;
                    default:
                        Helpful.Utility.WriteTimeClear("Opção inválida!", 2000, false, true);
                        break;
                }
            }
        }
    }
}
