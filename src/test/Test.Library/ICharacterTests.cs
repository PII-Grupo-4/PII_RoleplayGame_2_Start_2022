using NUnit.Framework;
using RoleplayGame;

namespace Test.Library
{
    [TestFixture]
    public class ICharacterTests
    {
        private Dwarf dwarfTest;
        private Knight knightTest;
        private Archer archerTest;
        private Wizard wizardTest;
        
        
        
        // En SetUp creamos todos los subtipos de ICharacter y los armamos con IAttackItems y IDefenseItems
        [SetUp]
        public void SetUp()
        {
            dwarfTest = new Dwarf("DwarfTest");
            knightTest = new Knight("KnightTest");
            archerTest = new Archer("ArcherTest");
            wizardTest = new Wizard("wizardTest");

            dwarfTest.AttackItems.Add(new Axe());
            dwarfTest.DefenseItems.Add(new Helmet());
            dwarfTest.DefenseItems.Add(new Shield());

            knightTest.AttackItems.Add(new Sword());
            knightTest.DefenseItems.Add(new Armor());

            archerTest.AttackItems.Add(new Bow());
            archerTest.DefenseItems.Add(new Helmet());

            Staff stafito = new Staff();
            wizardTest.AttackItems.Add(stafito);
            wizardTest.DefenseItems.Add(stafito);
        }
        
        /*
        Testeamos que funcionen tanto el método DefenseValue de los items como el de los characters
        -----------------------------------------------------------------------------------
            Valores de Defense esperados:
                dwarfTest  -> Helmet + Shield
                knightTest -> Armor
                archerTest -> Helmet
                wizardTest -> Staff (Staff es tanto de defensa como de ataque)
        */
        [Test]
        public void DefenseValueTest()
        {
            Assert.AreEqual(18+14, dwarfTest.DefenseValue);
            Assert.AreEqual(25, knightTest.DefenseValue);
            Assert.AreEqual(18, archerTest.DefenseValue);
            Assert.AreEqual(100, wizardTest.DefenseValue);
        }


        /*
        Testeamos que funcionen tanto el AttackValue de los items como el de los characters
        -----------------------------------------------------------------------------------
            Valores de Attack esperados:
                dwarfTest  -> Axe
                knightTest -> Sword
                archerTest -> Bow
                wizardTest -> Staff (Staff es tanto de defensa como de ataque)
        */
        [Test]
        public void AttackValueTest()
        {
            Assert.AreEqual(25, dwarfTest.AttackValue);
            Assert.AreEqual(50, knightTest.AttackValue);
            Assert.AreEqual(15, archerTest.AttackValue);
            Assert.AreEqual(100, wizardTest.AttackValue);
        }

        // Testeamos que funcione el método Recieveattack en cada ICharacter
        /*        
        [Test]
        public void ReceiveAttackTest()
        {
            dwarfTest.ReceiveAttack(knightTest);

            //Assert.AreEqual(expected, dwarfTest.Health);
        }
        /*
        
/*
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
            
            Assert.AreEqual(expected, dwarfTest.Health);
        }

        
        
        public void CureTest()
        {
            Dwarf dwarfTest = new Dwarf("DwarfTest");
            
            dwarfTest.Cure();
            
            int expected = 100;

            Assert.AreEqual(expected, dwarfTest.Health);

        }
*/
    }


}