using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Linq;
using System;
using Random = UnityEngine.Random;

public class DressUpView : MonoBehaviour
{
    #region Variables,Constants & Initializers

    public GameObject Loading;
    public Image LoadingFilled;

    public Sprite[] BodyList;
    public Sprite[] FaceList;
    public Sprite[] EarList;
    public Sprite[] leftLegList;
    public Sprite[] RightLegList;
    public Sprite[] LeftArmList;
    public Sprite[] RightArmList;
    public Sprite[] EyesList;
    public Image Body;
    public Image Face;
    public Image Ear;
    public Image leftLeg;
    public Image RightLeg;
    public Image LeftArm;
    public Image RightArm;
    public Image Eyes;

    public Image LoadingBody;
    public Image LoadingFace;
    public Image LoadingEar;
    public Image LoadingleftLeg;
    public Image LoadingRightLeg;
    public Image LoadingLeftArm;
    public Image LoadingRightArm;
    public Image LoadingEyes;

    public GameObject otherDress;

    private int lastTag = 0;
    private int currentTag = -1;
    private int LastClickGrid;
    private bool flagBtnClick;
    private int NextCount;
    private int[] NextArr;

    public GameObject loadingImage;
    public GameObject Character, CharacterBody;
    public RectTransform CharacterEndPoint;
    public GameObject characterMakeup, characterMakeupPosition;
    public GameObject dressedUnicorn;
    public GameObject MainGrid;
    public Sprite[] DressesUniCorn;
    public Image Dress;
    public Image Horn;
    public Image Veil;
    public Image hairs;
    public Image HeadWear;
    public Image Necklace;
    public Image Earring;
    public Image Flower;
    public Image Shoes;

    /// Makeup Items Image Here /// 

    public Image Lens;
    public Image LeftEyeShade;
    public Image RightEyeShade;
    public Image LeftEyeLiner;
    public Image RightEyeLiner;
    public Image LeftEyeLashes;
    public Image RightEyeLashes;
    public Image LeftCheekShade;
    public Image RightCheekShade;
    public Image Lips;
    public Image EarRing;


    public GameObject lastpopup, treamentText;
    public RectTransform treatmentTextEndPoint;
    public Image popupImage;
    public GameObject originalPopup;
    public GameObject levelEndParticles;
    public GameObject nextButton;
    public GameObject nextSceneButton;

    public GameObject ClickedBtnRef;

    public List<RectTransform> ItemsEndPoints;
    public Image CurrentItem;
    public List<GameObject> ScrollContentItems;
    public List<GameObject> CareerContentItems;

    public List<GameObject> Grids;
    public RectTransform GridStartPoint;
    public RectTransform GridEndPoint;

    public GameObject Next;
    public GameObject levelCompletedParticles;

    public int counter = 0;

    public GameObject[] clickedButtonArray;
    public GameObject noInternetConect;

    public Sprite[] taskMessageSprite;
    public Image taskMessageImage;
    public GameObject taskePanel;

    public GameObject levelCompletePanel;
    public GameObject objectivePanel;

    private int unicornId;

    public GameObject bgSound;

    private int itemCount;

    public Text objectiveText;

    public GameObject mainGrid;
    public GameObject[] CareerGrid;

    public Text animalName;
    public GameObject coinPurchasePanel;
    public GameObject LowCoinPurchasePanel;
    public Text purchaseText;
    public Text buttonPurchaseText;

    public Sprite clickedItemImage;

    public Button[] mainItems;
    #endregion

    #region Lifecycle Methods
    void OnAwake()
    {
        Character.SetActive(false);
    }

