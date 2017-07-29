using System;
using System.Linq;
using Xunit;
using FluentAssertions;
using GildedRose.Console;
using GildedRose.Console.Strategies;
using GildedRose.Tests.Strategies;

namespace GildedRose.Tests.Strategies
{
    public class ConjuredItemUpdateQualityShould : BaseStrategyTest
    {
        private readonly ConjuredItemUpdateQualityStrategy _strategy = new ConjuredItemUpdateQualityStrategy();

        [Fact]
        public void ReduceConjuredItemQualityByTwo()
        {
            var conjuredItem = GetConjuredItem();
            var startingQuality = conjuredItem.Quality;

            _strategy.UpdateQuality(conjuredItem);

            conjuredItem.Quality.Should().Be(startingQuality - 2);
        }

        [Fact]
        public void ReduceConjuredItemSellInByOne()
        {
            var conjuredItem = GetConjuredItem();
            var startingSellIn = conjuredItem.SellIn;

            _strategy.UpdateQuality(conjuredItem);

            conjuredItem.SellIn.Should().Be(startingSellIn - 1);
        }

        [Fact]
        public void ReduceConjuredItemQualityByFourWhenSellInLessThan1()
        {
            var conjuredItem = GetConjuredItem(sellIn: 0);
            int startingQuality = conjuredItem.Quality;

            _strategy.UpdateQuality(conjuredItem);

            conjuredItem.Quality.Should().Be(startingQuality - 4);
        }

        [Fact]
        public void NotReduceQualityBelowZero()
        {
            var conjuredItem = GetConjuredItem(quality: 0);
            var startingQuality = conjuredItem.Quality;

            _strategy.UpdateQuality(conjuredItem);

            conjuredItem.Quality.Should().Be(0);
        }

        private static StoreItem GetConjuredItem(int sellIn = DefaultStartingSellin, 
            int quality = DefaultStartingQuality)
        {
            return new StoreItem(
                new Item { Name = "Conjured Mana Cake", SellIn = sellIn, Quality = quality });
        }
    }
}