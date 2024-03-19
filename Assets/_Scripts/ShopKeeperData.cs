using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeperData : MonoBehaviour
{
    [SerializeField] string shopName;
    public string shopID;
    public List<ItemStock> stocks;
    //public List<ItemData> shopItem;
    //public Dictionary<ItemData, int> shopItems;
}
