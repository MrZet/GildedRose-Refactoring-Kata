namespace GildedRoseKata
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
    }

    public class ExpirableItem : Item
    {
        public int ExpirationSpeed { get; set; } = 1;
        public ExpirableItem()
        {
        }
        public ExpirableItem(int expirationSpeed)
        {
            ExpirationSpeed = expirationSpeed;
        }
    }
}
