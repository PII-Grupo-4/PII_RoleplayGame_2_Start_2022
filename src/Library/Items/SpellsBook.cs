using System.Collections.Generic;

namespace RoleplayGame
{
    public class SpellsBook : IMagicItem
    {
        public ISpell[] Spells { get; set; }
        
        public int AttackValue
        {
            get
            {
                int value = 0;
                foreach (ISpell spell in this.Spells)
                {
                    value += spell.AttackValue;
                }
                return value;
            }
        }

        public int DefenseValue
        {
            get
            {
                int value = 0;
                foreach (ISpell spell in this.Spells)
                {
                    value += spell.DefenseValue;
                }
                return value;
            }
        }
    }
}