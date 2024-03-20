using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem instance;
    public Dictionary<ItemData, GameObject> inventoryItemsDictionary = new Dictionary<ItemData, GameObject>();

    [SerializeField] GameObject inventoryItemPrefab;
    [SerializeField] Transform inventoryItemParent;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    public void Purchase(ItemData data)
    {
        if (!ValidatePurchase(data)) return;

        EventsManager.ManageStock(data, "purchase");
        if (inventoryItemsDictionary.TryGetValue(data, out GameObject itemObject))
        {
            itemObject.GetComponent<InventoryItemObject>().increaseStock(data); //.inventoryItem.itemStock.itemCount++;
        }
        else
        {
            GameObject itemPrefab = Instantiate(inventoryItemPrefab, inventoryItemParent);
            itemPrefab.GetComponent<InventoryItemObject>().AddData(data);
            inventoryItemsDictionary.Add(data, itemPrefab);
        }
    }
    public bool ValidatePurchase(ItemData data)
    {
        return (CoinsManager.instance.playerData.Coins >= data.buyPrice);
    }

    public void Sell(ItemData data, int shopID)
    {
        //if (data.originalShopID == shopID)

            data.shopID = shopID;
            EventsManager.ManageStock(data, "sell");


        //if (inventoryItemsDictionary.TryGetValue(data, out ItemHandler handler))
        //{
        //    CoinsManager.instance.playerData.Coins += data.buyPrice;
        //    handler.Sell();

        //    if (data.countInInventory == 0)
        //    {
        //        inventoryHandler.Remove(handler);
        //        inventoryItemsDictionary.Remove(data);
        //    }

        //}
    }
}
