using System;

namespace RoleplayGame
{
    public class Dwarf : ICharacter
    {
        private int health = 100;

        public string Name { get; set; }

        public Axe Axe { get; set; }

        public Shield Shield { get; set; }

        public Helmet Helmet { get; set; }

        public Dwarf(string name)
        {
            this.Name = name;
        }

        public int AttackValue
        {
            get
            {
                return Axe.AttackValue;
            }
        }

        public int DefenseValue
        {
            get
            {
                return Shield.DefenseValue + Helmet.DefenseValue;
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