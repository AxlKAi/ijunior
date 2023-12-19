using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace TestProject1
{
    public class Tests
    {
        private Inventory _inventory;

        [SetUp]
        public void Setup()
        {
            _inventory = new Inventory(15);
        }

        [Test]
        public void AddItem_CanAddFittingItem()
        {
            var sword = new Item("Sword", 5);

            _inventory.AddItem(sword, 1);

            Assert.DoesNotThrow(() => _inventory.AddItem(sword, 1));
        }

        [Test]
        public void AddItem_CanAddNofittingItem()
        {
            var sword = new Item("Sword", 25);

            Assert.Throws<System.InvalidOperationException>(() => _inventory.AddItem(sword, 1));
        }

        [Test]
        public void Items_IsLinked()
        {
            var sword = new Item("Sword", 5);
            _inventory.AddItem(sword, 1);

            Cell cellWichSword = _inventory.Cells[0];
            _inventory.AddItem(sword, 1);

            Assert.AreEqual(cellWichSword.Count, 2);
        }

        [Test]
        public void CanIBreak()
        {
            var sword = new Item("Sword", 5);

            _inventory.AddItem(sword, 1);

            _inventory.Cells[0].Count = 1000;

            Assert.Greater(_inventory.Cells[0].Count, 1);
        }

        [Test]
        public void AddItem_AffectToCells()
        {
            var sword = new Item("Sword", 5);

            _inventory.AddItem(sword, 1);
        }
    }
}