    // Use this for initialization
    void Start()
    {
        //PlayerPrefs.SetInt("PlayingLevel", 7);
        //PrefsManager.instance.SetPlayerScore(2000);
        for (int i = 0; i < CareerGrid.Length; i++)
        {
            CareerGrid[i].SetActive(false);
        }
        if (PlayerPrefs.GetInt("CareerMode") == 1)
        {
            nextButton.transform.localPosition -= new Vector3(0, 102, 0);
            mainGrid.SetActive(false);
            CareerGrid[PlayerPrefs.GetInt("PlayingLevel") - 6].SetActive(true);
            if (PlayerPrefs.GetInt("PlayingLevel") == 6)
            {
                objectiveText.text = "Please select dress for " + PlayerPrefs.GetString("SelectedPetName");
            }
            if (PlayerPrefs.GetInt("PlayingLevel") == 7)
            {
                objectiveText.text = "Please select shoes for " + PlayerPrefs.GetString("SelectedPetName");
            }
            if (PlayerPrefs.GetInt("PlayingLevel") == 8)
            {
                objectiveText.text = "Please select horn for " + PlayerPrefs.GetString("SelectedPetName");
            }
            if (PlayerPrefs.GetInt("PlayingLevel") == 9)
            {
                objectiveText.text = "Please select lens for " + PlayerPrefs.GetString("SelectedPetName");
            }
        } else
        {
            mainGrid.SetActive(true);
            //for (int i = 0; i < CareerGrid.Length; i++)
            //{
            //    CareerGrid[i].SetActive(false);
            //}
        }
        if (PlayerPrefs.GetInt("PetCareMode") == 1)
        {
            objectiveText.text = "DressUp " + PlayerPrefs.GetString("SelectedPetName") + " to look fantastic";
        }
        if (PlayerPrefs.GetInt("MusicContoller") == 1)
        {
            bgSound.GetComponent<AudioSource>().Play();
        }
        else
        {
            bgSound.GetComponent<AudioSource>().Stop();
        }
        //if (PlayerPrefs.GetInt("CareerMode") == 0)
        //{
        //    LoadingBgActive();
        //}
        //else
        //{
        //    LoadingFull();
        //}
        if (PlayerPrefs.GetInt("PetCareMode") == 1 || PlayerPrefs.GetInt("RandomMode") == 1)
        {
            LoadingFull();
        }
        else
        {
            LoadingBgActive();
        }
        unicornId = PlayerPrefs.GetInt("PetSelected");
        setUpLoadingUniCorn();
        PlayerPrefs.SetInt("ComingFromSplash", 0);

    }

    public void nextLevel()
    {
        PlayerPrefs.SetInt("levelPlayedId", PlayerPrefs.GetInt("levelPlayedId") + 1);
        SoundManager.instance.PlayButtonClickSound();
        if (PlayerPrefs.GetInt("PlayingLevel") == 6)
        {
            PlayerPrefs.SetInt("PlayingLevel", 7);
            NavigationManager.instance.ReplaceScene(GameScene.DRESSUPVIEW);
        }
        else if (PlayerPrefs.GetInt("PlayingLevel") == 7)
        {
            PlayerPrefs.SetInt("PlayingLevel", 8);
            NavigationManager.instance.ReplaceScene(GameScene.DRESSUPVIEW);
        }
        else if (PlayerPrefs.GetInt("PlayingLevel") == 8)
        {
            PlayerPrefs.SetInt("PlayingLevel", 9);
            NavigationManager.instance.ReplaceScene(GameScene.DRESSUPVIEW);
        }
        else if (PlayerPrefs.GetInt("PlayingLevel") == 9)
        {
            PlayerPrefs.SetInt("PlayingLevel", 10);
            NavigationManager.instance.ReplaceScene(GameScene.EATINGVIEW);
        }
    }

    public void RestartLevel()
    {
        SoundManager.instance.PlayButtonClickSound();
        NavigationManager.instance.ReplaceScene(GameScene.DRESSUPVIEW);
    }

    public void homeButton()
    {
        PlayerPrefs.SetInt("ComingToHome", 1);
        PlayerPrefs.SetInt("ComingFromSplash", 1);
        SoundManager.instance.PlayButtonClickSound();
        NavigationManager.instance.ReplaceScene(GameScene.MAINMENU);
    }

