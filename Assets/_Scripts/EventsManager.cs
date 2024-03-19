using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class EventsManager 
{
    #region Delegutes and events
    public delegate void dPurchace(ItemData data, string processName); // (int id);
    public static event dPurchace ePurchace;

    

    #endregion

    #region Functions

    public static void Purchace(ItemData data, string processName)
    {
        if (ePurchace != null)
        {
            ePurchace(data, processName);
        }
    }
   

    #endregion


}
