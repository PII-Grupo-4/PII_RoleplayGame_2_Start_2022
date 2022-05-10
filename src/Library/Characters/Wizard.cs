using System;
using System.Collections.Generic;

namespace RoleplayGame
{
    public class Wizard : ICharacter
    {
        private int health = 100;
        private List<IAttackItem> attackItems = new List<IAttackItem>();
        private List<IDefenseItem> defenseItems = new List<IDefenseItem>();
        private List<IMagicItem> magicItems = new List<IMagicItem>();
        // Por ahora solo los magos pueden tener IMagicItems

        public Wizard(string name)
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
                foreach (IMagicItem magicItem in this.MagicItems)
                {
                    value += magicItem.AttackValue;
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
                foreach (IMagicItem magicItem in this.MagicItems)
                {
                    value += magicItem.DefenseValue;
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

        public List<IMagicItem> MagicItems
        {
            get
            {
                return this.magicItems;
            }
            set
            {
                this.magicItems = value;
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