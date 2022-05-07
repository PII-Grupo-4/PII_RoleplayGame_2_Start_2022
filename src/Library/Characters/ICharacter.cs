namespace RoleplayGame
{
    public interface ICharacter
    {
        void Cure();
        void ReceiveAttack(int power);
        int AttackValue { get; }
        int DefenseValue { get; }
        int Health { get; }


    }
}