    public void TriplleReward()
    {
        AdsManager.Instance.ShowRewarded(() =>
        {
            PrefsManager.instance.SetPlayerScore(2000);
            NavigationManager.instance.ReplaceScene(GameScene.MAINMENU);
        }, "Counter Incremented");
    }

    void Destroy()
    {
        iTween.Stop();
    }

    #endregion

    #region Utility Methods



    private void SetViewContents()
    {
        LastClickGrid = -1;
        flagBtnClick = true;
        NextArr = new int[] { 1, 0, 0, 0, 0, 0, 0, 0 };
    }



    void setUpUniCorn()
    {
        Body.GetComponent<Image>().sprite = BodyList[unicornId];
        Face.GetComponent<Image>().sprite = FaceList[unicornId];
        Ear.GetComponent<Image>().sprite = EarList[unicornId];
        leftLeg.GetComponent<Image>().sprite = leftLegList[unicornId];
        RightLeg.GetComponent<Image>().sprite = RightLegList[unicornId];
        LeftArm.GetComponent<Image>().sprite = LeftArmList[unicornId];
        RightArm.GetComponent<Image>().sprite = RightArmList[unicornId];
        Eyes.GetComponent<Image>().sprite = EyesList[unicornId];
        if (PlayerPrefs.GetInt("PetCareMode") == 1 && PlayerPrefs.GetInt("AnimalPlayed") > 0)
        {
            Dress.GetComponent<Image>().sprite = DressesUniCorn[Random.Range(0, DressesUniCorn.Length - 1)];
        }
    }


    void setUpLoadingUniCorn()
    {
        LoadingBody.GetComponent<Image>().sprite = BodyList[unicornId];
        LoadingFace.GetComponent<Image>().sprite = FaceList[unicornId];
        LoadingEar.GetComponent<Image>().sprite = EarList[unicornId];
        LoadingleftLeg.GetComponent<Image>().sprite = leftLegList[unicornId];
        LoadingRightLeg.GetComponent<Image>().sprite = RightLegList[unicornId];
        LoadingLeftArm.GetComponent<Image>().sprite = LeftArmList[unicornId];
        LoadingRightArm.GetComponent<Image>().sprite = RightArmList[unicornId];
        LoadingEyes.GetComponent<Image>().sprite = EyesList[unicornId];
    }

    private void MoveAction(GameObject obj, RectTransform pos, float time, iTween.EaseType type)
    {
        Hashtable tweenParams = new Hashtable();
        tweenParams.Add("x", pos.position.x);
        tweenParams.Add("y", pos.position.y);
        tweenParams.Add("time", time);
        tweenParams.Add("easetype", type);
        iTween.MoveTo(obj, tweenParams);
    }


    private void ScaleAction(GameObject obj, float ScaleFactor, float time, iTween.EaseType type)
    {
        Hashtable tweenParams = new Hashtable();
        tweenParams.Add("scale", new Vector3(ScaleFactor, ScaleFactor, 0));
        tweenParams.Add("time", 0.5f);
        tweenParams.Add("easetype", type);
        iTween.ScaleTo(obj, tweenParams);
    }

    private void loadingImageInactive()
    {
        //BigBannerHandler.instance.HideBigBanner();
        loadingImage.SetActive(false);
    }

    private void ShowNext()
    {
        NextCount = 0;
        for (int i = 0; i < NextArr.Count(); i++)
        {

            if (NextArr[i] == 1)
            {
                NextCount++;
            }
        }
        if (NextCount == 2)
        {
            //Invoke("nextButtonActive", 0.7f);
            Next.SetActive(true);
        }
    }



    private void popupActive()
    {
        animalName.text = PlayerPrefs.GetString("SelectedPetName");
        lastpopup.SetActive(true);
        ScaleAction(lastpopup.transform.GetChild(0).gameObject, 0.8f, 0.5f, iTween.EaseType.linear);
        SoundManager.instance.PlayPopupCloseSound();
        Invoke("treatmentTextAppear", 1.2f);
    }

