namespace GildedRoseKata
{
    public abstract class QualityCalculation
    {
        private Item Item;
        public QualityCalculation(Item item)
        {
            Item = item;
        }

        public void Calculate()
        {
            CalculateQuality(Item);
            CalculateSellIn(Item);
            CalculateQualityForExpiredItems(Item);            
        }
        protected abstract void CalculateQuality(Item item);

        protected virtual void CalculateSellIn(Item item)
        {
            item.SellIn = item.SellIn - 1;
        }

        protected abstract void CalculateQualityForExpiredItems(Item item);

        protected static bool IsItemExpired(Item item) => item.SellIn < 0 ? true : false;
    }

    public class QualityCalculationNormalItem : QualityCalculation
    {
        public QualityCalculationNormalItem(Item item) : base(item)
        {}     

        protected override void CalculateQuality(Item item)
        {
            if (item.Quality <= 0)
            {
                return;
            }
            item.Quality = item.Quality - 1;
        }

        protected override void CalculateQualityForExpiredItems(Item item)
        {
            if (!IsItemExpired(item) || item.Quality <= 0)
            {
                return;
            }
            item.Quality = item.Quality - 1;
        }
    }

    public class QualityCalculationSulfuras : QualityCalculation
    {
        public QualityCalculationSulfuras(Item item) : base(item)
        {}
        protected override void CalculateQuality(Item item)
        {     
            //intentionally blank, no calculations needed                 
        }
        protected override void CalculateSellIn(Item item)
        {               
            //intentionally blank, no calculations needed          
        }
        protected override void CalculateQualityForExpiredItems(Item item)
        {               
            //intentionally blank, no calculations needed          
        }
    }

    public class QualityCalculationAgedBrie : QualityCalculation
    {
        public QualityCalculationAgedBrie(Item item) : base(item)
        {}
        protected override void CalculateQuality(Item item)
        {
            if (item.Quality >= 50)
            {
                return;
            }
            item.Quality = item.Quality + 1;
        }
        protected override void CalculateQualityForExpiredItems(Item item)
        {
            if (!IsItemExpired(item) || item.Quality >= 50)
            {
                return;
            }
            item.Quality = item.Quality + 1;
        }
    }

    public class QualityCalculationBackstagePass : QualityCalculation
    {
        public QualityCalculationBackstagePass(Item item) : base(item)
        {}   

        protected override void CalculateQuality(Item item)
        {
            if (item.Quality >= 50)
            {
                return;
            }

            item.Quality = item.Quality + 1;
            
            if (item.SellIn < 11)
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;
                }
            }

            if (item.SellIn < 6)
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;
                }
            }
        }
        protected override void CalculateQualityForExpiredItems(Item item)
        {
            if (!IsItemExpired(item))
            {
                return;
            }
            item.Quality = 0;
        }
    }
}