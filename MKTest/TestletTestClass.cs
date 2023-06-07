using NUnit.Framework;
using TestletPrj;

namespace MKTest
{
    public class TestletTestClass
    {
        [Test]
        public void GetRandomizedItems()
        {
            List<Item> Items = new List<Item>();
            Items = GenerateItems();
            foreach(var item in Items)
                Console.WriteLine("{0}:{1}", item.ItemId,item.ItemType);    
            Testlet testlet = new Testlet("1", Items);
            Items=testlet.Randomize();
            
            foreach(var item in Items)
                Console.WriteLine("{0}:{1}", item.ItemId,item.ItemType);
            Assert.AreNotEqual(1, 1);
            Assert.AreNotEqual(10, 10);
        }
        public List<Item> GenerateItems()
        {
            List<Item> Items = new List<Item>();
          

            for (int i = 0; i < 4; i++)
            {
                  Item item = new Item();
                item.ItemId = (i + 1).ToString();
                item.ItemType = 0;
                Items.Add(item);
            }
            for (int i = 0; i < 6; i++)
            {
                  Item item = new Item();
                item.ItemId = (i + 4 + 1).ToString();
                item.ItemType = (ItemTypeEnum)1;
                Items.Add(item);
            }
            return Items;
        }

    }
}
