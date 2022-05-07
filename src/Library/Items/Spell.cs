namespace RoleplayGame
{
    public class Spell  : IMagicItems // también se podria haber implementado las interfaces IDefenseItems, IAttackItems
    {
        public int AttackValue
        {
            get
            {
                return 70;
            }
        }

        public int DefenseValue
        {
            get
            {
                return 70;
            }
        }
    }
}