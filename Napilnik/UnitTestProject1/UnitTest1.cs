using Microsoft.VisualStudio.TestTools.UnitTesting;
using System; 

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private Inventory _inventory = new Inventory(15);

        [TestMethod]
        public void TestMethod1()
        {
            var sword = new Item("Sword", 5);

            _inventory.AddItem(sword,5);

            Assert.D
        }

        [TestMethod]
        public void TestMethod2()
        {
            Item item = new Item("Дубинка", 12);
            Inventory inventory = new Inventory(45);

            inventory.AddItem(item, 1);

            int a = 1, b = 1;
            int expected = 0;

            int actual = inventory.m1_test(a, b);

            Assert.AreEqual(expected, actual, "correct execution!");
        }
    }
}
