namespace TestletPrj
{
    public class Testlet
    {
        public string TestletId;
        private List<Item> Items;
        private List<Item> Items2 = new List<Item>();
        public Testlet(string testletId, List<Item> items)
        {
            TestletId = testletId;
            Items = items;
        }
        // Test First throws NotImplemented,
        //public List<Item> Randomize()
        //   { 
        //   throw new NotImplementedException(); 
        //   }
        // RandomizeOldVersion was Randomizing all Items.
        public List<Item> RandomizeOldVersion()
        {

            //Items private collection has 6 Operational and 4 Pretest Items. 
            //Randomize the order of these items as per the requirement (with TDD)

            var random = new Random();
            // pick randomonly 2 from the 4 pretest items, first 4 are pretest in .

            for (int i = 1; i <= 2;)
            {

                int MyNumber = 0;
                MyNumber = random.Next(1, 4);

                {
                    var matches = Items2.Where(x => x.ItemId == MyNumber.ToString() && x.ItemType.ToString() == "Pretest");
                    if (matches != null)
                    {
                        var itm = Items.Where(i => i.ItemId == MyNumber.ToString()).ToList();
                        foreach (var itm2 in itm)
                            Items2.Add(itm2);
                        i++;
                    }
                }

            }
            // pick randomonly next 8 from the items.
            for (int i = 1; Items2.Count < 10;)
            {

                int MyNumber = 0;
                MyNumber = random.Next(1, 11);

                var matches = Items2.Any(x => x.ItemId == MyNumber.ToString());
                if (!matches)
                {
                    var itm = Items.Where(i => i.ItemId == MyNumber.ToString()).ToList();
                    foreach (var itm2 in itm)
                        Items2.Add(itm2);
                    i++;
                }
            }
            return Items2;
        }

        public List<Item> Randomize()
        {

            //Items private collection has 6 Operational and 4 Pretest Items. 
            //Randomize the order of these items as per the requirement (with TDD)
            RandomizePretest(1, 2, "Pretest", 4); // pick randomonly 2 from the 4 pretest items, first 4 are pretest in .
            RandomizeOther();   // pick mix of pretest and operational Items randomonly from next 8 items.
            return Items2;
        }
        public void RandomizePretest(int L, int R, string Priority, int tot)
        {
            // pick randomonly 2 from the 4 pretest items, first 4 are pretest in .
            var random = new Random();
            for (int i = L; i <= R;)
            {
                int MyNumber = 0;
                MyNumber = random.Next(1, tot);
                {
                    var matches = Items2.Where(x => x.ItemId == MyNumber.ToString() && x.ItemType.ToString() == Priority);
                    if (matches != null)
                    {
                        var itm = Items.Where(i => i.ItemId == MyNumber.ToString()).ToList();
                        foreach (var itm2 in itm)
                            Items2.Add(itm2);
                        i++;
                    }
                }

            }
        }
        public void RandomizeOther()
        {
            var random = new Random();
            // pick mix of pretest and operational Items randomonly from next 8 items.
            for (int i = 1; Items2.Count < 10;)
            {

                int MyNumber = 0;
                MyNumber = random.Next(1, 11);

                var matches = Items2.Any(x => x.ItemId == MyNumber.ToString());
                if (!matches)
                {
                    var itm = Items.Where(i => i.ItemId == MyNumber.ToString()).ToList();
                    foreach (var itm2 in itm)
                        Items2.Add(itm2);
                    i++;
                }
            }

        }
    }
    public class Item
    {
        public string ItemId;
        public ItemTypeEnum ItemType;
    }
    public enum ItemTypeEnum
    {
        Pretest = 0,
        Operational = 1
    }
}