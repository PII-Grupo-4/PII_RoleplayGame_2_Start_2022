using System;
using RoleplayGame;
using System.Collections.Generic;

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
            gandalf.AttackItems.Add(stafito);
            gandalf.DefenseItems.Add(stafito);
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
