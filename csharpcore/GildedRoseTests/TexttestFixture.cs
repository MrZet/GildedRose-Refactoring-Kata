
using GildedRoseKata;

using System;
using System.Collections.Generic;

namespace GildedRoseTests
{
    public static class TexttestFixture
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            IList<ExpirableItem> ExpirableItems = new List<ExpirableItem>{
                new ExpirableItem {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new ExpirableItem {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new ExpirableItem {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new ExpirableItem {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new ExpirableItem {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                new ExpirableItem
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new ExpirableItem
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new ExpirableItem
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
                // this conjured ExpirableItem does not work properly yet
                new ExpirableItem {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6, ExpirationSpeed = 2}
            };

            var app = new GildedRose(ExpirableItems);

            int days = 2;
            if (args.Length > 0)
            {
                days = int.Parse(args[0]) + 1;
            }

            for (var i = 0; i < days; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < ExpirableItems.Count; j++)
                {
                    System.Console.WriteLine(ExpirableItems[j].Name + ", " + ExpirableItems[j].SellIn + ", " + ExpirableItems[j].Quality);
                }
                Console.WriteLine("");
                app.UpdateQuality();
            }
        }
    }
}
