using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class EventsManager 
{
    #region Delegutes and events
    public delegate void dManageStock(ItemData data, string processName); // (int id);
    public static event dManageStock eManageStock;

    public delegate void dATM_Error( string errorName); // (int id);
    public static event dATM_Error eATM_Error;

    #endregion

    #region Functions

    public static void ManageStock(ItemData data, string processName)
    {
        if (eManageStock != null)
        {
            eManageStock(data, processName);
        }
    }

    public static void ATM_Error( string errorName)
    {
        if (eATM_Error != null)
        {
            eATM_Error(errorName);
        }
    }


    #endregion


}
