using System;
using System.Linq;
using Xunit;
using FluentAssertions;
using GildedRose.Console;
using GildedRose.Console.Strategies;
using GildedRose.Tests.Strategies;

namespace GildedRose.Tests.Strategies
{
    public class LegendaryUpdateQualityShould : BaseStrategyTest
    {
        private readonly LegendaryUpdateQualityStrategy _strategy = new LegendaryUpdateQualityStrategy();
        [Fact]
        public void NotChangeQualityOfSulfuras()
        {
            var sulfuras = GetSulfuras();
            var startingQuality = sulfuras.Quality;

            _strategy.UpdateQuality(sulfuras);

            sulfuras.Quality.Should().Be(startingQuality);
        }

        [Fact]
        public void NotChangeSellInOfSulfuras()
        {
            var sulfuras = GetSulfuras();
            var startingSellIn = sulfuras.SellIn;

            _strategy.UpdateQuality(sulfuras);

            sulfuras.SellIn.Should().Be(startingSellIn);
        }
        private static StoreItem GetSulfuras()
        {
            return new StoreItem(
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 });
        }
    }
}