using System;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                switch (Items[i].Name)
                {
                    case "Aged Brie":
                        new GildedRoseKata.QualityCalculationAgedBrie(Items[i]).Calculate();
                        break;
                    case "Sulfuras, Hand of Ragnaros":
                        new GildedRoseKata.QualityCalculationSulfuras(Items[i]).Calculate();
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":
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
