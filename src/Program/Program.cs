using System;
using RoleplayGame;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            SpellsBook book = new SpellsBook();
            book.Spells = new SpellType1[]{ new SpellType1() };

            Wizard gandalf = new Wizard("Gandalf");

            gandalf.AttackItems.Add(new Staff());
            gandalf.DefenseItems.Add(new Staff());
            gandalf.MagicItems.Add(book);

            Dwarf gimli = new Dwarf("Gimli");
            gimli.AttackItems.Add(new Axe());
            gimli.DefenseItems.Add(new Helmet());
            gimli.DefenseItems.Add(new Shield());

            Console.WriteLine($"Gimli's health = {gimli.Health}");
            Console.WriteLine($"Gandalf attacks Gimli with {gandalf.AttackValue} of damage");

            gimli.ReceiveAttack(gandalf);

            Console.WriteLine($"Gimli's health = {gimli.Health}");

            gimli.Cure();

            Console.WriteLine($"Gimli's health = {gimli.Health}");
        }
    }
}
