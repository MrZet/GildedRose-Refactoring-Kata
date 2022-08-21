using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<ExpirableItem> Items;
        public GildedRose(IList<ExpirableItem> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                switch (Items[i].Name)
                {
                    case string s when s.Contains("Aged Brie"):
                        new GildedRoseKata.QualityCalculationAgedBrie(Items[i]).Calculate();
                        break;
                    case string s when s.Contains("Sulfuras, Hand of Ragnaros"):
                        new GildedRoseKata.QualityCalculationSulfuras(Items[i]).Calculate();
                        break;
                    case string s when s.Contains("Backstage passes to a TAFKAL80ETC concert"):
                        new GildedRoseKata.QualityCalculationBackstagePass(Items[i]).Calculate();
                        break;
                    default: 
                        new GildedRoseKata.QualityCalculationNormalItem(Items[i]).Calculate();
                        break;
                }                          
            }
        }
    }
}
