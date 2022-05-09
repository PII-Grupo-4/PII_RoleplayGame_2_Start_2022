using System.Collections.Generic;

namespace RoleplayGame
{
    public class Knight : ICharacter
    {
        private int health = 100;

        public Knight(string name)
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
            if (this.DefenseValue < power)
            {
                this.Health -= power - this.DefenseValue;
            }
        }

        public void Cure()
        {
            this.Health = 100;
        }
    }
}