namespace GildedRoseKata
{
    public interface IItem
    {
        string Name { get; set; }
        int SellIn { get; set; }
        int Quality { get; set; }
    }

    public class Item : IItem
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
    }

    public class ExpirableItem : Item, IItem
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
