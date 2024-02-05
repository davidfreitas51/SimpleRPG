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
            phrasesBeforeBattle.AddRange(new[] { "You step into the ominous depths of the dungeons..", "Suddenly, a noise catches your attention..", enemy.presentingPhrase1, enemy.presentingPhrase2 });
            foreach (string phrase in phrasesBeforeBattle) { Helpful.Utility.WriteTimeClear(phrase, 3000); }
            Fight.Combat(player, enemy);
        }
    }
}
