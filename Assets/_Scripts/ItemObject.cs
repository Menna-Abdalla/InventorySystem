using TMPro;
using UnityEngine.UI;
using System;

[Serializable]
public class ItemObject 
{
    public ItemStock itemStock ;
    public ItemObjectUI itemObjectUI;

}

[Serializable]
public class ItemStock
{

    public ItemData itemData;
    public int itemCount;

    public ItemStock (ItemData itemData, int itemCount)
    {
        this.itemData = itemData;
        this.itemCount = itemCount;
    }
}

[Serializable]
public class ItemObjectUI
{
    public TMP_Text count;
    public TMP_Text price;
    public Image icon;
}

