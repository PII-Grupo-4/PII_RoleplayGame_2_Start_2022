using System.Collections.Generic;

namespace RoleplayGame
{
    public interface ICharacter
    {
        int Health { get; }
        int AttackValue { get; }
        int DefenseValue { get; }
        List<IItem> Items { get; }
        void AddItem(IItem item);
        void RemoveItem(IItem item);
        void ReceiveAttack(ICharacter character);
        void Cure();
    }
}