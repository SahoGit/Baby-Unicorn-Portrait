using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseWithCoin : MonoBehaviour
{
    public void purchaseItemWithCoin()
    {
        int price = PlayerPrefs.GetInt("ItemPrice");
        string item = PlayerPrefs.GetString("ItemToPurchase");

        if (PrefsManager.instance.GetPlayerScore() > price)
        {

        }
    }
}
