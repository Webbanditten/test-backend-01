using GildedRose.Console.Interfaces;

namespace GildedRose.Console.Strategies
{
    public class BetterWithTimeUpdateQualityStrategy : IUpdateQualityStrategy
    {
        public void UpdateQuality(StoreItem item)
        {
            item.IncrementQuality();
            item.SellIn--;
            if (item.SellIn < 0)
            {
                item.IncrementQuality();
            }
        }
    }
}