using Helpful;

namespace Attacks
{
    public class Attacks
    {
        public int attackDamage;
        public int attackAccuracy;
        public string attackDescription;
        public string attackName;
        public Attacks(int attackDamage, int attackAccuracy, string attackDescription, string attackName)
        {
            this.attackDamage = attackDamage;
            this.attackAccuracy = attackAccuracy;
            this.attackDescription = attackDescription;
            this.attackName = attackName;
        }
    }
    public class AttackEffect : Attacks
    {
        public int turns;
        public string effect;
        public int effectType;
        public string status;
        public AttackEffect(int attackDamage, int attackAccuracy, string attackDescription, string attackName, string effect, int effectType, string status, int turns = 0) : base (attackDamage, attackAccuracy, attackDescription, attackName)
        {
            this.turns = turns;
            this.effect = effect;
            this.effectType = effectType;
            this.status = status;
        }
    }
}