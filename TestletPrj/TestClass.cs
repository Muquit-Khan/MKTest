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

        //public List<Item> Randomize()
        //   { 
        //   throw new NotImplementedException(); 
        //   }
        public List<Item> Randomize()
        {

            //Items private collection has 6 Operational and 4 Pretest Items. 
            //Randomize the order of these items as per the requirement (with TDD)
            //The assignment will be reviewed on the basis of – Tests written first, Correct 
            //logic, Well structured & clean readable code.
            //var shuffledList = Items.OrderBy(_ => _rand.Next()).ToList();
            var random = new Random();
            // pick randomonly 2 from the 4 pretest items.

            for (int i = 1; i <= 2;)
            {

                int MyNumber = 0;
                MyNumber = random.Next(1, 4);
                //if (Items2 is null)
                //{
                //    var itm = Items.Where(i => i.ItemId == MyNumber.ToString()).ToList();
                //    foreach (var itm2 in itm)
                //        Items2.Add(itm2);
                  
                //}
                //else
                {
                    var matches = Items2.Where(x => x.ItemId == MyNumber.ToString());
                    if (matches != null)
                    {
                        var itm = Items.Where(i => i.ItemId == MyNumber.ToString()).ToList();
                        foreach (var itm2 in itm)
                            Items2.Add(itm2);
                        i++;
                    }
                }

            }
            for (int i = 1; Items2.Count  < 10; )
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