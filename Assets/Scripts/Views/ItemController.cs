using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    public int itmeId;
    public bool isOnAd;
    public GameObject itemBtn;
    public GameObject lockBtn;
    public GameObject coinPurchasePanel;
    public int itemPrice;
    //public Text purchaseText;
    //public Text buttonPurchaseText;
    public string itemName;
    //public GameObject lockImage;
    //public GameObject animalImage;
    //public GameObject watchAdButton;
    //public GameObject watchAdPanel;
    // Start is called before the first frame update

    void OnValidate()
    {
        lockBtn = this.gameObject.transform.GetChild(0).gameObject;
        itemBtn = this.gameObject.transform.gameObject;
    }
    void Start()
    {
        
        unlockItems();
        
        if (PlayerPrefs.GetInt(itemName + itmeId) == 1)
        {
            itemBtn.GetComponent<Button>().interactable = true;
            lockBtn.SetActive(false);
            isOnAd = false;
        }
        else
        {
            if (isOnAd)
            {
                itemBtn.GetComponent<Button>().interactable = false;
            }
            lockBtn.SetActive(true);
        }
    }
    
    public void unlockWithReward()
    {
        PlayerPrefs.SetString("ItemToPurchase", itemName + itmeId);
        PlayerPrefs.SetInt("ItemPrice", itemPrice);
        //Debug.Log(PlayerPrefs.GetString("ItemToPurchase"));
        //Debug.Log(PlayerPrefs.GetInt("ItemPrice"));
        coinPurchasePanel.SetActive(true);
        //purchaseText.text = "Unlock This Item with " + itemPrice + " Reward";
        //buttonPurchaseText.text = itemPrice.ToString();
    }
    public void itemUnlocked()
    {
        Debug.Log(itemName + itmeId);
        PlayerPrefs.SetInt(itemName + itmeId, 1);
        itemBtn.GetComponent<Button>().interactable = true;
        lockBtn.SetActive(false);
    }

    void unlockItems()
    {
        PlayerPrefs.SetInt("Dress2", 1);
        PlayerPrefs.SetInt("Dress4", 1);
        ///my side unloack al////
         PlayerPrefs.SetInt("Dress1", 1);
          PlayerPrefs.SetInt("Dress0", 1);
        PlayerPrefs.SetInt("Dress3", 1);
        PlayerPrefs.SetInt("Dress5", 1);
        PlayerPrefs.SetInt("Dress6", 1);
        PlayerPrefs.SetInt("Dress7", 1);
        PlayerPrefs.SetInt("Dress8", 1);
         PlayerPrefs.SetInt("Dress9", 1);

        /// end /////
        PlayerPrefs.SetInt("Horn1", 1);
        PlayerPrefs.SetInt("Horn5", 1);


        ///// my sie start////
         PlayerPrefs.SetInt("Horn0", 1);
          PlayerPrefs.SetInt("Horn2", 1);
           PlayerPrefs.SetInt("Horn3", 1);
           PlayerPrefs.SetInt("Horn4", 1);
             PlayerPrefs.SetInt("Horn6", 1);
              PlayerPrefs.SetInt("Horn7", 1);
               PlayerPrefs.SetInt("Horn8", 1);
                PlayerPrefs.SetInt("Horn9", 1);
                 PlayerPrefs.SetInt("Horn10", 1);
                  PlayerPrefs.SetInt("Horn11", 1);
                   PlayerPrefs.SetInt("Horn12", 1);
                    PlayerPrefs.SetInt("Horn13", 1);
                     PlayerPrefs.SetInt("Horn14", 1);
        /// end ////
        PlayerPrefs.SetInt("Shoes1", 1);
        PlayerPrefs.SetInt("Shoes3", 1);
        ////// my ///
        PlayerPrefs.SetInt("Shoes2", 1);
            PlayerPrefs.SetInt("Shoes0", 1);
        PlayerPrefs.SetInt("Shoes4", 1);
        PlayerPrefs.SetInt("Shoes5", 1);
        PlayerPrefs.SetInt("Shoes6", 1);
        PlayerPrefs.SetInt("Shoes7", 1);
        PlayerPrefs.SetInt("Shoes8", 1);
        //////// end //
        PlayerPrefs.SetInt("Lens0", 1);
        PlayerPrefs.SetInt("Lens4", 1);
        ////mu ///
         PlayerPrefs.SetInt("Lens1", 1);
        PlayerPrefs.SetInt("Lens2", 1);
         PlayerPrefs.SetInt("Lens3", 1);
        PlayerPrefs.SetInt("Lens5", 1);
         PlayerPrefs.SetInt("Lens6", 1);
        PlayerPrefs.SetInt("Lens7", 1);
         PlayerPrefs.SetInt("Lens8", 1);
        PlayerPrefs.SetInt("Lens9", 1);
         PlayerPrefs.SetInt("Lens10", 1);
        PlayerPrefs.SetInt("Lens11", 1);
         PlayerPrefs.SetInt("Lens12", 1);
        PlayerPrefs.SetInt("Lens13", 1);
         PlayerPrefs.SetInt("Lens14", 1);
        PlayerPrefs.SetInt("Lens15", 1);
         PlayerPrefs.SetInt("Lens16", 1);
        PlayerPrefs.SetInt("Lens17", 1);
        ///
    }

    public void itemUnlockWithAd()
    {
        AdsManager.Instance.ShowRewarded(() =>
        {
            itemUnlocked();
        }, "Counter Incremented");
    }
}
