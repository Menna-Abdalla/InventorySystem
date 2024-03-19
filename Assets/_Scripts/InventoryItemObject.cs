using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryItemObject : MonoBehaviour
{
    public ItemObject inventoryItem = new ItemObject();
    public GameObject ShopSelectionPanel;


    private void OnEnable()
    {
        EventsManager.ePurchace += decreaseStock;
    }
    private void OnDisable()
    {
        EventsManager.ePurchace -= decreaseStock;
    }


    public void OnInventoryItemClick()
    {
        ShopSelectionPanel.SetActive(true);
        //if (shopItem.itemStock.itemCount == 0) return;
       
    }
    public void OnShopSelectionClick(int shopID)
    {
        ShopSelectionPanel.SetActive(false);
        InventorySystem.instance.Sell(inventoryItem.itemStock.itemData, shopID);
    }

    public void AddData(ItemData source)
    {
        inventoryItem.itemStock.itemData = source;
        inventoryItem.itemObjectUI.price.text = inventoryItem.itemStock.itemData.buyPrice.ToString();
        inventoryItem.itemObjectUI.icon.sprite = inventoryItem.itemStock.itemData.icon;
        increaseStock(inventoryItem.itemStock.itemData);
    }
    public void increaseStock(ItemData data)
    {
        inventoryItem.itemStock.itemCount++;
        inventoryItem.itemObjectUI.count.text = inventoryItem.itemStock.itemCount.ToString();
    }
    public void decreaseStock(ItemData data, string processName)
    {
        if(processName == "sell")
        {
            if (data.name == inventoryItem.itemStock.itemData.name)
            {
                inventoryItem.itemStock.itemCount--;
                inventoryItem.itemObjectUI.count.text = inventoryItem.itemStock.itemCount.ToString();
                if (inventoryItem.itemStock.itemCount == 0)
                {
                    InventorySystem.instance.inventoryItemsDictionary.Remove(data);
                    Destroy(gameObject, .2f);
                }
            }

                
        }
    }
}