    private void treatmentTextAppear()
    {
        SoundManager.instance.PlayGirlSound();
        ScaleAction(treamentText, 1.0f, 0.3f, iTween.EaseType.linear);
        Invoke("treatMentStamp", 0.3f);
    }

    private void treatMentStamp()
    {
        SoundManager.instance.playstampSound();
        MoveAction(treamentText, treatmentTextEndPoint, 0.3f, iTween.EaseType.easeInBounce);
        Invoke("nextButtonActive", 0.7f);
        Invoke("treamentParticleAppear", 0.4f);
    }

    private void treamentParticleAppear()
    {
        ParticleManger.instance.showStarParticle(treamentText);

    }

    private void nextButtonActive()
    {
        //Invoke("popupActive", 2.0f);
        //nextButton.SetActive(true);
        nextSceneButton.SetActive(true);
    }




    #endregion

    #region Callback Methods

    void noInternetConectClose()
    {
        noInternetConect.SetActive(false);
    }



    public void closeGrid()
    {
        for (int i = 0; i < Grids.Count; i++)
        {
            MoveAction(Grids[i], GridStartPoint, 0.5f, iTween.EaseType.easeInOutSine);
        }

    }
    /// Grids Click Code Here /// 


    public void getRewardPoints(int reward)
    {
        PrefsManager.instance.SetPlayerScore(reward);
        LowCoinPurchasePanel.SetActive(false);
    }

    public void purchaseBtn()
    {
        Debug.Log(PlayerPrefs.GetString("ItemToPurchase"));
        if (PrefsManager.instance.GetPlayerScore() >= PlayerPrefs.GetInt("ItemPrice"))
        {
            PrefsManager.instance.PurchasePlayerScore(PlayerPrefs.GetInt("ItemPrice"));
            PlayerPrefs.SetInt(PlayerPrefs.GetString("ItemToPurchase"), 1); 
            ClickedBtnRef.transform.GetChild(0).gameObject.SetActive(false);
            SoundManager.instance.PlayButtonClickSound();
            coinPurchasePanel.SetActive(false);
        }
        else
        {
            SoundManager.instance.PlayButtonClickSound();
            LowCoinPurchasePanel.SetActive(true);
            //ItemPurchasePanel.SetActive(false);
        }

    }

    public void OnDressGirdClick(int tag)
    {
        GameObject clickedItem = EventSystem.current.currentSelectedGameObject;
        int itemId = clickedItem.GetComponent<ItemController>().itmeId;
        string itemName = clickedItem.GetComponent<ItemController>().itemName;
        int itemAmount = clickedItem.GetComponent<ItemController>().itemPrice;
        PlayerPrefs.SetString("ItemToPurchase", itemName + itemId);
        PlayerPrefs.SetInt("ItemPrice", itemAmount);
        purchaseText.text = "Unlock This Item with " + itemAmount + " Reward";
        buttonPurchaseText.text = itemAmount.ToString();
        if (PlayerPrefs.GetInt(itemName + itemId) == 1)
        {
            SoundManager.instance.PlayButtonClickSound();
            GameManager.instance.CurrentDressupItem = GameManager.instance.dressDataList[tag] as BaseItem;
            GameManager.instance.selectedDress = GameManager.instance.dressDataList[tag] as BaseItem;
            CurrentItem.sprite = Resources.Load<Sprite>(GameManager.instance.CurrentDressupItem.getInGameImageName());
            mainItems[0].gameObject.transform.GetComponent<Image>().sprite = clickedItemImage;
            StartCoroutine(MoveCurrentItem(Dress, 0, tag));
        }
        else
        {
            SoundManager.instance.PlayButtonClickSound();
            coinPurchasePanel.SetActive(true);
            ClickedBtnRef = clickedItem;
        }
    }

