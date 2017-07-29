using FluentAssertions;
using GildedRose.UI;
using Xunit;

namespace GildedRose.Tests
{
    public class StoreItemUpdateQualityShould
    {
        private const int SystemMaxQuality = 50;
        private const int DefaultStartingSellin = 10;
        private const int DefaultStartingQuality = 20;

        [Fact]
        public void ReduceNormalItemQualityByOne()
        {
            var normalItem = GetNormalItem();
            var startingQuality = normalItem.Quality;

            normalItem.UpdateQuality();

            normalItem.Quality.Should().Be(startingQuality - 1);
        }

        [Fact]
        public void ReduceNormalItemSellInByOne()
        {
            var normalItem = GetNormalItem();
            var startingSellIn = normalItem.SellIn;

            normalItem.UpdateQuality();

            normalItem.SellIn.Should().Be(startingSellIn - 1);
        }

        [Fact]
        public void ReduceNormalItemQualityByTwoWhenSellInLessThan1()
        {
            var normalItem = GetNormalItem(sellIn: 0);
            var startingQuality = normalItem.Quality;

            normalItem.UpdateQuality();

            normalItem.Quality.Should().Be(startingQuality - 2);
        }

        [Fact]
        public void NotReduceQualityBelowZero()
        {
            var normalItem = GetNormalItem(quality: 0);
            var startingQuality = normalItem.Quality;

            normalItem.UpdateQuality();

            normalItem.Quality.Should().Be(0);
        }

        [Fact]
        public void IncreaseQualityOfAgedBrie()
        {
            var agedBrie = GetAgedBrie();
            var startingQuality = agedBrie.Quality;

            agedBrie.UpdateQuality();

            agedBrie.Quality.Should().Be(startingQuality + 1);
        }

        [Fact]
        public void NotIncreaseQualityOfAgedBriePast50()
        {
            var agedBrie = GetAgedBrie(quality: SystemMaxQuality);
            var startingQuality = agedBrie.Quality;

            agedBrie.UpdateQuality();

            agedBrie.Quality.Should().Be(startingQuality);
        }

        [Fact]
        public void IncreaseQualityOfAgedBrieBy2AfterSellIn()
        {
            var agedBrie = GetAgedBrie(sellIn: 0);
            var startingQuality = agedBrie.Quality;

            agedBrie.UpdateQuality();

            agedBrie.Quality.Should().Be(startingQuality + 2);
        }

        [Fact]
        public void NotChangeQualityOfSulfuras()
        {
            var surlfuras = GetSulfuras();
            var startingQuality = surlfuras.Quality;

            surlfuras.UpdateQuality();

            surlfuras.Quality.Should().Be(startingQuality);
        }

        [Fact]
        public void NotChangeSellInOfSulfuras()
        {
            var surlfuras = GetSulfuras();
            var startingSellIn = surlfuras.SellIn;

            surlfuras.UpdateQuality();

            surlfuras.SellIn.Should().Be(startingSellIn);
        }

        [Fact]
        public void IncreaseQualityOfBackstagePassesByOneWith11DaysLeft()
        {
            var passes = GetBackstagePasses(sellIn: 11);
            var startingQuality = passes.Quality;

            passes.UpdateQuality();

            passes.Quality.Should().Be(startingQuality + 1);
        }

        [Fact]
        public void IncreaseQualityOfBackstagePassesByTwoWith10DaysLeft()
        {
            var passes = GetBackstagePasses(sellIn: 10);
            var startingQuality = passes.Quality;

            passes.UpdateQuality();

            passes.Quality.Should().Be(startingQuality + 2);
        }

        [Fact]
        public void IncreaseQualityOfBackstagePassesByTwoWith6DaysLeft()
        {
            var passes = GetBackstagePasses(sellIn: 6);
            var startingQuality = passes.Quality;

            passes.UpdateQuality();

            passes.Quality.Should().Be(startingQuality + 2);
        }

        [Fact]
        public void IncreaseQualityOfBackstagePassesByThreeWith5DaysLeft()
        {
            var passes = GetBackstagePasses(sellIn: 5);
            var startingQuality = passes.Quality;

            passes.UpdateQuality();

            passes.Quality.Should().Be(startingQuality + 3);
        }

        [Fact]
        public void IncreaseQualityOfBackstagePassesByThreeWith1DayLeft()
        {
            var passes = GetBackstagePasses(sellIn: 1);
            var startingQuality = passes.Quality;

            passes.UpdateQuality();

            passes.Quality.Should().Be(startingQuality + 3);
        }

        [Fact]
        public void SetQualityOfBackstagePassesToZeroWith0DaysLeft()
        {
            var passes = GetBackstagePasses(sellIn: 0);
            var startingQuality = passes.Quality;

            passes.UpdateQuality();

            passes.Quality.Should().Be(0);
        }


        private static StoreItem GetNormalItem(int sellIn = DefaultStartingSellin,
            int quality = DefaultStartingQuality)
        {
            return new StoreItem(
                new Item { Name = "+5 Dexterity Vest", SellIn = sellIn, Quality = quality });
        }

        private static StoreItem GetAgedBrie(int sellIn = DefaultStartingSellin,
            int quality = DefaultStartingQuality)
        {
            return new StoreItem(
                new Item { Name = "Aged Brie", SellIn = sellIn, Quality = quality });
        }

        private static StoreItem GetSulfuras()
        {
            return new StoreItem(
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 });
        }

        private static StoreItem GetBackstagePasses(int sellIn = DefaultStartingSellin,
    int quality = DefaultStartingQuality)
        {
            return new StoreItem(
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality });
        }


    }
}