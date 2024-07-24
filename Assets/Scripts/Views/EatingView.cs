using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class EatingView : MonoBehaviour
{
    #region Variables, Constants & Initializers
    // Use this for initialization\

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


    private bool timeflag = false;
    private int boneCounter = 0;
    private int dragCounter = 0;
    private int eatingCounter = 0;
    public int eatingItemCounter = 0;
    public GameObject sideTable;
    public GameObject sideTable1;
    public GameObject panda;
    public RectTransform bottomTableEndPoint, sideTableEndPoint, sideTableStartPoint, pandaEndPoint;
    public GameObject XrayMachine, originalXrayMachine;
    private Vector3 startXrayPosition;
    private Vector3 startXrayMachinePosition;
    public RectTransform xrayMachineStartPoint, xrayMachineEndPoint, xrayMachineCrackPoint;
    public GameObject xrayimage;
    public GameObject warningImage;
    public GameObject bonesPopup;
    public GameObject headBandage, ArmBandage, headBandage1, ArmBandage1;
    public RectTransform bandageEndPoint, bandageStartPoint, headBandageOutPoint, armBandageOutPoint;
    public GameObject headBandageHand, armHand, eatingHand;
    public RectTransform headHandEndPOint, armHandEndPoint, eatingHandEndPoint;
    public GameObject medicineTray, medicine;
    public RectTransform medicineTrayEndPoint, medicineTrayStartPoint, medicineMouthPoint;
    public GameObject plate, spoon;
    public GameObject itemPlate;
    public Sprite[] spoonSprites;
    public RectTransform plateEndPoint, itemStartPoint, itemEndPoint, plateStartPoint, spoonEndPoint, spoonMouthPoint, eatingPoint;
    public GameObject pandaFace, mouth, closeMouth;
    public GameObject nextButton;
    public GameObject lastpopup, treamentText;
    public RectTransform treatmentTextEndPoint;
    public Image popupImage;
    public GameObject originalPopup;
    public GameObject headSwell, armSwell;
    public Image blackScreen;
    public GameObject newBg;
    public GameObject newPanda;
    public RectTransform newPandaEndPoint;
    public GameObject frame, cameraButton, lastNextButton;
    public GameObject levelEndParticles;
    public Image expressions;
    public Sprite[] faceImages;
    public GameObject levelComplete;

    public GameObject homeButton;
    public GameObject backButton;
    public GameObject menuButton;

    public int levelCount;

    private int unicornId;

    public GameObject eatingCountObj;
    public GameObject eatingCountIntObj;
    public Text eatingCount;
    public int eatingCountInt;
    public GameObject banner;

    public Sprite[] taskMessageSprite;
    public Image taskMessageImage;
    public GameObject taskePanel;

    public GameObject levelCompletePanel;
    public GameObject objectivePanel;

    private int itemCount;

    public GameObject nextSceneButton;

    public GameObject bgSound;

    public Image[] EatingItemsImages;

    public Sprite[] EatingItemsSprite;

    public Text objectiveText;

    public Text animalName;

    public GameObject table1, table2;
    public Button leftBtn, rightBtn;

    public GameObject Finger;

    #endregion

    #region Lifecycle Methods
    void Awake()
    {
        GameManager.instance.currentScene = GameUtils.EATING_VIEW_SCENE;
    }

    void Start()
    {
        if (PlayerPrefs.GetInt("FingerTutorial") == 0)
        {
            Finger.SetActive(true);
        } else
        {
            Finger.SetActive(false);
        }
        if (PlayerPrefs.GetInt("isEatingHand") == 0)
        {
            eatingHand.SetActive(true);
            MoveAction(eatingHand, eatingHandEndPoint, 1.0f, iTween.EaseType.linear, iTween.LoopType.loop);
            PlayerPrefs.SetInt("isEatingHand", 1);
        }
        animalName.text = PlayerPrefs.GetString("SelectedPetName");
        if (PlayerPrefs.GetInt("CareerMode") == 1)
        {
            if (PlayerPrefs.GetInt("PlayingLevel") == 1)
            {
                objectiveText.text = PlayerPrefs.GetString("SelectedPetName") + " is hungry, She need something to eat";
            }
            if (PlayerPrefs.GetInt("PlayingLevel") == 10)
            {
                objectiveText.text = PlayerPrefs.GetString("SelectedPetName") + " is hungry, She need something to eat, before sleeping";
            }
        }
        if (PlayerPrefs.GetInt("PetCareMode") == 1)
        {
            objectiveText.text = PlayerPrefs.GetString("SelectedPetName") + " is very hungry, please give him something to eat.";
        }
        eatingItemsSetting();
        if (PlayerPrefs.GetInt("MusicContoller") == 1)
        {
            bgSound.GetComponent<AudioSource>().Play();
        }
        else
        {
            bgSound.GetComponent<AudioSource>().Stop();
        }
        unicornId = PlayerPrefs.GetInt("PetSelected");

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
        setUpLoadingUniCorn();
        PlayerPrefs.SetInt("ComingFromSplash", 0);

    }
    

    public void nextLevel()
    {
        PlayerPrefs.SetInt("levelPlayedId", PlayerPrefs.GetInt("levelPlayedId") + 1);
        SoundManager.instance.PlayButtonClickSound();
        if (PlayerPrefs.GetInt("PlayingLevel") == 1)
        {
            PlayerPrefs.SetInt("PlayingLevel", 2);
            NavigationManager.instance.ReplaceScene(GameScene.BATHVIEW);
        } else if (PlayerPrefs.GetInt("PlayingLevel") == 10)
        {
            PlayerPrefs.SetInt("PlayingLevel", 11);
            NavigationManager.instance.ReplaceScene(GameScene.SLEEPINGVIEW);
        }
    }

    public void RestartLevel()
    {
        SoundManager.instance.PlayButtonClickSound();
        NavigationManager.instance.ReplaceScene(GameScene.EATINGVIEW);
    }

    public void TriplleReward()
    {
        AdsManager.Instance.ShowRewarded(() =>
        {
            PrefsManager.instance.SetPlayerScore(2000);
            NavigationManager.instance.ReplaceScene(GameScene.MAINMENU);
        }, "Counter Incremented");
    }
    #endregion

    #region Utility Methods

    private void SetViewContents()
    {

        //startXrayPosition = xrayimage.GetComponent<RectTransform>().localPosition;
        //startXrayMachinePosition = XrayMachine.GetComponent<RectTransform>().localPosition;
        //xrayMachineComesInn ();
        //pandaPositioning();
        //bonesPopupActive();
        //headBandageComesInn ();
        //medicineTrayComesInn();
        //plateComesInn ();
    }

    void eatingItemsSetting()
    {
        for (int t = 0; t < EatingItemsSprite.Length; t++)
        {
            Sprite tmp = EatingItemsSprite[t];
            int r = Random.Range(t, EatingItemsSprite.Length);
            EatingItemsSprite[t] = EatingItemsSprite[r];
            EatingItemsSprite[r] = tmp;
        }
        for (int i = 0; i < EatingItemsImages.Length; i++)
        {
            EatingItemsImages[i].sprite = EatingItemsSprite[i];
            EatingItemsImages[i].GetComponent<Image>().SetNativeSize();
            Debug.Log(EatingItemsSprite[i].name);
        }
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

    private void colorIncreases(Image img, float val)
    {
        if (img.color.a < 1)
        {
            img.color = new Vector4(img.color.r, img.color.g, img.color.b, img.color.a + val);
        }
    }

    private void colorDecreases(Image img, float value)
    {
        if (img.color.a > 0)
        {
            img.color = new Vector4(img.color.r, img.color.g, img.color.b, img.color.a - value);
        }
    }

    private void sideTablePositioning()
    {
        
            MoveAction(sideTable, sideTableEndPoint, 0.5f, iTween.EaseType.easeInBounce, iTween.LoopType.none);
            //MoveAction(sideTable, sideTableStartPoint, 0.5f, iTween.EaseType.easeInBounce, iTween.LoopType.none);
            //Invoke("eatingItemsComesInn", 0.7f);
    }

    private void xrayMachineComesInn()
    {
        SoundManager.instance.PlayToolComesSound();
        XrayMachine.SetActive(true);
        MoveAction(XrayMachine, xrayMachineEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
        Invoke("xrayMachineListenerOn", 0.6f);
    }

    private void xrayMachineListenerOn()
    {
        XrayMachine.GetComponent<ApplicatorListener>().enabled = true;
    }

    private void xrayMachineGoOutside()
    {
        MoveAction(XrayMachine, xrayMachineStartPoint, 0.5f, iTween.EaseType.easeInBack, iTween.LoopType.none);
    }

    private void xrayMachineShake()
    {
        ShakeAction(XrayMachine.gameObject);
        iTween.Pause(XrayMachine.gameObject);
        xrayMachineGoOutside();
        Invoke("bonesPopupActive", 0.3f);
    }

    private void bonesPopupActive()
    {

        warningImage.SetActive(true);
        SoundManager.instance.playWarningSound();
    }

    private void bonesPopupClose()
    {
        SoundManager.instance.PlayPopupCloseSound();
        bonesPopup.SetActive(false);
        expressions.sprite = faceImages[0];
        ParticleManger.instance.showPointingParticle(warningImage.gameObject);
        Invoke("headBandageComesInn", 0.5f);
        Debug.Log("Level1 Done");
    }

    private void headBandageComesInn()
    {
        expressions.sprite = faceImages[0];
        SoundManager.instance.PlayToolComesSound();
        headBandage.SetActive(true);
        MoveAction(headBandage, bandageEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
        Invoke("headBandageListenerOn", 0.5f);
    }

    private void headBandageListenerOn()
    {
        headBandageHand.SetActive(true);
        MoveAction(headBandageHand, headHandEndPOint, 1.0f, iTween.EaseType.linear, iTween.LoopType.loop);
        headBandage.GetComponent<ApplicatorListener>().enabled = true;
    }

    private void armBandageComesInn()
    {
        SoundManager.instance.PlayToolComesSound();
        ArmBandage.SetActive(true);
        MoveAction(ArmBandage, bandageEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
        Invoke("ArmBandageListenerOn", 0.5f);
    }

    private void ArmBandageListenerOn()
    {
        expressions.sprite = faceImages[0];
        armHand.SetActive(true);
        MoveAction(armHand, armHandEndPoint, 1.0f, iTween.EaseType.linear, iTween.LoopType.loop);
        ArmBandage.GetComponent<ApplicatorListener>().enabled = true;
    }

    private void medicineTrayComesInn()
    {
        SoundManager.instance.PlayToolComesSound();
        medicineTray.SetActive(true);
        MoveAction(medicineTray, medicineTrayEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
        Invoke("makingMedicineListenerOn", 0.5f);
    }

    private void makingMedicineListenerOn()
    {
        medicine.GetComponent<ApplicatorListener>().enabled = true;
    }

    private void scaleOutMedicine()
    {
        ScaleAction(medicine, 0.0f, 1.0f, iTween.EaseType.linear, iTween.LoopType.none);
        Invoke("medicineTrayGoesout", 1.0f);
    }

    private void medicineTrayGoesout()
    {
        ParticleManger.instance.showPointingParticle(pandaFace.gameObject);
        MoveAction(medicineTray, medicineTrayStartPoint, 0.5f, iTween.EaseType.easeInBack, iTween.LoopType.none);
        MoveAction(sideTable, sideTableStartPoint, 0.5f, iTween.EaseType.easeInBounce, iTween.LoopType.none);
        //Invoke("plateComesInn", 0.7f);
        Invoke("eatingItemsComesInn", 0.7f);
        Debug.Log("Level2 Done");
    }

    private void plateComesInn()
    {
        SoundManager.instance.PlayToolComesSound();
        plate.SetActive(true);
        MoveAction(plate, plateEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
        Invoke("spoonListenerOn", 0.6f);
    }

    private void eatingItemsComesInn()
    {
        SoundManager.instance.PlayToolComesSound();
        MoveAction(itemPlate, itemEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
    }

    private void spoonListenerOn()
    {
        spoon.GetComponent<ApplicatorListener>().enabled = true;
    }

    private void platesGoOutside()
    {
        MoveAction(plate, plateStartPoint, 0.5f, iTween.EaseType.easeInBack, iTween.LoopType.none);
        Invoke("toolsCompleted", 0.6f);
    }

    private void toolsCompleted()
    {
        //ParticleManger.instance.showPointingParticle(pandaFace.gameObject);
        Invoke ("popupActive", 2.0f);
        Debug.Log("Level3 Done");
    }

    private void popupActive()
    {
        lastpopup.SetActive(true);
        ScaleAction(lastpopup.transform.GetChild(0).gameObject, 0.8f, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
        SoundManager.instance.PlayPopupCloseSound();
        Invoke("treatmentTextAppear", 1.2f);
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

    private void popUpClose()
    {
        StartCoroutine(FadeOutAction(popupImage));
        ScaleAction(originalPopup, 0.0f, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
        Invoke("pandaBandgeGoesOut", 1.2f);

    }

    private void pandaBandgeGoesOut()
    {
        SoundManager.instance.PlayToolGoesSound();
        MoveAction(headBandage1, headBandageOutPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
        MoveAction(ArmBandage1, armBandageOutPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
        Invoke("blackScreenActive", 1.5f);
    }

    private void blackScreenActive()
    {
        blackScreen.gameObject.SetActive(true);
        newBg.SetActive(true);
        StartCoroutine(FadeOutAction(blackScreen));
        Invoke("newPandaComes", 2.0f);
    }

    private void newPandaComes()
    {
        blackScreen.gameObject.SetActive(false);
        newPanda.SetActive(true);
        MoveAction(newPanda, newPandaEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
        Invoke("cameraButtonActive", 0.7f);
    }

    private void cameraButtonActive()
    {
        cameraButton.SetActive(true);
    }

    private void photoFrameComes()
    {
        frame.SetActive(true);
        ScaleAction(frame, 1.0f, 0.3f, iTween.EaseType.easeInBounce, iTween.LoopType.none);
        Invoke("lastNextButtonActive", 0.7f);
    }

    private void lastNextButtonActive()
    {
        SoundManager.instance.playLevelCompletedSound();
        levelEndParticles.SetActive(true);
        if (PlayerPrefs.GetInt("PetCareMode") == 1)
        {
            if (PlayerPrefs.GetInt("AnimalPlayed") == 4)
            {
                PlayerPrefs.SetInt("AnimalPlayed", 5);
            }
        }
        lastNextButton.SetActive(true);

    }

    #endregion

    #region Utility Methods
    public void xrayMachineBeginDrag()
    {
        //iTween.Pause (XrayMachine);
        XrayMachine.transform.GetChild(0).gameObject.SetActive(true);
        XrayMachine.GetComponent<Image>().enabled = false;

    }
    public void xrayMachineEndDrag()
    {
        XrayMachine.transform.GetChild(0).gameObject.SetActive(false);
        XrayMachine.GetComponent<Image>().enabled = true;

    }

    public void xrayMachineDrag()
    {
        expressions.sprite = faceImages[1];
        Vector3 difference = startXrayMachinePosition - XrayMachine.GetComponent<RectTransform>().localPosition;
        Vector3 localPosition = xrayimage.GetComponent<RectTransform>().localPosition;
        xrayimage.GetComponent<RectTransform>().localPosition = new Vector3(startXrayPosition.x - 370 + difference.x, startXrayPosition.y + 180 + difference.y, localPosition.z);
        //		print ("DragCouter"+dragCounter++);
        dragCounter++;
        if (dragCounter >= 200)
        {
            SoundManager.instance.PlayscanningLoop(false);
            XrayMachine.GetComponent<ApplicatorListener>().enabled = false;
            //MoveAction (XrayMachine, xrayMachineCrackPoint, 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
            Invoke("xrayMachineShake", 0.3f);
        }
    }

    public void onCollisionWithXrayMachine()
    {

    }

    public void OnCollisionWithBones()
    {
        boneCounter++;
        if (boneCounter >= 5)
        {
            Invoke("bonesPopupClose", 1.5f);

        }
    }

    public void onCollisionWithHadBandage()
    {
        expressions.sprite = faceImages[1];
        headBandageHand.SetActive(false);
        headSwell.SetActive(false);
        Invoke("armBandageComesInn", 1.0f);
    }

    public void onCollisionWithArmBandage()
    {
        expressions.sprite = faceImages[1];
        armHand.SetActive(false);
        armSwell.SetActive(false);
        Invoke("medicineTrayComesInn", 1.0f);

        Debug.Log("Level2 Done");
    }

    public void onCollisionOfMedicine()
    {
        expressions.sprite = faceImages[1];
        SoundManager.instance.playmedicineSound();
        MoveAction(medicine, medicineMouthPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
        Invoke("scaleOutMedicine", 0.5f);
    }

    public void onCollisionSpoonWithMouth()
    {
        expressions.sprite = faceImages[0];
        if (GameManager.instance.currentItem == "mouth")
        {
            MoveAction(spoon, spoonMouthPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
            Invoke("spoonEmpty", 0.8f);
        }
        else if (GameManager.instance.currentItem == "Plate")
        {
            spoon.GetComponent<Image>().sprite = spoonSprites[1];
        }
    }
    void disableCloseMouth()
    {
        closeMouth.SetActive(false);
    }

    public void OnCollisionWithEatingItems(GameObject eatingItem)
    {
        eatingHand.SetActive(false);
        itemCount++;
        SoundManager.instance.PlayBiteSound();
        closeMouth.SetActive(true);
        Invoke("disableCloseMouth", 2.0f);
        MoveAction(eatingItem, eatingPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
        ScaleAction(eatingItem, 0.0f, 2.0f, iTween.EaseType.linear, iTween.LoopType.none);
        Destroy(eatingItem, 1.5f);
        eatingCountInt++;

        nextButton.SetActive(true);
        eatingCount.text = eatingCountInt + "/3".ToString();
        if (eatingItemCounter > 1)
        {
            eatingCountObj.SetActive(false);
            eatingCountIntObj.SetActive(false);
            nextButton.SetActive(true);
        }
        else
        {
            eatingItemCounter++;
        }
        if (itemCount % 2 == 0)
        {
            SoundManager.instance.PlayGoodJobSound();
            taskMessageImage.sprite = taskMessageSprite[1];
            taskePanel.SetActive(true);
            Invoke("taskPanelOff", 3.0f);
        }

        //Invoke("eatingItemGoesBack", 2.0f);
        //Invoke("toolsCompleted", 2.0f);
    }

    void taskPanelOff()
    {
        taskePanel.SetActive(false);
    }

    void eatingItemGoesBack()
    {
        MoveAction(itemPlate, itemStartPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
    }

    private void spoonEmpty()
    {
        SoundManager.instance.PlayBiteSound();
        spoon.GetComponent<Image>().sprite = spoonSprites[0];
        Invoke("smoothStartPoint", 0.3f);
    }

    private void smoothStartPoint()
    {
        MoveAction(spoon, spoonEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
        Invoke("spoonAgainActive", 0.7f);
    }

    private void spoonAgainActive()
    {
        spoon.GetComponent<ApplicatorListener>().enabled = true;
        spoon.GetComponent<BoxCollider2D>().enabled = true;
        plate.GetComponent<BoxCollider2D>().enabled = true;
        mouth.GetComponent<BoxCollider2D>().enabled = true;
        print("eatingCounter" + ++eatingCounter);
        if (eatingCounter > 3)
        {
            spoon.GetComponent<ApplicatorListener>().enabled = false;
            spoon.GetComponent<BoxCollider2D>().enabled = false;
            plate.GetComponent<BoxCollider2D>().enabled = false;
            mouth.GetComponent<BoxCollider2D>().enabled = false;
            Invoke("platesGoOutside", 0.3f);
        }
    }

    IEnumerator FadeOutAction(Image img)
    {
        if (img.color.a > 0)
        {
            img.color = new Vector4(img.color.r, img.color.g, img.color.b, img.color.a - 0.03f);
            yield return new WaitForSeconds(0.05f);
            StartCoroutine(FadeOutAction(img));
        }
        else if (img.color.a < 0)
        {
            StopCoroutine(FadeOutAction(img));
        }
    }

    public void onCliockWarningButton()
    {
        SoundManager.instance.PlayPopupCloseSound();
        warningImage.SetActive(false);
        bonesPopup.SetActive(true);

    }

    public void onClickNextButton()
    {
        SoundManager.instance.PlayButtonClickSound();
        NavigationManager.instance.ReplaceScene(GameScene.SLEEPINGVIEW);
        nextButton.SetActive(false);
        popUpClose();


    }

    public void OnClickCameraButton()
    {
        SoundManager.instance.playcameraSound();
        cameraButton.SetActive(false);
        photoFrameComes();
    }

    public void OnClickLastNext()
    {
        SoundManager.instance.PlayButtonClickSound();
        NavigationManager.instance.ReplaceScene(GameScene.SLEEPINGVIEW);

    }

    public void homeBtn()
    {
        PlayerPrefs.SetInt("ComingToHome", 1);
        PlayerPrefs.SetInt("ComingFromSplash", 1);
        SoundManager.instance.PlayButtonClickSound();
        NavigationManager.instance.ReplaceScene(GameScene.MAINMENU);
    }

    public void nextBtn()
    {
        levelComplete.SetActive(false);
    }
    public void OnNextClick()
    {
        SoundManager.instance.PlayButtonClickSound();
        nextButton.SetActive(false);
        if (PlayerPrefs.GetInt("CareerMode") == 1)
        {
            if (PlayerPrefs.GetInt("PlayingLevel") == 1)
            {
                levelCompletePanel.SetActive(true);
            }
            if (PlayerPrefs.GetInt("PlayingLevel") == 10)
            {
                levelCompletePanel.SetActive(true);
            }
            PrefsManager.instance.SetPlayerScore(1000);
            if (PlayerPrefs.GetInt("LevelPlayed") == PlayerPrefs.GetInt("levelPlayedId"))
            {
                PlayerPrefs.SetInt("LevelPlayed", PlayerPrefs.GetInt("LevelPlayed") + 1);
            }
        } else
        {
            Invoke("popupActive", 0.1f);
        }
        //levelCompletedParticles.SetActive(true);
        //MainGrid.SetActive(false);
        //UnicornInstantiate();
        //loadingImage.SetActive(true);
        //AssignAdIds_CB.instance.CallInterstitialAd(Adspref.JustStatic);
        //Invoke("loadNextScene", 3.0f);

    }
    public void OnNextSceneClick()
    {
        //Invoke("popupActive", 0.1f);
        //levelCompletedParticles.SetActive(true);
        SoundManager.instance.PlayButtonClickSound();
        //Next.SetActive(false);
        //MainGrid.SetActive(false);
        //UnicornInstantiate();
        //loadingImage.SetActive(true);
        //AssignAdIds_CB.instance.CallInterstitialAd(Adspref.JustStatic);
        NavigationManager.instance.ReplaceScene(GameScene.SLEEPINGVIEW);
        //Invoke("loadNextScene", 3.0f);

    }

    private void loadNextScene()
    {
        NavigationManager.instance.ReplaceScene(GameScene.SLEEPINGVIEW);
    }

    public void unlockEatingItem(GameObject item)
    {
         item.GetComponent<ApplicatorListener>().enabled = true;
         item.transform.GetChild(0).gameObject.SetActive(false);
        // AdsManager.Instance.ShowRewarded(() =>
        // {
        //     item.GetComponent<ApplicatorListener>().enabled = true;
        //     item.transform.GetChild(0).gameObject.SetActive(false);
        // }, "Counter Incremented");
    }

    public void OnPanelClosed(GameObject parent)
    {
        parent.SetActive(false);
        SoundManager.instance.PlayButtonClickSound();
    }


    private void LoadingBgActive()
    {
        eatingCount.text = "0/3";
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
        //GameManager.instance.currentScene = GameUtils.EATING_VIEW_SCENE;
        Invoke("SetViewContents", 0.1f);
    }

    void AdCalled()
    {
        AdsManager.Instance.ShowInterstitial("Level Complete");
    }

    public void sound()
    {
        SoundManager.instance.PlayButtonClickSound();
    }

    public void tableRight()
    {
        SoundManager.instance.PlayButtonClickSound();
        table1.SetActive(false);
        table2.SetActive(true);
        rightBtn.interactable = false;
        leftBtn.interactable = true;
        if (PlayerPrefs.GetInt("FingerTutorial") == 0)
        {
            Finger.SetActive(false);
            //PlayerPrefs.SetInt("FingerTutorial", 1);
        }
    }

    public void tableLeft()
    {
        SoundManager.instance.PlayButtonClickSound();
        table1.SetActive(true);
        table2.SetActive(false);
        rightBtn.interactable = true;
        leftBtn.interactable = false;
    }

    #endregion
}
