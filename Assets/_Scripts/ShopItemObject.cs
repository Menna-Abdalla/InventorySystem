using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemObject : MonoBehaviour
{
    public ItemObject shopItem;
    private void OnEnable()
    {
        EventsManager.ePurchace += decreaseStock;
    }
    private void OnDisable()
    {
        EventsManager.ePurchace -= decreaseStock;
    }
    public void OnShopItemClick()
    {
        if (shopItem.itemStock.itemCount == 0) return;
        InventorySystem.instance.Purchase(shopItem.itemStock.itemData);
    }

    public void increaseStock(ItemData data)
    {
        shopItem.itemStock.itemCount++;
        shopItem.itemObjectUI.count.text = shopItem.itemStock.itemCount.ToString();

    }
    private void decreaseStock(ItemData data, string processName)
    {
        if (processName == "purchase")
            if (data.shopID == shopItem.itemStock.itemData.shopID && data.name == shopItem.itemStock.itemData.name)
            {
                shopItem.itemStock.itemCount--;
                shopItem.itemObjectUI.count.text = shopItem.itemStock.itemCount.ToString();
            }
    }
}
