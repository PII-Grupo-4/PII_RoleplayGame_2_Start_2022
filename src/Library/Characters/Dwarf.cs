using System;
using System.Collections.Generic;

namespace RoleplayGame
{
    public class Dwarf : ICharacter
    {
        private int health = 100;

        public Dwarf(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public List<IAttackItem> AttackItems { get; set; }

        public List<IDefenseItem> DefenseItems { get; set; }

        public int AttackValue
        {
            get
            {
                int value = 0;
                foreach (IAttackItem attackItem in this.AttackItems)
                {
                    value += attackItem.AttackValue;
                }
                return value;
            }
        }

        public int DefenseValue
        {
            get
            {
                int value = 0;
                foreach (IDefenseItem defenseItem in this.DefenseItems)
                {
                    value += defenseItem.DefenseValue;
                }
                return value;
            }
        }

        public int Health
        {
            get
            {
                return this.health;
            }
            private set
            {
                this.health = value < 0 ? 0 : value;
            }
        }

        public void ReceiveAttack(ICharacter character)
        {
            if (this.DefenseValue < character.AttackValue)
            {
                this.Health -= character.AttackValue - this.DefenseValue;
            }
        }
        
        public void Cure()
        {
            this.Health = 100;
        }
    }
}