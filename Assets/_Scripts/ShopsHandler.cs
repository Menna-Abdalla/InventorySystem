using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ShopsHandler : MonoBehaviour
{
    public ShopKeeperData[] shopKeeperItem;
    public GameObject[] btnHolder;
    public GameObject btnItem;
    //public List<GameObject> btnItems = new List<GameObject>();
    private void OnEnable()
    {
        EventsManager.eManageStock += ManageStock;
    }
    private void OnDisable()
    {
        EventsManager.eManageStock -= ManageStock;
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int shopIndex = 0; shopIndex < shopKeeperItem.Length; shopIndex++)
        {
            int shopItemslength = shopKeeperItem[shopIndex].stocks.Count;

            for (int shopItemIndex = 0; shopItemIndex < shopItemslength; shopItemIndex++)
            {
                InstantiateBtn(shopIndex, shopItemIndex);
            }
        }
    }

    public void ManageStock(ItemData data, string processName)
    {
        if (processName == "sell")
        {
            for (int i = 0; i < btnHolder[data.shopID - 1].transform.childCount; i++)
            {
                ShopItemObject shopItemBtn = btnHolder[data.shopID - 1].transform.GetChild(i).GetComponent<ShopItemObject>();
                if (data.name == shopItemBtn.shopItem.itemStock.itemData.name)
                {
                    shopItemBtn.increaseStock(data);
                    return;
                }
               
            }
            int shopIndex = data.shopID - 1;
            shopKeeperItem[shopIndex].stocks.Add(new ItemStock(data,1));
            int shopItemIndex = shopKeeperItem[shopIndex].stocks.Count-1;
            InstantiateBtn(shopIndex, shopItemIndex);
        }
    }

    public void InstantiateBtn(int i, int j)
    {
        GameObject btn = Instantiate(btnItem, btnHolder[i].transform);
        btn.GetComponent<ShopItemObject>().shopItem.itemStock = shopKeeperItem[i].stocks[j];
        btn.GetComponent<ShopItemObject>().shopItem.itemObjectUI.price.text = shopKeeperItem[i].stocks[j].itemData.buyPrice.ToString();
        btn.GetComponent<ShopItemObject>().shopItem.itemObjectUI.count.text = shopKeeperItem[i].stocks[j].itemCount.ToString();
        btn.GetComponent<ShopItemObject>().shopItem.itemObjectUI.icon.sprite = shopKeeperItem[i].stocks[j].itemData.icon;

    }
}
