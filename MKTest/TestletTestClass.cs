using NUnit.Framework;
using TestletPrj;

namespace MKTest
{
    public class TestletTestClass
    {
        const int Pretest = 4;
        const int Operational = 6;
        List<Item> Items = new List<Item>();

        [Test]
        public void GetRandomizedItems()
        {

            GenerateItems();
            Console.WriteLine("Before Randomization");
            foreach (var item in Items)
                Console.WriteLine("{0}:{1}", item.ItemId, item.ItemType);
            Testlet testlet = new Testlet("1", Items);

            //    Items = testlet.RandomizeOldVersion();  // Older Version
            Items = testlet.Randomize();        // With Modular Approach with Randomization

            Console.WriteLine("After Randomization");
            foreach (var item in Items)
                Console.WriteLine("{0}:{1}", item.ItemId, item.ItemType);

            var item1 = Items[0].ItemType.ToString();
            var item2 = Items[1].ItemType.ToString();
            Assert.AreEqual(item1, "Pretest");
            Assert.AreEqual(item2, "Pretest");
        }
        private void GenerateItems()
        {
            //Generation of Items divided as per Pretest Item module and Operational Item module.
            //  GeneratePretestItems();  //Generate Pretest Items
            //   GenerateOperationalItems(); // Generate Operational Items
            GenerateItem("Pretest");
            GenerateItem("Operational");
        }

        private void GenerateItem(string itemType)          // Single function to generate both type data based on argument 
        {
            if (itemType == "Pretest")
            {
                for (int i = 0; i < Pretest; i++)
                {
                    Item item = new Item();
                    item.ItemId = (i + 1).ToString();
                    item.ItemType = 0;
                    Items.Add(item);
                }
            }
            if (itemType == "Operational")
            {
                for (int i = 0; i < Operational; i++)
                {
                    Item item = new Item();
                    item.ItemId = (i + Pretest + 1).ToString();
                    item.ItemType = (ItemTypeEnum)1;
                    Items.Add(item);
                }

            }
        }
        //public void GeneratePretestItems()
        //{
        //    for (int i = 0; i < Pretest; i++)
        //    {
        //        Item item = new Item();
        //        item.ItemId = (i + 1).ToString();
        //        item.ItemType = 0;
        //        Items.Add(item);
        //    }
        //}
        //public void GenerateOperationalItems()
        //{
        //    for (int i = 0; i < Operational; i++)
        //    {
        //        Item item = new Item();
        //        item.ItemId = (i + Pretest + 1).ToString();
        //        item.ItemType = (ItemTypeEnum)1;
        //        Items.Add(item);
        //    }

        //}

    }
}
