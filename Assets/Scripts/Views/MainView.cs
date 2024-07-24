using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class MainView : MonoBehaviour {

    #region Variables, Constants & Initializers

    private bool quitFlag = true;
	public GameObject title, playButton, settingButton, rateUsButton, privacyButton;
	public RectTransform titleEndPoint , playButtonEndPoint, settingButtonEndPoint, rateUsButtonEndPoint, privacyButtonEndPoint;
	public GameObject quitPopup;
	public GameObject titleParticles;

    public GameObject modeSelection;
    public GameObject careerSelection;
    public GameObject petCareSelection;
    public GameObject watchAdPanel;
    public GameObject watchAdModePanel;
    public GameObject lowCashPanel;
    public GameObject settingPanel;
    public Text watchBtnText;

    public Button[] lockBtn;
    public GameObject[] lockImage;
    public GameObject[] animalImage;
    public GameObject[] watchAdButton;
	public int[] watcAdCount;

    public GameObject Loading;
    public Image LoadingFilled;

    public Sprite onSprite;
    public Sprite offSprite;

    public Button SoundBtn;
    public Button MusicBtn;

    public GameObject bgSound;

    static int index = 0;

    //Economy Content Start
    public Text PlayerScore;

    public GameObject unicornCareModeLockImage;
    public GameObject randomModeLockImage;
    public GameObject unicornCareModeLock;
    public GameObject randomModeLock;

    public Button UnicornCareModeBtn;
    public Button RandomeModeBtn;

    public Text watchAdPanelText;
    public Text watchAdButtonText;
    public Text CoinPurchaseText;

    public ScrollRect carrerModeScroll;
    public ScrollRect petCareModeScroll;

    public GameObject[] outline;
    public GameObject[] petCareOutline;
    //Economy Content End

    #endregion

    #region Lifecycle Methods

    // Use this for initialization
    void Start ()
    {
        PlayerPrefs.SetInt("UniCornUnLocked", 1);
        PlayerPrefs.SetInt("RandomUnLocked", 1);
        //PlayerPrefs.SetInt("LevelPlayed", 60);
        scrollSetting();
        petCareScrollSetting();
        outlineManager();
        petCareOutlineManager();
        if (PlayerPrefs.GetInt("LevelPlayed") >= 50)
        {
            PlayerPrefs.SetInt("UniCornUnLocked", 1);
        }
        if (PlayerPrefs.GetInt("AnimalPlayed") >= 5)
        {
            PlayerPrefs.SetInt("RandomUnLocked", 1);
        }
        //PrefsManager.instance.SetPlayerScore(75000);
        if (PlayerPrefs.GetInt("UniCornUnLocked") == 1)
        {
            unicornCareModeLockImage.SetActive(false);
            unicornCareModeLock.SetActive(false);

        }
        if (PlayerPrefs.GetInt("RandomUnLocked") == 1)
        {
            randomModeLockImage.SetActive(false);
            randomModeLock.SetActive(false);
        }
        PlayerScore.text = PrefsManager.instance.GetPlayerScore().ToString();
        if (PlayerPrefs.GetInt("Settings") == 0)
        {
            PlayerPrefs.SetInt("MusicContoller", 1);
            PlayerPrefs.SetInt("SoundContoller", 1);
            PlayerPrefs.SetInt("Settings", 1);
        }
        if (PlayerPrefs.GetInt("SoundContoller") == 1)
        {
            SoundBtn.GetComponent<Image>().sprite = onSprite;
        }
        else
        {
            SoundBtn.GetComponent<Image>().sprite = offSprite;
        }

        if (PlayerPrefs.GetInt("MusicContoller") == 1)
        {
            bgSound.GetComponent<AudioSource>().Play();
            MusicBtn.GetComponent<Image>().sprite = onSprite;
        }
        else
        {
            bgSound.GetComponent<AudioSource>().Stop();
            MusicBtn.GetComponent<Image>().sprite = offSprite;
        }
        //Debug.Log(PlayerPrefs.GetInt("LevelPlayed"));
        if (PlayerPrefs.GetInt("ComingToHome") == 1)
        {
            LoadingFilled.fillAmount = 0;
            Loading.SetActive(true);
            StartCoroutine(FillAction(LoadingFilled));
            Invoke("AdCalled", 1.0f);
            PlayerPrefs.SetInt("ComingToHome", 0);
            Invoke("homeSection", 4.0f);

        }
        if (PlayerPrefs.GetInt("ComingFromSplash") == 0)
        {
            LoadingFilled.fillAmount = 0;
            Loading.SetActive(true);
            StartCoroutine(FillAction(LoadingFilled));
            Invoke("AdCalled", 1.0f);
            if (PlayerPrefs.GetInt("CareerMode") == 1 && PlayerPrefs.GetInt("LevelPlayed") < 50)
            {
                Invoke("careerSection", 4.0f);
                Invoke("modeSection", 4.0f);
            }
            else if (PlayerPrefs.GetInt("PetCareMode") == 1 && PlayerPrefs.GetInt("AnimalPlayed") < 5)
            {
                Invoke("petCareSection", 4.0f);
                Invoke("modeSection", 4.0f);
            }
            else
            {
                Invoke("modeSection", 4.0f);
            }

        }
        //else
        //{
        //	PlayerPrefs.SetInt("ComingFromSplash", 0);
        //}
        Invoke ("SetViewContents", 0.1f);
	}

	
	// Update is called once per frame
	void Update () {
#if UNITY_ANDROID || UNITY_WP8
		if (Input.GetKeyDown(KeyCode.Escape)) 
		{ 
	
			if (quitPopup != null) {
				titleParticles.SetActive(false);
				if(quitPopup.GetComponent<RectTransform>().localScale != Vector3.one) {
					Hashtable tweenParams = new Hashtable();
					tweenParams.Add ("scale", Vector3.one);
					tweenParams.Add ("time", 0.5f);
					//tweenParams.Add ("oncompletetarget", gameObject);
					//tweenParams.Add ("oncomplete", "HideCartFullIndication");
					iTween.ScaleTo(quitPopup.gameObject, tweenParams);
				}
			}
			else {
				OnQuitYesButtonClicked();
			}
		}

#endif
    }

    void outlineManager()
    {
        for (int i = 0; i < outline.Length; i++)
        {
            outline[i].SetActive(false);
        }
        if (PlayerPrefs.GetInt("CareerMode") == 1)
        {
            outline[0].SetActive(true);
        }
        if (PlayerPrefs.GetInt("PetCareMode") == 1)
        {
            outline[1].SetActive(true);
        }
        if (PlayerPrefs.GetInt("RandomMode") == 1)
        {
            outline[2].SetActive(true);
        }
    }

    void petCareOutlineManager()
    {
        for (int i = 0; i < petCareOutline.Length; i++)
        {
            petCareOutline[i].SetActive(false);
        }
        for (int i = 0; i < petCareOutline.Length; i++)
        {
            if (PlayerPrefs.GetInt("AnimalPlayed") == i)
            {
                petCareOutline[i].SetActive(true);
            }
        }
    }

    public void petCareScrollSetting()
    {
        if (PlayerPrefs.GetInt("AnimalPlayed") == 0)
        {
            petCareModeScroll.normalizedPosition = new Vector2(0, 1.00f);
        }
        if (PlayerPrefs.GetInt("AnimalPlayed") == 1)
        {
            petCareModeScroll.normalizedPosition = new Vector2(0, 0.72f);
        }
        if (PlayerPrefs.GetInt("AnimalPlayed") == 2)
        {
            petCareModeScroll.normalizedPosition = new Vector2(0, 0.44f);
        }
        if (PlayerPrefs.GetInt("AnimalPlayed") == 3)
        {
            petCareModeScroll.normalizedPosition = new Vector2(0, 0.16f);
        }
        if (PlayerPrefs.GetInt("AnimalPlayed") == 4)
        {
            petCareModeScroll.normalizedPosition = new Vector2(0, 0.00f);
        }
    }

    public void scrollSetting()
    {
        if (PlayerPrefs.GetInt("LevelPlayed") <= 2)
        {
            carrerModeScroll.normalizedPosition = new Vector2(0, 1.00f);
        }
        if (PlayerPrefs.GetInt("LevelPlayed") >= 3 && PlayerPrefs.GetInt("LevelPlayed") <= 5)
        {
            carrerModeScroll.normalizedPosition = new Vector2(0, 0.935f);
        }
        if (PlayerPrefs.GetInt("LevelPlayed") >= 6 && PlayerPrefs.GetInt("LevelPlayed") <= 8)
        {
            carrerModeScroll.normalizedPosition = new Vector2(0, 0.87f);
        }
        if (PlayerPrefs.GetInt("LevelPlayed") >= 9 && PlayerPrefs.GetInt("LevelPlayed") <= 11)
        {
            carrerModeScroll.normalizedPosition = new Vector2(0, 0.805f);
        }
        if (PlayerPrefs.GetInt("LevelPlayed") >= 12 && PlayerPrefs.GetInt("LevelPlayed") <= 14)
        {
            carrerModeScroll.normalizedPosition = new Vector2(0, 0.74f);
        }
        if (PlayerPrefs.GetInt("LevelPlayed") >= 15 && PlayerPrefs.GetInt("LevelPlayed") <= 17)
        {
            carrerModeScroll.normalizedPosition = new Vector2(0, 0.675f);
        }
        if (PlayerPrefs.GetInt("LevelPlayed") >= 18 && PlayerPrefs.GetInt("LevelPlayed") <= 20)
        {
            carrerModeScroll.normalizedPosition = new Vector2(0, 0.61f);
        }
        if (PlayerPrefs.GetInt("LevelPlayed") >= 21 && PlayerPrefs.GetInt("LevelPlayed") <= 23)
        {
            carrerModeScroll.normalizedPosition = new Vector2(0, 0.545f);
        }
        if (PlayerPrefs.GetInt("LevelPlayed") >= 24 && PlayerPrefs.GetInt("LevelPlayed") <= 26)
        {
            carrerModeScroll.normalizedPosition = new Vector2(0, 0.48f);
        }
        if (PlayerPrefs.GetInt("LevelPlayed") >= 27 && PlayerPrefs.GetInt("LevelPlayed") <= 29)
        {
            carrerModeScroll.normalizedPosition = new Vector2(0, 0.415f);
        }
        if (PlayerPrefs.GetInt("LevelPlayed") >= 30 && PlayerPrefs.GetInt("LevelPlayed") <= 32)
        {
            carrerModeScroll.normalizedPosition = new Vector2(0, 0.35f);
        }
        if (PlayerPrefs.GetInt("LevelPlayed") >= 33 && PlayerPrefs.GetInt("LevelPlayed") <= 35)
        {
            carrerModeScroll.normalizedPosition = new Vector2(0, 0.285f);
        }
        if (PlayerPrefs.GetInt("LevelPlayed") >= 36 && PlayerPrefs.GetInt("LevelPlayed") <= 38)
        {
            carrerModeScroll.normalizedPosition = new Vector2(0, 0.22f);
        }
        if (PlayerPrefs.GetInt("LevelPlayed") >= 39 && PlayerPrefs.GetInt("LevelPlayed") <= 41)
        {
            carrerModeScroll.normalizedPosition = new Vector2(0, 0.155f);
        }
        if (PlayerPrefs.GetInt("LevelPlayed") >= 42 && PlayerPrefs.GetInt("LevelPlayed") <= 44)
        {
            carrerModeScroll.normalizedPosition = new Vector2(0, 0.09f);
        }
        if (PlayerPrefs.GetInt("LevelPlayed") >= 45 && PlayerPrefs.GetInt("LevelPlayed") <= 47)
        {
            carrerModeScroll.normalizedPosition = new Vector2(0, 0.025f);
        }
        if (PlayerPrefs.GetInt("LevelPlayed") >= 48 && PlayerPrefs.GetInt("LevelPlayed") <= 50)
        {
            carrerModeScroll.normalizedPosition = new Vector2(0, 0.025f);
        }
        if (PlayerPrefs.GetInt("LevelPlayed") >= 51 && PlayerPrefs.GetInt("LevelPlayed") <= 53)
        {
            carrerModeScroll.normalizedPosition = new Vector2(0, 0.025f);
        }
        if (PlayerPrefs.GetInt("LevelPlayed") >= 54 && PlayerPrefs.GetInt("LevelPlayed") <= 56)
        {
            carrerModeScroll.normalizedPosition = new Vector2(0, 0.025f);
        }
        if (PlayerPrefs.GetInt("LevelPlayed") >= 57 && PlayerPrefs.GetInt("LevelPlayed") <= 59)
        {
            carrerModeScroll.normalizedPosition = new Vector2(0, 0.025f);
        }
    }

	void Destroy() {
		iTween.Stop ();
	}

	#endregion

	#region Callback Methods

	private void SetViewContents() {
		buttonActive ();
		titleComesInn();

    }

    private void buttonActive()
    {
        int index = PlayerPrefs.GetInt("ButtonActive");
        Debug.Log("value is"+ index);
        index = index % 2;

        PlayerPrefs.SetInt("ButtonActive", PlayerPrefs.GetInt("ButtonActive") + 1);

    }
    private void ScaleAction(GameObject obj,float scaleval,float time,iTween.EaseType type,iTween.LoopType loopType) {
		Hashtable tweenParams = new Hashtable();
		tweenParams.Add ("scale", new Vector3 (scaleval,scaleval, 0));
		tweenParams.Add ("time", time);
		tweenParams.Add ("easetype", type);
		tweenParams.Add ("looptype", loopType);
		iTween.ScaleTo(obj, tweenParams);
	}


	private void MoveAction(GameObject obj,RectTransform pos,float time,iTween.EaseType actionType,iTween.LoopType loopType){
		Hashtable tweenParams = new Hashtable();
		tweenParams.Add ("x", pos.position.x);
		tweenParams.Add ("y", pos.position.y);
		tweenParams.Add ("time", time);
		tweenParams.Add ("easetype", actionType);
		tweenParams.Add ("looptype", loopType);
		iTween.MoveTo (obj, tweenParams);
	}

	private void RotateAction(GameObject obj,float roatationamount,float t,iTween.EaseType actionType,iTween.LoopType loopType){
		Hashtable tweenParams = new Hashtable ();
		tweenParams.Add ("z", roatationamount);
		tweenParams.Add ("time", t);
		tweenParams.Add ("easetype", actionType);
		tweenParams.Add ("looptype", loopType);
		iTween.RotateTo (obj, tweenParams);
	}

	private void titleComesInn()
    {
        if (PlayerPrefs.GetInt("ComingFromSplash") == 1)
        {
            SoundManager.instance.PlayTitleDropSound();
        }
        MoveAction (title, titleEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("ButtonsComesInn", 0.3f);
	}

	private void ButtonsComesInn(){

        if (PlayerPrefs.GetInt("ComingFromSplash") == 1)
        {
            SoundManager.instance.PlaySideBtnSound();
        }
        MoveAction (settingButton, settingButtonEndPoint, 0.5f, iTween.EaseType.easeInBounce, iTween.LoopType.none);
		Invoke ("rateUsComesInn", 0.3f);
	}

    private void rateUsComesInn()
    {
        if (PlayerPrefs.GetInt("ComingFromSplash") == 1)
        {
            SoundManager.instance.PlaySideBtnSound();
        }
        MoveAction(rateUsButton, rateUsButtonEndPoint, 0.5f, iTween.EaseType.easeInBounce, iTween.LoopType.none);
        Invoke("privacyPolicyComesInn", 0.3f);
    }

    private void privacyPolicyComesInn()
    {
        if (PlayerPrefs.GetInt("ComingFromSplash") == 1)
        {
            SoundManager.instance.PlaySideBtnSound();
        }
        MoveAction(privacyButton, privacyButtonEndPoint, 0.5f, iTween.EaseType.easeInBounce, iTween.LoopType.none);
        Invoke("playButtonComesInn", 0.3f);
    }

    private void playButtonComesInn()
    {
        if (PlayerPrefs.GetInt("ComingFromSplash") == 1)
        {
            SoundManager.instance.PlayPlayBtnSound();
        }
        playButton.SetActive (true);
		ScaleAction (playButton, 0.7f, 0.45f, iTween.EaseType.linear, iTween.LoopType.none);
        //MoveAction (playButton, playButtonEndPoint, 0.5f, iTween.EaseType.easeInBounce, iTween.LoopType.none);
    }

    public void OnPlayButtonClicked()
    {
        SoundManager.instance.PlayButtonClickSound();
        LoadingFilled.fillAmount = 0;
        Loading.SetActive(true);
        StartCoroutine(FillAction(LoadingFilled));
        Invoke("AdCalled", 1.0f);
        //Invoke("petcareSection", 4.0f);
        Invoke("modeSection", 4.0f);

        //petCareSelection.SetActive(true);


        //NavigationManager.instance.ReplaceScene (GameScene.RECEPTIONView);
    }

    public void OnPetCareModeClicked()
    {
        SoundManager.instance.PlayButtonClickSound();
        PlayerPrefs.SetInt("CareerMode", 0);
        PlayerPrefs.SetInt("PetCareMode", 1);
        PlayerPrefs.SetInt("RandomMode", 0);
        outlineManager();
        if (PlayerPrefs.GetInt("UniCornUnLocked") == 1)
        {
            LoadingFilled.fillAmount = 0;
            Loading.SetActive(true);
            StartCoroutine(FillAction(LoadingFilled));
            Invoke("AdCalled", 1.0f);
            Invoke("petcareSection", 4.0f);
        }
        else
        {
            watchAdPanelText.text = "Unlock UniCornCare Mode";
            watchAdButtonText.text = "Watch Ad " + PlayerPrefs.GetInt("UniCornUnLockedCount") + "/3";
            CoinPurchaseText.text = "25000";
            watchAdModePanel.SetActive(true);
        }
    }

    public void OnRandomModeClicked()
    {
        SoundManager.instance.PlayButtonClickSound();
        PlayerPrefs.SetInt("CareerMode", 0);
        PlayerPrefs.SetInt("PetCareMode", 0);
        PlayerPrefs.SetInt("RandomMode", 1);
        outlineManager();
        if (PlayerPrefs.GetInt("RandomUnLocked") == 1)
        {
            LoadingFilled.fillAmount = 0;
            Loading.SetActive(true);
            StartCoroutine(FillAction(LoadingFilled));
            Invoke("AdCalled", 1.0f);
            Invoke("randomSection", 4.0f);
        }
        else
        {
            watchAdPanelText.text = "Unlock Random Mode";
            watchAdButtonText.text = "Watch Ad " + PlayerPrefs.GetInt("RandomUnLockedCount") + "/5";
            CoinPurchaseText.text = "50000";
            watchAdModePanel.SetActive(true);
        }
    }

    public void OnCareerModeClicked()
    {

        PlayerPrefs.SetInt("CareerMode", 1);
        PlayerPrefs.SetInt("PetCareMode", 0);
        PlayerPrefs.SetInt("RandomMode", 0);
        outlineManager();
        SoundManager.instance.PlayButtonClickSound();
        LoadingFilled.fillAmount = 0;
        Loading.SetActive(true);
        StartCoroutine(FillAction(LoadingFilled));
        Invoke("AdCalled", 1.0f);
        Invoke("careerSection", 4.0f);
    }

    public void OnSettingButtonClicked()
    {
        SoundManager.instance.PlayButtonClickSound();
        settingPanel.SetActive(true);
    }

    void homeSection()
    {
        Loading.SetActive(false);
        LoadingFilled.fillAmount = 0;
    }

    void careerSection()
    {
        Loading.SetActive(false);
        LoadingFilled.fillAmount = 0;
        careerSelection.SetActive(true);
    }

    void petcareSection()
    {
        Loading.SetActive(false);
        LoadingFilled.fillAmount = 0;
        petCareSelection.SetActive(true);
    }

    void randomSection()
    {
        Loading.SetActive(false);
        LoadingFilled.fillAmount = 0;
        NavigationManager.instance.ReplaceScene(GameScene.RECEPTIONView);
    }

    void modeSection()
    {
        Loading.SetActive(false);
        LoadingFilled.fillAmount = 0;
        modeSelection.SetActive(true);
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
    public void OnPanelClosed(GameObject parent)
    {
        parent.SetActive(false);
        SoundManager.instance.PlayButtonClickSound();
    }


    public void OnPanelBack(GameObject parent)
    {
        LoadingFilled.fillAmount = 0;
        Loading.SetActive(true);
        StartCoroutine(FillAction(LoadingFilled));
        Invoke("AdCalled", 1.0f);
        Invoke("loadingPanelClose", 4.0f);
        parent.SetActive(false);
        SoundManager.instance.PlayButtonClickSound();
    }
    void loadingPanelClose()
    {
        Loading.SetActive(false);
        LoadingFilled.fillAmount = 0;

    }

    void AdCalled()
    {
        AdsManager.Instance.ShowInterstitial("Level Complete");
    }
    public void OnPetCareModeButtonClicked()
    {
        petCareSelection.SetActive(true);
        PlayerPrefs.SetInt("CareerMode", 0);
        PlayerPrefs.SetInt("PetCareMode", 1);
        PlayerPrefs.SetInt("RandomMode", 0);
        SoundManager.instance.PlayButtonClickSound();
        //NavigationManager.instance.ReplaceScene(GameScene.RECEPTIONView);
    }

    public void OnRateUsButtonClicked() {
		GameManager.instance.LogDebug ("RateUs Clicked");
		//Application.OpenURL ("https://play.google.com/store/apps/details?id=com.pdi.unicorn.baby.care.mybabyunicorn.free.caregames.portrait2024" + Application.identifier);
        //Application.OpenURL("market://details?id=com.pd.unicornbaby.ponycaregames");
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.pd.unicornbaby.ponycaregames");
        
        SoundManager.instance.PlayButtonClickSound ();
	}

	public void OnMoreFunButtonClicked() {
		GameManager.instance.LogDebug ("MoreFun Clicked");
        SoundManager.instance.PlayButtonClickSound();
        Application.OpenURL ("https://play.google.com/store/apps/dev?id=4826365601331502275");
    }

	public void OnPrivacyPolicyButtonClicked() {
		GameManager.instance.LogDebug ("Privacy policy");
        SoundManager.instance.PlayButtonClickSound();
        Application.OpenURL ("https://doc-hosting.flycricket.io/pet-dragon-inc-policy/0eaa397d-d077-424f-9603-bc62ba307b2f/privacy");
	}

	public void OnBurgerGameClicked() {
		SoundManager.instance.PlayButtonClickSound ();
		Application.OpenURL ("https://play.google.com/store/apps/details?id=com.bestonegames.yummyburger.homemade.cooking");
	}

    public void OnPizzaMakingClicked()
    {
        SoundManager.instance.PlayButtonClickSound();
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.bestonegames.mypizzashop.goodpizza.business.makergame");
    }

    public void OnQuitNoButtonClicked()
    {
        SoundManager.instance.PlayButtonClickSound();
        GameManager.instance.LogDebug ("QuitNo Clicked");
		quitPopup.GetComponent<RectTransform> ().localScale = Vector3.zero;
		titleParticles.SetActive(true);
	}

	public void OnQuitYesButtonClicked()
    {
        SoundManager.instance.PlayButtonClickSound();
        GameManager.instance.LogDebug ("QuitYes Clicked");
		Application.Quit ();
	}

	public void watchAdPanelButton(int petId)
    {
        SoundManager.instance.PlayButtonClickSound();
        watchBtnText.text = "Watch Ad " + PlayerPrefs.GetInt("PetWatchAdCount" + petId) + "/" + watcAdCount[petId];
        watchAdPanel.SetActive (true);
        PlayerPrefs.SetInt("PetSelected", petId);
    }

    public void unlockLevel()
    {
        SoundManager.instance.PlayButtonClickSound();
        int id = PlayerPrefs.GetInt("PetSelected");
        PlayerPrefs.SetInt("PetWatchAdCount" + id, PlayerPrefs.GetInt("PetWatchAdCount" + id) + 1);
        watchBtnText.text = "Watch Ad " + PlayerPrefs.GetInt("PetWatchAdCount" + id) + "/" + watcAdCount[id];
        if (PlayerPrefs.GetInt("PetWatchAdCount" + id) == watcAdCount[id])
        {
            lockImage[id].SetActive(false);
            lockBtn[id].GetComponent<Button>().interactable = true;
            animalImage[id].GetComponent<Image>().color = new Color(255, 255, 255, 255);
            watchAdButton[id].SetActive(false);
            PlayerPrefs.SetInt("AnimalUnlock" + id, 1);
            watchAdPanel.SetActive(false);
        }
    }

    public void sound()
    {
        SoundManager.instance.PlayButtonClickSound();
    }

    public void SoundController()
    {
        if (PlayerPrefs.GetInt("SoundContoller") == 1)
        {
            SoundBtn.GetComponent<Image>().sprite = offSprite;
            PlayerPrefs.SetInt("SoundContoller", 0);
        }
        else
        {
            SoundBtn.GetComponent<Image>().sprite = onSprite;
            PlayerPrefs.SetInt("SoundContoller", 1);
        }
        SoundManager.instance.PlayButtonClickSound();
    }

    public void MusicController()
    {
        if (PlayerPrefs.GetInt("MusicContoller") == 1)
        {
            MusicBtn.GetComponent<Image>().sprite = offSprite;
            PlayerPrefs.SetInt("MusicContoller", 0);
            bgSound.GetComponent<AudioSource>().Stop();
        }
        else
        {
            MusicBtn.GetComponent<Image>().sprite = onSprite;
            PlayerPrefs.SetInt("MusicContoller", 1);
            bgSound.GetComponent<AudioSource>().Play();
        }
        SoundManager.instance.PlayButtonClickSound();
    }

    public void addRewardedScore()
    {
        lowCashPanel.SetActive(true);
    }

    public void lowCashWatchAdd(int score)
    {
        AdsManager.Instance.ShowRewarded(() =>
        {
            lowCashPanel.SetActive(false);
            //PlayerPrefs.SetInt("PlayerScore", PlayerPrefs.GetInt("PlayerScore") + score);
            PrefsManager.instance.SetPlayerScore(score);
            PlayerScore.text = PrefsManager.instance.GetPlayerScore().ToString();
        }, "Counter Incremented");
    }

    public void unlockModeWithWatchAd()
    {
        if (PlayerPrefs.GetInt("PetCareMode") == 1)
        {
            if (PlayerPrefs.GetInt("UniCornUnLockedCount") < 2)
            {
                PlayerPrefs.SetInt("UniCornUnLockedCount", PlayerPrefs.GetInt("UniCornUnLockedCount") + 1);
                watchAdButtonText.text = "Watch Ad " + PlayerPrefs.GetInt("UniCornUnLockedCount") + "/3";

            }
            else
            {
                PlayerPrefs.SetInt("UniCornUnLocked", 1);
                watchAdModePanel.SetActive(false);
                unicornCareModeLockImage.SetActive(false);
                unicornCareModeLock.SetActive(false);
            }
        }
        if (PlayerPrefs.GetInt("RandomMode") == 1)
        {
            if (PlayerPrefs.GetInt("RandomUnLockedCount") < 4)
            {
                PlayerPrefs.SetInt("RandomUnLockedCount", PlayerPrefs.GetInt("RandomUnLockedCount") + 1);
                watchAdButtonText.text = "Watch Ad " + PlayerPrefs.GetInt("RandomUnLockedCount") + "/5";

            }
            else
            {
                PlayerPrefs.SetInt("RandomUnLocked", 1);
                watchAdModePanel.SetActive(false);
                randomModeLockImage.SetActive(false);
                randomModeLock.SetActive(false);
            }
        }
    }

    public void unlockModeWithCoins()
    {
        SoundManager.instance.PlayButtonClickSound();
        if (PlayerPrefs.GetInt("PetCareMode") == 1)
        {

            //PlayerScore.text = PrefsManager.instance.GetPlayerScore().ToString();
            if (PrefsManager.instance.GetPlayerScore() < 25000)
            {
                lowCashPanel.SetActive(true);
            }
            else
            {
                PrefsManager.instance.PurchasePlayerScore(25000);
                PlayerScore.text = PrefsManager.instance.GetPlayerScore().ToString();
                PlayerPrefs.SetInt("UniCornUnLocked", 1);
                watchAdModePanel.SetActive(false);
                unicornCareModeLockImage.SetActive(false);
                unicornCareModeLock.SetActive(false);
            }
        }
        if (PlayerPrefs.GetInt("RandomMode") == 1)
        {
            if (PrefsManager.instance.GetPlayerScore() < 50000)
            {
                lowCashPanel.SetActive(true);
            }
            else
            {
                PrefsManager.instance.PurchasePlayerScore(50000);
                PlayerScore.text = PrefsManager.instance.GetPlayerScore().ToString();
                PlayerPrefs.SetInt("RandomUnLocked", 1);
                watchAdModePanel.SetActive(false);
                randomModeLockImage.SetActive(false);
                randomModeLock.SetActive(false);
            }
        }
    }



    #endregion
}
