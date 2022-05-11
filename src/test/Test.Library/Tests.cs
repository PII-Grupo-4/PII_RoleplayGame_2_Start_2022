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

            dwarfTest.AddItem(new Axe());
            dwarfTest.AddItem(new Helmet());
            dwarfTest.AddItem(new Shield());

            knightTest.AddItem(new Sword());
            knightTest.AddItem(new Armor());

            archerTest.AddItem(new Bow());
            archerTest.AddItem(new Helmet());

            Staff stafito = new Staff();
            wizardTest.AddItem(new Staff());
        }
        
        /*
        Testeamos que funcionen tanto el método DefenseValue de los items como el de los characters
        -----------------------------------------------------------------------------------
            Valores de Defense esperados:
                dwarfTest  -> Helmet + Shield (18+14)
                knightTest -> Armor (25)
                archerTest -> Helmet (18)
                wizardTest -> Staff (100) (Staff es tanto de defensa como de ataque)
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
                dwarfTest  -> Axe (25)
                knightTest -> Sword (50)
                archerTest -> Bow (15)
                wizardTest -> Staff (100) (Staff es tanto de defensa como de ataque)
        */
        [Test]
        public void AttackValueTest()
        {
            Assert.AreEqual(25, dwarfTest.AttackValue);
            Assert.AreEqual(50, knightTest.AttackValue);
            Assert.AreEqual(15, archerTest.AttackValue);
            Assert.AreEqual(100, wizardTest.AttackValue);
        }

        /*
        Testeamos que funcione el método RecieveAttack en cada ICharacter
        También se puede observar como cualquier personaje de un tipo puede atacar a cualquiera
        de otro tiop gracias a la implementación del supertipo ICharacter
        -----------------------------------------------------------------------------------
            Tabla de valores:

            Ataca (AttackValue)  |  Recibe (DefenseValue)  |   Health_Resultante
            ----------------------------------------------------------------------
              dwarfTest(25)          knightTest(25)           100 - (25-25) =       100 (no ataca)
              knightTest(50)         archerTest(18)           100 - (50-18) =       68
              archerTest(15)         wizardTest(100)          100 - (15-100) =      100 (no ataca)
              wizardTest(100)        dwarfTest(18+14)         100 - (100-(18+14)) = 32
        */
        [Test]
        public void ReceiveAttackTest()
        {
            knightTest.ReceiveAttack(dwarfTest);
            archerTest.ReceiveAttack(knightTest);
            wizardTest.ReceiveAttack(archerTest);
            dwarfTest.ReceiveAttack(wizardTest);

            Assert.AreEqual(100, knightTest.Health);
            Assert.AreEqual(68, archerTest.Health);
            Assert.AreEqual(100, wizardTest.Health);
            Assert.AreEqual(32, dwarfTest.Health);
        }
    
        // Test para confirmar que cuando muere un personaje su vida es igual a 0 y no es negativa
        [Test]
        public void CharacterDeadTest()
        {
            wizardTest.AddItem(new Sword());
            wizardTest.AddItem(new Sword());
    
            dwarfTest.ReceiveAttack(wizardTest);
            archerTest.ReceiveAttack(wizardTest);
            knightTest.ReceiveAttack(wizardTest);
            wizardTest.ReceiveAttack(wizardTest); //Se mata a el mismo :D

            Assert.AreEqual(0, dwarfTest.Health);
            Assert.AreEqual(0, archerTest.Health);
            Assert.AreEqual(0, knightTest.Health);
            Assert.AreEqual(0, wizardTest.Health);
        }

        // Test para confirmar que funciona curar a los personajes
        [Test]
        public void CureTest()
        {
            CharacterDeadTest();

            dwarfTest.Cure();
            archerTest.Cure();
            knightTest.Cure();
            wizardTest.Cure();
            
            Assert.AreEqual(100, dwarfTest.Health);
            Assert.AreEqual(100, archerTest.Health);
            Assert.AreEqual(100, knightTest.Health);
            Assert.AreEqual(100, wizardTest.Health);
            
        }


        /* 
            Testeamos el correcto funcionamiento de ISpells, sus subtipos y SpellBook.
            Confirmamos que el mago pueda adquirir un IMagicItem y funcione correctamente.
            
            Tablas de datos:
                SpellsBook
                                AttackValue    DefenseValue
                    SpellType1      70              70
                    SpellType2      50              50
                    SpellBook       120             120

                Wizard
                    AttackValue_Inicial     100
                    DefenseValue_Inicial    100
                    AttackValue_Final       220
                    DefenseValue_Final      220
                    
        
        */
        [Test]
        public void MagicItem()
        {
            SpellsBook bookTest = new SpellsBook();
            bookTest.Spells = new ISpell[]{ new SpellType1() , new SpellType2() };
            wizardTest.MagicItems.Add(bookTest);

            Assert.AreEqual(220, wizardTest.DefenseValue);
            Assert.AreEqual(220, wizardTest.AttackValue);
        }
        
    }


}