    public void OnHornGirdClick(int tag)
    {
        GameObject clickedItem = EventSystem.current.currentSelectedGameObject;
        int itemId = clickedItem.GetComponent<ItemController>().itmeId;
        string itemName = clickedItem.GetComponent<ItemController>().itemName;
        int itemAmount = clickedItem.GetComponent<ItemController>().itemPrice;
        PlayerPrefs.SetString("ItemToPurchase", itemName + itemId);
        PlayerPrefs.SetInt("ItemPrice", itemAmount);
        purchaseText.text = "Unlock This Item with " + itemAmount + " Reward";
        buttonPurchaseText.text = itemAmount.ToString();
        if (PlayerPrefs.GetInt(itemName + itemId) == 1)
        {
            SoundManager.instance.PlayButtonClickSound();
            GameManager.instance.CurrentDressupItem = GameManager.instance.hornDataList[tag] as BaseItem;
            GameManager.instance.selectedHorn = GameManager.instance.hornDataList[tag] as BaseItem;
            CurrentItem.sprite = Resources.Load<Sprite>(GameManager.instance.CurrentDressupItem.getInGameImageName());
            mainItems[1].gameObject.transform.GetComponent<Image>().sprite = clickedItemImage;
            StartCoroutine(MoveCurrentItem(Horn, 1, tag));
        }
        else
        {
            SoundManager.instance.PlayButtonClickSound();
            coinPurchasePanel.SetActive(true);
            ClickedBtnRef = clickedItem;
        }
    }

    public void OnShoesGirdClick(int tag)
    {
        GameObject clickedItem = EventSystem.current.currentSelectedGameObject;
        int itemId = clickedItem.GetComponent<ItemController>().itmeId;
        string itemName = clickedItem.GetComponent<ItemController>().itemName;
        int itemAmount = clickedItem.GetComponent<ItemController>().itemPrice;
        PlayerPrefs.SetString("ItemToPurchase", itemName + itemId);
        PlayerPrefs.SetInt("ItemPrice", itemAmount);
        purchaseText.text = "Unlock This Item with " + itemAmount + " Reward";
        buttonPurchaseText.text = itemAmount.ToString();
        if (PlayerPrefs.GetInt(itemName + itemId) == 1)
        {
            SoundManager.instance.PlayButtonClickSound();
            GameManager.instance.CurrentDressupItem = GameManager.instance.shoesDataList[tag] as BaseItem;
            GameManager.instance.selectedShoes = GameManager.instance.shoesDataList[tag] as BaseItem;
            CurrentItem.sprite = Resources.Load<Sprite>(GameManager.instance.CurrentDressupItem.getInGameImageName());
            mainItems[2].gameObject.transform.GetComponent<Image>().sprite = clickedItemImage;
            StartCoroutine(MoveCurrentItem(Shoes, 2, tag));
        }
        else
        {
            SoundManager.instance.PlayButtonClickSound();
            coinPurchasePanel.SetActive(true);
            ClickedBtnRef = clickedItem;
        }
    }

    public void OnLenseGirdClick(int tag)
    {
        GameObject clickedItem = EventSystem.current.currentSelectedGameObject;
        int itemId = clickedItem.GetComponent<ItemController>().itmeId;
        string itemName = clickedItem.GetComponent<ItemController>().itemName;
        int itemAmount = clickedItem.GetComponent<ItemController>().itemPrice;
        PlayerPrefs.SetString("ItemToPurchase", itemName + itemId);
        PlayerPrefs.SetInt("ItemPrice", itemAmount);
        purchaseText.text = "Unlock This Item with " + itemAmount + " Reward";
        buttonPurchaseText.text = itemAmount.ToString();
        if (PlayerPrefs.GetInt(itemName + itemId) == 1)
        {
            SoundManager.instance.PlayButtonClickSound();
            GameManager.instance.CurrentDressupItem = GameManager.instance.lensDataList[tag] as BaseItem;
            GameManager.instance.selectedLens = GameManager.instance.lensDataList[tag] as BaseItem;
            CurrentItem.sprite = Resources.Load<Sprite>(GameManager.instance.CurrentDressupItem.getInGameImageName());
            mainItems[3].gameObject.transform.GetComponent<Image>().sprite = clickedItemImage;
            StartCoroutine(MoveCurrentItem(Lens, 3, tag));
        }
        else
        {
            SoundManager.instance.PlayButtonClickSound();
            coinPurchasePanel.SetActive(true);
            ClickedBtnRef = clickedItem;
        }
    }

