using System.Collections.Generic;

namespace GildedRose.Console
{
    public class ItemQualityService
    {
        public void UpdateQuality(IList<Item> Items)
        {
            foreach (var item in Items)
            {
                var storeItem = new StoreItem(item);
                storeItem.UpdateQuality();
            }
        }
    }
}