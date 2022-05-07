namespace RoleplayGame
{
    public class Staff : IDefenseItems, IAttackItems
    {
        public int AttackValue 
        {
            get
            {
                return 100;
            } 
        }

        public int DefenseValue
        {
            get
            {
                return 100;
            }
        }
    }
}