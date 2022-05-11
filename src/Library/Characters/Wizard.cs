using System;
using System.Collections.Generic;

namespace RoleplayGame
{
    public class Wizard : ICharacter, IMagicCharacter
    {
        private int health = 100;
        public List<IItem> Items { get; }
        public List<IMagicItem> MagicItems { get;}


        public Wizard(string name)
        {
            this.Name = name;
            this.Items = new List<IItem>();
            this.MagicItems = new List<IMagicItem>();
        }

        public string Name { get; set; }

        public int AttackValue
        {
            get
            {
                int value = 0;
                foreach (var item in this.Items)
                {
                    var attackItem = item as IAttackItem;
                    if (attackItem != null)
                    {
                        value += attackItem.AttackValue;
                    }
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
                foreach (var item in this.Items)
                {
                    var defenseItem = item as IDefenseItem;
                    if (defenseItem != null)
                    {
                        value += defenseItem.DefenseValue;
                    }
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

        public void AddItem(IItem item)
        {
            this.Items.Add(item);
        }

        public void RemoveItem(IItem item)
        {
            if (this.Items.Contains(item))
            {
                this.Items.Remove(item);
            }
        }

        public void AddMagicItem(IMagicItem magicItem)
        {
            this.MagicItems.Add(magicItem);
        }

        public void RemoveMagicItem(IMagicItem magicItem)
        {
            if (this.MagicItems.Contains(magicItem))
            {
                this.MagicItems.Remove(magicItem);
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