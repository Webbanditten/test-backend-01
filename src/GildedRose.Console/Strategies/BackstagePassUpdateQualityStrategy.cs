using GildedRose.Console.Interfaces;

namespace GildedRose.Console.Strategies
{
    public class BackstagePassUpdateQualityStrategy : IUpdateQualityStrategy
    {
        public void UpdateQuality(StoreItem item)
        {
            item.IncrementQuality();
            item.SellIn--;
            if (item.SellIn < 10)
            {
                item.IncrementQuality();
            }
            if (item.SellIn < 5)
            {
                item.IncrementQuality();
            }
            if (item.SellIn < 0)
            {
                item.Expire();
            }
        }
    }
}