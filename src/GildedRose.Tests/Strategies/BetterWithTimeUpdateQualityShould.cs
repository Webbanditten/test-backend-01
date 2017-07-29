using GildedRose.Console.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using GildedRose.Console;
using Xunit;

namespace GildedRose.Tests.Strategies
{
    public class BetterWithTimeUpdateQualityShould : BaseStrategyTest
    {
        private readonly BackstagePassUpdateQualityStrategy _strategy = new BackstagePassUpdateQualityStrategy();

        [Fact]
        public void IncreaseQualityOfBackstagePassesByOneWith11DaysLeft()
        {
            var passes = GetBackstagePasses(sellIn: 11);
            var startingQuality = passes.Quality;

            _strategy.UpdateQuality(passes);

            passes.Quality.Should().Be(startingQuality + 1);
        }

        [Fact]
        public void IncreaseQualityOfBackstagePassesByTwoWith10DaysLeft()
        {
            var passes = GetBackstagePasses(sellIn: 10);
            var startingQuality = passes.Quality;

            _strategy.UpdateQuality(passes);

            passes.Quality.Should().Be(startingQuality + 2);
        }

        [Fact]
        public void IncreaseQualityOfBackstagePassesByTwoWith6DaysLeft()
        {
            var passes = GetBackstagePasses(sellIn: 6);
            var startingQuality = passes.Quality;

            _strategy.UpdateQuality(passes);

            passes.Quality.Should().Be(startingQuality + 2);
        }

        [Fact]
        public void IncreaseQualityOfBackstagePassesByThreeWith5DaysLeft()
        {
            var passes = GetBackstagePasses(sellIn: 5);
            var startingQuality = passes.Quality;

            _strategy.UpdateQuality(passes);

            passes.Quality.Should().Be(startingQuality + 3);
        }

        [Fact]
        public void IncreaseQualityOfBackstagePassesByThreeWith1DayLeft()
        {
            var passes = GetBackstagePasses(sellIn: 1);
            var startingQuality = passes.Quality;

            _strategy.UpdateQuality(passes);

            passes.Quality.Should().Be(startingQuality + 3);
        }

        [Fact]
        public void SetQualityOfBackstagePassesToZeroWith0DaysLeft()
        {
            var passes = GetBackstagePasses(sellIn: 0);
            var startingQuality = passes.Quality;

            _strategy.UpdateQuality(passes);

            passes.Quality.Should().Be(0);
        }

        private static StoreItem GetBackstagePasses(int sellIn = DefaultStartingSellin,
    int quality = DefaultStartingQuality)
        {
            return new StoreItem(
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality });
        }
    }
}
