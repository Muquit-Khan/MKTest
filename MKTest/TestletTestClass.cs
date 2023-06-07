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
            Console.WriteLine("Before Randomization");
            foreach(var item in Items)
                Console.WriteLine("{0}:{1}", item.ItemId,item.ItemType);    
            Testlet testlet = new Testlet("1", Items);

            Items=testlet.Randomize();

            Console.WriteLine("After Randomization");
            foreach(var item in Items)
                Console.WriteLine("{0}:{1}", item.ItemId,item.ItemType);

            var item1 =  Items[0].ItemType.ToString();
            var item2 = Items[1].ItemType.ToString();
            Assert.AreEqual(item1, "Pretest");
            Assert.AreEqual(item2, "Pretest");
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