    void callAd()
    {
        AdsManager.Instance.ShowInterstitial("Level Complete");
    }

    IEnumerator MoveCurrentItem(Image ReplaceImage, int ClickItem, int ItemTag)
    {
        Debug.Log(ClickItem);
        if (flagBtnClick)
        {
            flagBtnClick = false;
            NextArr[ClickItem] = 1;
            if (PlayerPrefs.GetInt("CareerMode") == 1)
            {
                CurrentItem.transform.position = CareerContentItems[ClickItem].transform.GetChild(ItemTag).transform.position;
                CurrentItem.gameObject.SetActive(true);
                CurrentItem.GetComponent<Image>().SetNativeSize();
                MoveAction(CurrentItem.gameObject, ItemsEndPoints[ClickItem], 0.7f, iTween.EaseType.linear);
            } else
            {
                CurrentItem.transform.position = ScrollContentItems[ClickItem].transform.GetChild(ItemTag).transform.position;
                CurrentItem.gameObject.SetActive(true);
                CurrentItem.GetComponent<Image>().SetNativeSize();
                MoveAction(CurrentItem.gameObject, ItemsEndPoints[ClickItem], 0.7f, iTween.EaseType.linear);
            }

            if (ClickItem == 0)
            {
                ScaleAction(CurrentItem.gameObject, 0.55f, 0.7f, iTween.EaseType.easeInOutQuad);

            }
            else if (ClickItem == 1)
            {
                ScaleAction(CurrentItem.gameObject, 0.35f, 0.7f, iTween.EaseType.easeInOutQuad);
            }
            else if (ClickItem == 2)
            {
                ScaleAction(CurrentItem.gameObject, 0.35f, 0.7f, iTween.EaseType.easeInOutQuad);
            }
            else if (ClickItem == 3)
            {
                ScaleAction(CurrentItem.gameObject, 0.35f, 0.7f, iTween.EaseType.easeInOutQuad);
            }

            yield return new WaitForSeconds(0.8f);
            ReplaceImage.sprite = Resources.Load<Sprite>(GameManager.instance.CurrentDressupItem.getInGameImageName());
            ReplaceImage.gameObject.SetActive(true);
            //ParticleManger.instance.ShowStarParticle(ReplaceImage.gameObject);
            ParticleManger.instance.showStarParticle(ReplaceImage.gameObject);
            CurrentItem.transform.localScale = Vector3.zero;
            if (ClickItem == 0)
            {
                otherDress.SetActive(false);
            }
            StopAllCoroutines();
            flagBtnClick = true;
            Debug.Log(ClickItem);
            //ShowNext();
            if (ClickItem < 3)
            {
                clickedButtonArray[ClickItem + 1].GetComponent<Button>().interactable = true;
            }
            if(ClickItem == 3)
            {
                //Invoke("nextButtonActive", 0.7f);
                Next.SetActive(true);
            }
            itemCount++;
            if (itemCount %3 == 0)
            {
                SoundManager.instance.PlayGoodJobSound();
                taskMessageImage.sprite = taskMessageSprite[Random.Range(0, 1)];
                taskePanel.SetActive(true);
                Invoke("taskPanelOff", 3.0f);
            }
            if (PlayerPrefs.GetInt("CareerMode") == 1)
            {
                nextButton.SetActive(true);
            }
        }
    }



    void taskPanelOff()
    {
        taskePanel.SetActive(false);
    }

