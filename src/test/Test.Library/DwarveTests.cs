using NUnit.Framework;
using RoleplayGame;

namespace Test.Library
{

    [TestFixture]
    public class DwarfTests
    {

        [Test]
        public void ReceiveAttackTest()
        {

            Dwarf dwarfTest = new Dwarf("DwarfTest");
            dwarfTest.Axe = new Axe();
            dwarfTest.Helmet = new Helmet();
            dwarfTest.Shield = new Shield();

            Knight knightTest = new Knight("KnightTest");
            knightTest.Sword = new Sword();

            dwarfTest.ReceiveAttack(knightTest.AttackValue);

            int expected = 82;

            Assert.AreEqual(dwarfTest.Health, expected);
        }

        [Test]
        public void DiedTest()
        {
            Knight knightTest = new Knight("KnightTest");
            Dwarf dwarfTest = new Dwarf("DwarfTest");

            dwarfTest.Helmet = new Helmet();
            dwarfTest.Shield = new Shield();

            knightTest.Sword = new Sword();

            dwarfTest.ReceiveAttack(knightTest.AttackValue);
            dwarfTest.ReceiveAttack(knightTest.AttackValue);
            dwarfTest.ReceiveAttack(knightTest.AttackValue);
            dwarfTest.ReceiveAttack(knightTest.AttackValue);
            dwarfTest.ReceiveAttack(knightTest.AttackValue);
            dwarfTest.ReceiveAttack(knightTest.AttackValue);
            

            int expected = 0;
            
            Assert.AreEqual(dwarfTest.Health, expected);
        }
        [Test]
         public void DefenseValueTest()
        {
            Dwarf dwarfTest = new Dwarf("DwarfTest");
            
            dwarfTest.Helmet = new Helmet();
            dwarfTest.Shield = new Shield();

            int expected = 32;

            Assert.AreEqual(dwarfTest.DefenseValue, expected);
        }
        [Test]
         public void AttackValueTest()
        {
            Dwarf dwarfTest = new Dwarf("DwarfTest");
            
            dwarfTest.Axe = new Axe();

            int expected = 25;

            Assert.AreEqual(dwarfTest.AttackValue, expected);
        }
    }


}