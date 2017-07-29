using GildedRose.Console.Interfaces;

namespace GildedRose.Console.Strategies
{
    public class ConjuredItemUpdateQualityStrategy : IUpdateQualityStrategy
    {
        public void UpdateQuality(StoreItem item)
        {
            item.DecrementQuality();
            item.DecrementQuality();
            if (item.SellIn <= 0)
            {
                item.DecrementQuality();
                item.DecrementQuality();
            }
            item.SellIn--;
        }
    }
}