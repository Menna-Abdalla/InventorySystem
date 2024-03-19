using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemHandler 
{
    public ItemData data{ get; private set; }
    //public int CountInInventory { get; private set; }
    //public int CountinShop { get; private set; }

    public ItemHandler(ItemData source)
    {
        data = source;
        Purchase();
    }
    public void Purchase()
    {
        //data.countInInventory++;
        //data.countInShop--;
        
    }
    public void Sell()
    {
        data.countInInventory--;
        data.countInShop++;
    }
}
