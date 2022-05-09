using System;
using System.Collections.Generic;

namespace RoleplayGame
{
    public class Wizard : ICharacter
    {
        private int health = 100;

        public Wizard(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public List<IAttackItem> AttackItems { get; set; }

        public List<IDefenseItem> DefenseItems { get; set; }

        public List<IMagicItem> MagicItems { get; set; }

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

        public void ReceiveAttack(int power)
        {
            if (this.DefenseValue < power)
            {
                this.Health -= power - this.DefenseValue;
                Console.WriteLine($"{this.Name} receive attack");
            }
        }

        public void Cure()
        {
            this.Health = 100;
        }
    }
}