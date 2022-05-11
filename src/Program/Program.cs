using System;
using RoleplayGame;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            SpellsBook book = new SpellsBook();
            book.Spells = new ISpell[]{ new SpellType1() };

            Wizard gandalf = new Wizard("Gandalf");

            Staff stafito = new Staff();
            gandalf.AddItem(stafito);
            gandalf.AddMagicItem(book);

            Dwarf gimli = new Dwarf("Gimli");
            gimli.AddItem(new Axe());
            gimli.AddItem(new Helmet());
            gimli.AddItem(new Shield());

            Console.WriteLine($"Gimli's health = {gimli.Health}");
            Console.WriteLine($"Gandalf attacks Gimli with {gandalf.AttackValue} of damage");

            gimli.ReceiveAttack(gandalf);

            Console.WriteLine($"Gimli's health = {gimli.Health}");

            gimli.Cure();

            Console.WriteLine($"Gimli's health = {gimli.Health}");
        }
    }
}
