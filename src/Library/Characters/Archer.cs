using System.Collections.Generic;
using System;

namespace RoleplayGame
{
    public class Archer : ICharacter
    {
        private int health = 100;
        private List<IAttackItem> attackItems = new List<IAttackItem>();
        private List<IDefenseItem> defenseItems = new List<IDefenseItem>();

        public Archer(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

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

        public List<IAttackItem> AttackItems
        {
            get
            {
                return this.attackItems;
            }
            set
            {
                this.attackItems = value;
            }
        }

        public List<IDefenseItem> DefenseItems
        {
            get
            {
                return this.defenseItems;
            }
            set
            {
                this.defenseItems = value;
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