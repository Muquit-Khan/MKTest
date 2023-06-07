using TestletPrj;

namespace TestData
{

    class Program
    {
        static void Main2()
        {

            List<Item> Items = new List<Item>();

            Item item = new Item();

            for (int i = 0; i < 4; i++)
            {
                item.ItemId = (i + 1).ToString();
                item.ItemType = 0;
                Items.Add(item);
            }
            for (int i = 0; i < 6; i++)
            {
                item.ItemId = (i + 4 + 1).ToString();
                item.ItemType = (ItemTypeEnum)1;
                Items.Add(item);
            }
            Testlet testlet = new Testlet("1", Items);
            testlet.Randomize();

        }



    }
}

