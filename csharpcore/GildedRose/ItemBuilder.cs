using System;

namespace GildedRoseKata
{
    public interface IItemBuilder
    {
        void SetName(string name);
        void SetSellIn(int sellIn);
        void SetQuality(int quality);
        void SetExpirationDate();
    }

    public abstract class BaseItemBuilder : IItemBuilder
    {
        protected ExpirableItem _item = new ExpirableItem();

        protected void Reset()
        {
            _item = new ExpirableItem();
        }   

        public void SetName(string name)
        {
            _item.Name = name;
        }

        public void SetSellIn(int sellIn)
        {
            _item.SellIn = sellIn;
        }

        public void SetQuality(int quality)
        {
            _item.Quality = quality;
        }

        public abstract void SetExpirationDate();
    }

    public class BuildNormalItem : BaseItemBuilder
    {
        public BuildNormalItem()
        {
            this.Reset();
        }

        public override void SetExpirationDate()
        {
            _item.ExpirationSpeed = 1;
        }

        public ExpirableItem Build()
        {
            return this._item;
        }
    }

    public class BuildConjuredItem : BaseItemBuilder
    {
        public override void SetExpirationDate()
        {
            _item.Name = "Conjured " + _item.Name;
            _item.ExpirationSpeed = 2;
        }

        public ExpirableItem Build()
        {
            return this._item;
        }
    }
}