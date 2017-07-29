using System;
using System.Linq;
using GildedRose.UI;
using GildedRose.UI.Strategies;
using Xunit;
using FluentAssertions;
using GildedRose.Tests.Strategies;

namespace GildedRose.UnitTests.Strategies
{
    public class DefaultUpdateQualityShould : BaseStrategyTest
    {
        private readonly DefaultUpdateQualityStrategy _strategy = new DefaultUpdateQualityStrategy();

        [Fact]
        public void ReduceNormalItemQualityByOne()
        {
            var normalItem = GetNormalItem();
            var startingQuality = normalItem.Quality;

            _strategy.UpdateQuality(normalItem);

            normalItem.Quality.Should().Be(startingQuality - 1);
        }

        [Fact]
        public void ReduceNormalItemSellInByOne()
        {
            var normalItem = GetNormalItem();
            var startingSellIn = normalItem.SellIn;

            _strategy.UpdateQuality(normalItem);

            normalItem.SellIn.Should().Be(startingSellIn - 1);
        }

        [Fact]
        public void ReduceNormalItemQualityByTwoWhenSellInLessThan1()
        {
            var normalItem = GetNormalItem(sellIn: 0);
            var startingQuality = normalItem.Quality;

            _strategy.UpdateQuality(normalItem);

            normalItem.Quality.Should().Be(startingQuality - 2);
        }

        [Fact]
        public void NotReduceQualityBelowZero()
        {
            var normalItem = GetNormalItem(quality: 0);
            var startingQuality = normalItem.Quality;

            _strategy.UpdateQuality(normalItem);

            normalItem.Quality.Should().Be(0);
        }

        private static StoreItem GetNormalItem(int sellIn = DefaultStartingSellin, 
            int quality = DefaultStartingQuality)
        {
            return new StoreItem(
                new Item { Name = "+5 Dexterity Vest", SellIn = sellIn, Quality = quality });
        }
    }
}