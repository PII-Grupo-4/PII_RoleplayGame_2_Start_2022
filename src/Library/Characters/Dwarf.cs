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

        public void ReceiveAttack(int power)
        {
            if (this.health > 0)
            {
                if (power >= (this.DefenseValue))
                {
                    this.health = this.health - (power - this.DefenseValue);
                    if (this.health <= 0)
                    {
                        this.health = 0;
                        Console.WriteLine($"{this.Name} died.");
                    }
                    else
                    {
                        Console.WriteLine($"{this.Name} have {this.health} HP after the attack");
                    }
                }
            }

        }
        public void Cure()
        {
            this.Health = 100;
        }
    }
}