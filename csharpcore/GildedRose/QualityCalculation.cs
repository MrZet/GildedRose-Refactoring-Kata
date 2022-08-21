namespace GildedRoseKata
{
    public abstract class QualityCalculation
    {
        private ExpirableItem Item;
        public QualityCalculation(ExpirableItem item)
        {
            Item = item;
        }

        public void Calculate()
        {
            CalculateQuality(Item);
            CalculateSellIn(Item);
            CalculateQualityForExpiredItems(Item);            
        }
        protected abstract void CalculateQuality(ExpirableItem item);

        protected virtual void CalculateSellIn(ExpirableItem item)
        {
            item.SellIn = item.SellIn - 1;
        }

        protected abstract void CalculateQualityForExpiredItems(ExpirableItem item);

        protected static bool IsItemExpired(ExpirableItem item) => item.SellIn < 0 ? true : false;

        protected static int SetQuality(ExpirableItem item, int value)
        {
            int calculatedValue = item.Quality + value * item.ExpirationSpeed;
            calculatedValue = calculatedValue < 0 ? 0 : calculatedValue;
            calculatedValue = calculatedValue > 50 ? 50 : calculatedValue;
            return calculatedValue;
        }
    }

    public class QualityCalculationNormalItem : QualityCalculation
    {
        public QualityCalculationNormalItem(ExpirableItem item) : base(item)
        {}     

        protected override void CalculateQuality(ExpirableItem item)
        {
            if (item.Quality <= 0)
            {
                return;
            }

            item.Quality = SetQuality(item, -1);
        }

        protected override void CalculateQualityForExpiredItems(ExpirableItem item)
        {
            if (!IsItemExpired(item) || item.Quality <= 0)
            {
                return;
            }
            
            item.Quality = SetQuality(item, -1);
        }
    }

    public class QualityCalculationSulfuras : QualityCalculation
    {
        public QualityCalculationSulfuras(ExpirableItem item) : base(item)
        {}
        protected override void CalculateQuality(ExpirableItem item)
        {     
            //intentionally blank, no calculations needed                 
        }
        protected override void CalculateSellIn(ExpirableItem item)
        {               
            //intentionally blank, no calculations needed          
        }
        protected override void CalculateQualityForExpiredItems(ExpirableItem item)
        {               
            //intentionally blank, no calculations needed          
        }
    }

    public class QualityCalculationAgedBrie : QualityCalculation
    {
        public QualityCalculationAgedBrie(ExpirableItem item) : base(item)
        {}
        protected override void CalculateQuality(ExpirableItem item)
        {
            if (item.Quality >= 50)
            {
                return;
            }

            item.Quality = SetQuality(item, 1);
        }
        protected override void CalculateQualityForExpiredItems(ExpirableItem item)
        {
            if (!IsItemExpired(item) || item.Quality >= 50)
            {
                return;
            }

            item.Quality = SetQuality(item, 1);
        }
    }

    public class QualityCalculationBackstagePass : QualityCalculation
    {
        public QualityCalculationBackstagePass(ExpirableItem item) : base(item)
        {}   

        protected override void CalculateQuality(ExpirableItem item)
        {
            if (item.Quality >= 50)
            {
                return;
            }

            item.Quality = SetQuality(item, 1);
            
            if (item.SellIn < 11)
            {
                item.Quality = SetQuality(item, 1);
            }

            if (item.SellIn < 6)
            {
                item.Quality = SetQuality(item, 1);
            }
        }
        protected override void CalculateQualityForExpiredItems(ExpirableItem item)
        {
            if (!IsItemExpired(item))
            {
                return;
            }

            item.Quality = 0;
        }
    }
}