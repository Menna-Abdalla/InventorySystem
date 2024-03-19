using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory Item Data")]
public class ItemData : ScriptableObject
{
    public string ItemName;
    public int id;
    public Sprite icon;
    public int buyPrice;
    public int sellCost;
    public int shopID;
    public int originalShopID;
    public int countInInventory;
    public int countInShop;
    public bool isInventory;

}
