using System.Collections.Generic;

namespace RoleplayGame
{
    public interface ICharacter
    {
        int Health { get; }
        int AttackValue { get; }
        int DefenseValue { get; }
        List<IAttackItem> AttackItems { get; }
        List<IDefenseItem> DefenseItems { get; }

        void ReceiveAttack(ICharacter character);
        void Cure();
    }
}