    public void OnClickItemsButtons(int tag)
    {
        SoundManager.instance.PlayButtonClickSound();
        currentTag = tag;
        if (lastTag != tag)
        {
            print("value is" + tag + "" + lastTag);
            gridsGoesOut();
            Invoke("gridComesInn", 0.1f);
            counter++;
            //CallAds();
        }
    }

    void CallAds()
    {
        if (counter % 3 == 0)
        {
            print("Counter =" + counter);
            AdsManager.Instance.ShowInterstitial("Level Complete");
        }
    }

    private void gridsGoesOut()
    {
        if (lastTag != -1)
        {
            MoveAction(Grids[lastTag], GridStartPoint, 0.3f, iTween.EaseType.easeInBack);

        }
    }
    private void gridComesInn()
    {
        MoveAction(Grids[currentTag], GridEndPoint, 0.3f, iTween.EaseType.linear);
        lastTag = currentTag;
    }
    public void OnNextClick()
    {
        if (PlayerPrefs.GetInt("CareerMode") == 1)
        {
            levelCompletePanel.SetActive(true);
            PrefsManager.instance.SetPlayerScore(1000);
            if (PlayerPrefs.GetInt("LevelPlayed") == PlayerPrefs.GetInt("levelPlayedId"))
            {
                PlayerPrefs.SetInt("LevelPlayed", PlayerPrefs.GetInt("LevelPlayed") + 1);
            }
        }
        else
        {
            Invoke("popupActive", 0.1f);
        }
        SoundManager.instance.PlayButtonClickSound();

    }
    public void OnNextSceneClick()
    {
        SoundManager.instance.PlayButtonClickSound();
        NavigationManager.instance.ReplaceScene(GameScene.EATINGVIEW);

    }

    private void loadNextScene()
    {
        NavigationManager.instance.ReplaceScene(GameScene.EATINGVIEW);
    }

    private void UnicornInstantiate()
    {
        //GameManager.instance.player.SetMakeup(Instantiate(dressedUnicorn));
    }


    private void LoadingBgActive()
    {
        LoadingFilled.fillAmount = 0;
        Loading.SetActive(true);
        StartCoroutine(FillAction(LoadingFilled));
        Invoke("AdCalled", 1.0f);
        Invoke("LoadingFull", 4.0f);
    }

    IEnumerator FillAction(Image img)
    {
        if (img.fillAmount < 1.0f)
        {
            img.fillAmount = img.fillAmount + 0.010f;
            yield return new WaitForSeconds(0.02f);
            StartCoroutine(FillAction(img));
        }
        else if (img.fillAmount >= 1.0f)
        {
            StopCoroutine(FillAction(img));
        }
    }

    private void LoadingFull()
    {
        objectivePanel.SetActive(true);
        Loading.SetActive(false);
    }

    public void levelStart()
    {
        SoundManager.instance.PlayButtonClickSound();
        objectivePanel.SetActive(false);
        setUpUniCorn();
        //MoveAction(Grids[0], GridEndPoint, 0.3f, iTween.EaseType.linear);
        Invoke("SetViewContents", 0.2f);
    }

    void AdCalled()
    {
        AdsManager.Instance.ShowInterstitial("Level Complete");
    }

    public void onPanelClose(GameObject parent)
    {
        SoundManager.instance.PlayButtonClickSound();
        parent.SetActive(false);
    }

    public void sound()
    {
        SoundManager.instance.PlayButtonClickSound();
    }

    public void lowCoinGetCashWithAd(int score)
    {
        AdsManager.Instance.ShowRewarded(() =>
        {
            LowCoinPurchasePanel.SetActive(false);
            //PlayerPrefs.SetInt("PlayerScore", PlayerPrefs.GetInt("PlayerScore") + score);
            PrefsManager.instance.SetPlayerScore(score);
            //PlayerScore.text = PrefsManager.instance.GetPlayerScore().ToString();
        }, "Counter Incremented");
    }

    #endregion
}
