using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SleepingView : MonoBehaviour
{
    #region Variables, Constants & Initializers
    // Use this for initialization

    public GameObject Loading;
    public Image LoadingFilled1;

    public Sprite[] BodyList;
    public Sprite[] FaceList;
    public Sprite[] EarList;
    public Sprite[] leftLegList;
    public Sprite[] RightLegList;
    public Sprite[] LeftArmList;
    public Sprite[] RightArmList;
    public Sprite[] EyesList;
    public Sprite[] ClosedEyesList;
    public Image Body;
    public Image Face;
    public Image Ear;
    public Image leftLeg;
    public Image RightLeg;
    public Image LeftArm;
    public Image RightArm;
    public Image Eyes;
    public Image ClosedEyes;

    public Image LoadingBody;
    public Image LoadingFace;
    public Image LoadingEar;
    public Image LoadingleftLeg;
    public Image LoadingRightLeg;
    public Image LoadingLeftArm;
    public Image LoadingRightArm;
    public Image LoadingEyes;

    private int unicornId;

    public GameObject lampOff;
    public GameObject lampOn;
    public GameObject alarmClockObj;
    public GameObject SleepingSymbols;
    public GameObject BlackScreen;
    public GameObject ClosedEye;
    public GameObject LoadingScreen;
    public GameObject Finger;
    public Image LoadingFilled;
    public GameObject nextSceneButton;
    public GameObject lastpopup, treamentText;
    public RectTransform treatmentTextEndPoint;
    public Image popupImage;
    public GameObject originalPopup;

    public Sprite[] taskMessageSprite;
    public Image taskMessageImage;
    public GameObject taskePanel;

    public GameObject levelCompletePetCare;
    public GameObject levelCompletePanel;
    public GameObject objectivePanel;
    public Text objectiveText;

    public GameObject bgSound;
    public Text petCareScoreText;

    private Animator clockAnim;

    public Text animalName;
    public Text rewaredText;

    public string[] petNameSet;

    #endregion

    #region Lifecycle Methods
    // Start is called before the first frame update
    void Start()
    {
        animalName.text = PlayerPrefs.GetString("SelectedPetName");
        if (PlayerPrefs.GetInt("CareerMode") == 1)
        {
            if (PlayerPrefs.GetInt("PlayingLevel") == 0)
            {
                objectiveText.text = PlayerPrefs.GetString("SelectedPetName") + " is sleeping, Please wake her up";
            } else if (PlayerPrefs.GetInt("PlayingLevel") == 11)
            {
                objectiveText.text = PlayerPrefs.GetString("SelectedPetName") + " is very tired, Please let her sleep";
            }
        }
        if (PlayerPrefs.GetInt("PetCareMode") == 1)
        {
            objectiveText.text = PlayerPrefs.GetString("SelectedPetName") + " is very tired now, please let him sleep.";
        }
        clockAnim = alarmClockObj.GetComponent<Animator>();
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
            LoadingBgActive1();
        }
        setUpLoadingUniCorn();
        unicornId = PlayerPrefs.GetInt("PetSelected");
        PlayerPrefs.SetInt("ComingFromSplash", 0);
        //PlayerPrefs.SetInt("PetSelected", 0);

    }

    public void nextLevel()
    {
        if (PlayerPrefs.GetInt("PetCareMode") == 1 || PlayerPrefs.GetInt("RandomMode") == 1)
        {
            SoundManager.instance.PlayButtonClickSound();
            NavigationManager.instance.ReplaceScene(GameScene.MAINMENU);
        }
        else
        {
            PlayerPrefs.SetInt("levelPlayedId", PlayerPrefs.GetInt("levelPlayedId") + 1);
            SoundManager.instance.PlayButtonClickSound();
            if (PlayerPrefs.GetInt("PlayingLevel") == 0)
            {
                PlayerPrefs.SetInt("PlayingLevel", 1);
                NavigationManager.instance.ReplaceScene(GameScene.EATINGVIEW);
            }
            else if (PlayerPrefs.GetInt("PlayingLevel") == 11)
            {
                PlayerPrefs.SetInt("PlayingLevel", 0);
                PlayerPrefs.SetInt("PetSelected", PlayerPrefs.GetInt("PetSelected") + 1);
                PlayerPrefs.SetString("SelectedPetName", petNameSet[PlayerPrefs.GetInt("PetSelected")]);
                NavigationManager.instance.ReplaceScene(GameScene.SLEEPINGVIEW);
            }
        }
    }

    public void RestartLevel()
    {
        SoundManager.instance.PlayButtonClickSound();
        NavigationManager.instance.ReplaceScene(GameScene.SLEEPINGVIEW);
    }

    public void RestartPetCareLevel()
    {
        SoundManager.instance.PlayButtonClickSound();
        NavigationManager.instance.ReplaceScene(GameScene.BATHVIEW);
    }

    public void homeBtn()
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
            if (PlayerPrefs.GetInt("CareerMode") == 1)
            {
                PrefsManager.instance.SetPlayerScore(2000);
            }
            else if (PlayerPrefs.GetInt("PetCareMode") == 1)
            {
                PrefsManager.instance.SetPlayerScore(10000);
            }
            else if (PlayerPrefs.GetInt("RandomMode") == 1)
            {
                PrefsManager.instance.SetPlayerScore(20000);
            }
            NavigationManager.instance.ReplaceScene(GameScene.MAINMENU);
        }, "Counter Incremented");
    }

    void careerModeData()
    {
        if (PlayerPrefs.GetInt("PlayingLevel") == 0)
        {
            lampOn.SetActive(false);
            lampOff.SetActive(false);
            Finger.SetActive(false);
            SleepingSymbols.SetActive(true);
            BlackScreen.SetActive(true);
            ClosedEye.SetActive(true);
            alarmClock();
            //LoadingBgActive();
        }
    }

    #endregion

    #region Utility Methods

    private void SetViewContents()
    {
        GameManager.instance.currentScene = GameUtils.SLEEPING_VIEW_SCENE;
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
        ClosedEyes.GetComponent<Image>().sprite = ClosedEyesList[unicornId];
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

    private void ScaleAction(GameObject obj, float scaleval, float time, iTween.EaseType type, iTween.LoopType loopType)
    {
        Hashtable tweenParams = new Hashtable();
        tweenParams.Add("scale", new Vector3(scaleval, scaleval, 0));
        tweenParams.Add("time", time);
        tweenParams.Add("easetype", type);
        tweenParams.Add("looptype", loopType);
        iTween.ScaleTo(obj, tweenParams);
    }

    private void MoveAction(GameObject obj, RectTransform pos, float time, iTween.EaseType actionType, iTween.LoopType loopType)
    {
        Hashtable tweenParams = new Hashtable();
        tweenParams.Add("x", pos.position.x);
        tweenParams.Add("y", pos.position.y);
        tweenParams.Add("time", time);
        tweenParams.Add("easetype", actionType);
        tweenParams.Add("looptype", loopType);
        iTween.MoveTo(obj, tweenParams);
    }

    private void RotateAction(GameObject obj, float roatationamount, float t, iTween.EaseType actionType, iTween.LoopType loopType)
    {
        Hashtable tweenParams = new Hashtable();
        tweenParams.Add("z", roatationamount);
        tweenParams.Add("time", t);
        tweenParams.Add("easetype", actionType);
        tweenParams.Add("looptype", loopType);
        iTween.RotateTo(obj, tweenParams);
    }

    private void ShakeAction(GameObject obj)
    {
        Hashtable tweenParams = new Hashtable();
        tweenParams.Add("amount", new Vector3(0.02f, 0.02f, 0.02f));
        tweenParams.Add("time", 1.0f);
        tweenParams.Add("easetype", iTween.EaseType.easeInCubic);
        tweenParams.Add("looptype", iTween.LoopType.pingPong);
        iTween.ShakePosition(obj, tweenParams);
    }

    #endregion

    #region CallBack Methods

    public void switchLamp()
    {
        bgSound.GetComponent<AudioSource>().volume = 0.3f;
        SoundManager.instance.PlayButtonClickSound();
        Finger.SetActive(false);
        if (lampOn.activeSelf)
        {
            lampOn.SetActive(false);
            SleepingSymbols.SetActive(true);
            BlackScreen.SetActive(true);
            ClosedEye.SetActive(true); 
            LoadingBgActive();
        } else
        {
            lampOn.SetActive(true);
            SleepingSymbols.SetActive(false);
            BlackScreen.SetActive(false);
            ClosedEye.SetActive(false);
            LoadingScreen.SetActive(false);
            LoadingFilled.fillAmount = 0;
            StopAllCoroutines();
        }
    }



    private void LoadingBgActive()
    {
        Debug.Log(PlayerPrefs.GetInt("PlayingLevel"));
        LoadingScreen.SetActive(true);
        StartCoroutine(FillAction(LoadingFilled));
        Invoke("taskPanelOff", 4.0f);
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

    private void loadNextSence()
    {
        if (PlayerPrefs.GetInt("PetCareMode") == 1)
        {
            if (PlayerPrefs.GetInt("AnimalPlayed") == PlayerPrefs.GetInt("PetSelected"))
            {
                PlayerPrefs.SetInt("AnimalPlayed", PlayerPrefs.GetInt("AnimalPlayed") + 1);
            }

        }
        SoundManager.instance.PlayGoodJobSound();
        taskMessageImage.sprite = taskMessageSprite[1];
        //taskePanel.SetActive(true);
        Invoke("taskPanelOff", 0.1f);
        //NavigationManager.instance.ReplaceScene(GameScene.MAINMENU);
    }


    void taskPanelOff()
    {
        taskePanel.SetActive(false);
        //popupActive();
        if (PlayerPrefs.GetInt("PlayingLevel") == 11)
        {
            BlackScreen.SetActive(false);
            levelCompletePanel.SetActive(true);
            PrefsManager.instance.SetPlayerScore(1000);
            if (PlayerPrefs.GetInt("LevelPlayed") == PlayerPrefs.GetInt("levelPlayedId"))
            {
                PlayerPrefs.SetInt("LevelPlayed", PlayerPrefs.GetInt("LevelPlayed") + 1);
            }
        }
        else
        {
            alarmClock();
        }
    }

    void alarmClock()
    {
        SoundManager.instance.PlayButtonClickSound();
        Finger.SetActive(true);
        alarmClockObj.SetActive(true);
        lampOn.SetActive(false);
        lampOff.SetActive(false);
    }

    public void alarmClockClick()
    {
        clockAnim.SetBool("isClicked", true);
        SoundManager.instance.PlayAlarmClockSound();
        Finger.SetActive(false);
        Invoke("alarmClockRun", 2.0f);
    }

    void alarmClockRun()
    {
        SleepingSymbols.SetActive(false);
        BlackScreen.SetActive(false);
        ClosedEye.SetActive(false);
        LoadingScreen.SetActive(false);
        Invoke("popupActive", 2.0f);
    }

    private void LoadingBgActive1()
    {
        LoadingFilled1.fillAmount = 0;
        Loading.SetActive(true);
        StartCoroutine(FillAction1(LoadingFilled1));
        Invoke("AdCalled", 1.0f);
        Invoke("LoadingFull", 4.0f);
    }

    IEnumerator FillAction1(Image img)
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
        if (PlayerPrefs.GetInt("CareerMode") == 1)
        {
            careerModeData();
        }
        SoundManager.instance.PlayButtonClickSound();
        objectivePanel.SetActive(false);
        setUpUniCorn();
        Invoke("SetViewContents", 0.1f);
    }



    private void popupActive()
    {
        Debug.Log(PlayerPrefs.GetInt("PlayingLevel"));
        if (PlayerPrefs.GetInt("CareerMode") == 1)
        {
            if (PlayerPrefs.GetInt("PlayingLevel") == 0)
            {
                levelCompletePanel.SetActive(true);
                PrefsManager.instance.SetPlayerScore(1000);
                if (PlayerPrefs.GetInt("LevelPlayed") == PlayerPrefs.GetInt("levelPlayedId"))
                {
                    PlayerPrefs.SetInt("LevelPlayed", PlayerPrefs.GetInt("LevelPlayed") + 1);
                }
            }
            if (PlayerPrefs.GetInt("PlayingLevel") == 11)
            {
                levelCompletePanel.SetActive(true);
                PrefsManager.instance.SetPlayerScore(1000);
                if (PlayerPrefs.GetInt("LevelPlayed") == PlayerPrefs.GetInt("levelPlayedId"))
                {
                    PlayerPrefs.SetInt("LevelPlayed", PlayerPrefs.GetInt("LevelPlayed") + 1);
                }
            }
        } else
        {
            if (PlayerPrefs.GetInt("PetCareMode") == 1)
            {
                //levelCompletePetCare.SetActive(true);
                PrefsManager.instance.SetPlayerScore(5000);
            }
            if (PlayerPrefs.GetInt("RandomMode") == 1)
            {
                //levelCompletePetCare.SetActive(true);
                PrefsManager.instance.SetPlayerScore(10000);
            }
            bgSound.GetComponent<AudioSource>().volume = 0.6f;
            lastpopup.SetActive(true);
            ScaleAction(lastpopup.transform.GetChild(0).gameObject, 0.8f, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
            SoundManager.instance.PlayPopupCloseSound();
            Invoke("treatmentTextAppear", 1.2f);
        }
    }

    private void treatmentTextAppear()
    {
        SoundManager.instance.PlayGirlSound();
        ScaleAction(treamentText, 1.0f, 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
        Invoke("treatMentStamp", 0.3f);
    }

    private void treatMentStamp()
    {
        SoundManager.instance.playstampSound();
        MoveAction(treamentText, treatmentTextEndPoint, 0.3f, iTween.EaseType.easeInBounce, iTween.LoopType.none);
        Invoke("nextButtonActive", 0.7f);
        Invoke("treamentParticleAppear", 0.3f);
    }

    private void treamentParticleAppear()
    {
        ParticleManger.instance.showStarParticle(treamentText);

    }

    private void nextButtonActive()
    {
        SoundManager.instance.PlayButtonClickSound();
        //Invoke("popupActive", 2.0f);
        //nextButton.SetActive(true);
        nextSceneButton.SetActive(true);
    }


    public void OnNextSceneClick()
    {
        SoundManager.instance.PlayButtonClickSound();
        //NavigationManager.instance.ReplaceScene(GameScene.MAINMENU);
        if (PlayerPrefs.GetInt("PetCareMode") == 1)
        {
            petCareScoreText.text = "Reward : 5000";
            rewaredText.text = "Watch Ad for 15000 Reward";
            levelCompletePetCare.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("RandomMode") == 1)
        {
            petCareScoreText.text = "Reward : 10000";
            rewaredText.text = "Watch Ad for 30000 Reward";
            levelCompletePetCare.SetActive(true);
        }
        lastpopup.SetActive(false);
        ScaleAction(lastpopup.transform.GetChild(0).gameObject, 0.0f, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
        if (PlayerPrefs.GetInt("PetCareMode") == 1)
        {
            if (PlayerPrefs.GetInt("AnimalPlayed") == PlayerPrefs.GetInt("PetSelected"))
            {
                PlayerPrefs.SetInt("AnimalPlayed", PlayerPrefs.GetInt("AnimalPlayed") + 1);
            }

        }

        //NavigationManager.instance.ReplaceScene(GameScene.MAINMENU);
        
        
        //Invoke("popupActive", 0.1f);
        //levelCompletedParticles.SetActive(true);
        //Next.SetActive(false);
        //MainGrid.SetActive(false);
        //UnicornInstantiate();
        //loadingImage.SetActive(true);
        //AssignAdIds_CB.instance.CallInterstitialAd(Adspref.JustStatic);
        //Invoke("loadNextScene", 3.0f);

    }

    void AdCalled()
    {
        AdsManager.Instance.ShowInterstitial("Level Complete");
    }
    #endregion
}
