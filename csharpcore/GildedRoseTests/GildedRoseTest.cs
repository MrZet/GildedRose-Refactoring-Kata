using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {

        #region SellIn Tests
        [Fact]
        public void TestSellInReductionWithPositiveValue()
        {
            IList<ExpirableItem> Items = new List<ExpirableItem>{
                new ExpirableItem {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20}};
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(9, Items[0].SellIn);    
        }

        [Fact]
        public void TestSellInReductionWithNegativeValue()
        {
            IList<ExpirableItem> Items = new List<ExpirableItem>{
                new ExpirableItem {Name = "+5 Dexterity Vest", SellIn = -7, Quality = 20}};
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(-8, Items[0].SellIn);    
        }
        #endregion
        
        #region Normal Item Tests
        [Fact]
        public void TestQualityForNormalItem()
        {
            IList<ExpirableItem> Items = new List<ExpirableItem>{
                new ExpirableItem {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20}};
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(19, Items[0].Quality);    
        }
        
        [Fact]
        public void TestQualityForNormalItemWithMinQualityValue()
        {
            IList<ExpirableItem> Items = new List<ExpirableItem>{
                new ExpirableItem {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 0}};
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(0, Items[0].Quality);    
        }
        
        [Fact]
        public void TestQualityForNormalItemWithZeroSellInValue()
        {
            IList<ExpirableItem> Items = new List<ExpirableItem>{
                new ExpirableItem {Name = "+5 Dexterity Vest", SellIn = 1, Quality = 3}};
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(2, Items[0].Quality);    
        }
        
        [Fact]
        public void TestQualityForNormalItemWhenExpired()
        {
            IList<ExpirableItem> Items = new List<ExpirableItem>{
                new ExpirableItem {Name = "+5 Dexterity Vest", SellIn = 0, Quality = 3}};
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(1, Items[0].Quality);    
        }
        #endregion
    
        #region Aged Brie Tests
        [Fact]
        public void TestQualityForAgedBrie()
        {
            IList<ExpirableItem> Items = new List<ExpirableItem>{
                new ExpirableItem {Name = "Aged Brie", SellIn = 10, Quality = 20}};
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(21, Items[0].Quality);    
        }
        
        [Fact]
        public void TestQualityForAgedBrieWithMaxQualityValue()
        {
            IList<ExpirableItem> Items = new List<ExpirableItem>{
                new ExpirableItem {Name = "Aged Brie", SellIn = 10, Quality = 50}};
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(50, Items[0].Quality);    
        }
        
        [Fact]
        public void TestQualityForAgedBrieWithZeroSellInValue()
        {
            IList<ExpirableItem> Items = new List<ExpirableItem>{
                new ExpirableItem {Name = "Aged Brie", SellIn = 1, Quality = 3}};
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(4, Items[0].Quality);    
        }
        
        [Fact]
        public void TestQualityForAgedBrieWhenExpired()
        {
            IList<ExpirableItem> Items = new List<ExpirableItem>{
                new ExpirableItem {Name = "Aged Brie", SellIn = 0, Quality = 3}};
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(5, Items[0].Quality);    
        }
        #endregion
        
        #region BackstagePass Tests
        [Fact]
        public void TestQualityForBackstagePass()
        {
            IList<ExpirableItem> Items = new List<ExpirableItem>{
                new ExpirableItem {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 20}};
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(21, Items[0].Quality);    
        }

        [Fact]
        public void TestQualityForBackstagePassWhenTenDaysToConcert()
        {
            IList<ExpirableItem> Items = new List<ExpirableItem>{
                new ExpirableItem {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 20}};
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(22, Items[0].Quality);    
        }

        [Fact]
        public void TestQualityForBackstagePassWhenFiveDaysToConcert()
        {
            IList<ExpirableItem> Items = new List<ExpirableItem>{
                new ExpirableItem {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 20}};
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(23, Items[0].Quality);    
        }

        [Fact]
        public void TestQualityForBackstagePassWhenZeroDaysToConcert()
        {
            IList<ExpirableItem> Items = new List<ExpirableItem>{
                new ExpirableItem {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20}};
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(0, Items[0].Quality);    
        }

        [Fact]
        public void TestQualityForBackstagePassWhenExpired()
        {
            IList<ExpirableItem> Items = new List<ExpirableItem>{
                new ExpirableItem {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 20}};
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(0, Items[0].Quality);    
        }
        
        [Fact]
        public void TestQualityForBackstagePassWith48QualityWhenFiveDaysToConcert()
        {
            IList<ExpirableItem> Items = new List<ExpirableItem>{
                new ExpirableItem {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 48}};
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(50, Items[0].Quality);    
        }

        [Fact]
        public void TestQualityForBackstagePassWith49QualityWhenFiveDaysToConcert()
        {
            IList<ExpirableItem> Items = new List<ExpirableItem>{
                new ExpirableItem {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49}};
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(50, Items[0].Quality);    
        }

        [Fact]
        public void TestQualityForBackstagePassWith50QualityWhenFiveDaysToConcert()
        {
            IList<ExpirableItem> Items = new List<ExpirableItem>{
                new ExpirableItem {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 50}};
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(50, Items[0].Quality);    
        }        
      
        #endregion
        
        #region Sulfuras Item Tests
        [Fact]
        public void TestQualityForSulfuras()
        {
            IList<ExpirableItem> Items = new List<ExpirableItem>{
                new ExpirableItem {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80}};
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(80, Items[0].Quality);    
        }
        
        [Fact]
        public void TestQualityForSulfurasWhenExpired()
        {
            IList<ExpirableItem> Items = new List<ExpirableItem>{
                new ExpirableItem {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80}};
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(80, Items[0].Quality);    
        }

        #endregion      
    
        #region Conjured Item Tests
        [Fact]
        public void TestQualityForConjuredItem()
        {
            IList<ExpirableItem> Items = new List<ExpirableItem>{
                new ExpirableItem {Name = "Conjured Mana Cake", SellIn = 10, Quality = 20, ExpirationSpeed = 2}};
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(18, Items[0].Quality);    
        }

        [Fact]
        public void TestQualityForConjuredAgedBrie()
        {
            IList<ExpirableItem> Items = new List<ExpirableItem>{
                new ExpirableItem {Name = "Conjured Aged Brie", SellIn = 10, Quality = 20, ExpirationSpeed = 2}};
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(22, Items[0].Quality);    
        }

        [Fact]
        public void TestQualityForConjuredBackstagePassWhen10DaysToConcert()
        {
            IList<ExpirableItem> Items = new List<ExpirableItem>{
                new ExpirableItem {Name = "Conjured Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 20, ExpirationSpeed = 2}};
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(24, Items[0].Quality);    
        }

        [Fact]
        public void TestQualityForConjuredBackstagePassWhen5DaysToConcert()
        {
            IList<ExpirableItem> Items = new List<ExpirableItem>{
                new ExpirableItem {Name = "Conjured Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 20, ExpirationSpeed = 2}};
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(26, Items[0].Quality);    
        }
        #endregion

        #region Item Builder Test
        [Fact]
        public void TestUsingBuilder_QualityForNormalItem()
        {
            var builder = new BuildNormalItem();
            builder.SetName("Mangusta");
            builder.SetSellIn(10);
            builder.SetQuality(20);
            builder.SetExpirationDate();
            var item = builder.Build();

            IList<ExpirableItem> Items = new List<ExpirableItem>{item};
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(19, Items[0].Quality);    
            Assert.Equal(1, Items[0].ExpirationSpeed);   
        }

        [Fact]
        public void TestUsingBuilder_QualityForConjuredItem()
        {
            var builder = new BuildConjuredItem();
            builder.SetName("Mangusta");
            builder.SetSellIn(10);
            builder.SetQuality(20);
            builder.SetExpirationDate();
            var item = builder.Build();

            IList<ExpirableItem> Items = new List<ExpirableItem>{item};
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(18, Items[0].Quality);    
            Assert.Equal(2, Items[0].ExpirationSpeed);   
            Assert.Equal("Conjured Mangusta", Items[0].Name);   
        }
        #endregion
    }
}
