using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CareerCatView : MonoBehaviour
{
    #region Variables, Constants & Initializers
    // Use this for initialization\
    private int leafCount = 0;
    private int rashCounter = 0;
    private int tubeCounter = 0;
    private int TrayCounter = 0;
    public GameObject bottomTable;
    public GameObject sideTable;
    public GameObject cat, catEyeClose;
    public RectTransform bottomTableEndPoint, sideTableEndPoint, catEndPoint;
    public GameObject ratTrap, rat, trapArrow;
    public RectTransform ratTrapEndPoint, ratTrapStartPoint, ratTrapPointingPoint;
    public Sprite trapedRat;
    public GameObject trash;
    public RectTransform trashStartPoint, trashEndPoint;
    public GameObject leaf1, leaf2, leaf3, leaf4, leaf5, leaf6, leaf7, leaf8;
    public RectTransform leafUpperEndPoint, leafLowerPoint;
    public GameObject leafHand;
    public RectTransform leafHandEndPoint;
    public GameObject rashRemover;
    public RectTransform rashRemoverStartPoint, rashRemoverEndPoint, rashBrushEndPoint;
    public GameObject rashBrush;
    public Image rash1, rash2, rash3, rash4;
    public GameObject rashArrow1, rashArrow2, rashArrow3, rashArrow4;
    public GameObject rashCream;
    public Image rashgerm1, rashgerm2, rashgerm3;
    public Image rashgermcream1, rashgermcream2, rashgermcream3;
    public RectTransform rashCreamEndPoint, rashCreamStartPoint, rashCream1StartPoint, rashCream1EndPoint, rashCream2StartPoint, rashCream2EndPoint, rashCream3StartPoint, rashCream3EndPoint;
    public Image bandage, tailBandage;
    public RectTransform bandageEndPoint, bandageStartPoint;
    public GameObject meatPlate, meat;
    public RectTransform plateStartPoint, plateEndPoint, meatEatingPoint, meatEatingPoint1, meatEatingPoint2, meatEatingPoint3, meatEatingPoint4;
    public GameObject[] WoodWounds;
    public GameObject[] TrayWoods;
    public GameObject TweekerTool;
    public Sprite[] TweekerSprite;
    public GameObject Tray;
    public RectTransform TrayStartPosition, TrayEndPosition;
    public RectTransform tweekerStartPoint, tweekerEndPoint;
    public Image thornRash1, thornRash2, thornRash3, thornRash4, thornRash5;
    public GameObject tweekerHand;
    public RectTransform tweekerHandEndPoint;
    public Image catFace;
    public Sprite[] faceExpressions;
    public GameObject nextButton;
    public GameObject bandageHand;
    public RectTransform bandageHandEndPoint;
    public GameObject mouth;
    public GameObject lastpopup, treamentText;
    public RectTransform treatmentTextEndPoint;
    public GameObject Face, tale;
    public GameObject taleBandage, swelled;
    public RectTransform taleBandageOutPoint;
    public Image popupImage;
    public GameObject originalPopup;
    public GameObject levelEndParticles;
    public Image blackScreen;
    public GameObject newBg;
    public GameObject newCat;
    public RectTransform newCatEndPoint;
    public GameObject frame, cameraButton, lastNextButton;

    #endregion

    #region Lifecycle Methods

    // Use this for initialization
    void Start()
    {
        Invoke("SetViewContents", 0.1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    #endregion

    #region Utility Methods

    private void SetViewContents()
    {
        GameManager.instance.currentScene = GameUtils.CAT_VIEW_SCENE;
        animalFaceMovement();
        bottomTablePositioning();
        //		ratTrapComesInn ();
        //rashRemoverComesInn ();
        //bandageComesInn();
        //meatPlateComesInn();
        //rashCreamComesInn();
        //tweekerComesInn();

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
        tweenParams.Add("amount", new Vector3(0.05f, 0.05f, 0.05f));
        tweenParams.Add("time", 1.0f);
        tweenParams.Add("easetype", iTween.EaseType.easeInCubic);
        tweenParams.Add("looptype", iTween.LoopType.pingPong);
        iTween.ShakePosition(obj, tweenParams);
    }

    //	private void MoveProgressBarComesInn(){
    //		powerImage.fillAmount = 0;
    //		MoveAction (progressBar,progressBarEndPoint,1.0f,iTween.EaseType.easeInOutBounce,iTween.LoopType.none);
    //	}
    //
    //	private void MoveProgressBarGoesOut(){
    //		MoveAction (progressBar,progressBarStartPoint,0.5f,iTween.EaseType.easeInOutBack,iTween.LoopType.none);
    //	}

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

    private void animalFaceMovement()
    {
        RotateAction(Face, -3.0f, 2.0f, iTween.EaseType.linear, iTween.LoopType.pingPong);
        RotateAction(tale, 4.0f, 2.0f, iTween.EaseType.linear, iTween.LoopType.pingPong);

    }

    private void bottomTablePositioning()
    {
        SoundManager.instance.PlayToolComesSound();
        MoveAction(bottomTable, bottomTableEndPoint, 0.5f, iTween.EaseType.easeInBounce, iTween.LoopType.none);
        Invoke("catPositioning", 0.7f);
    }

    private void catPositioning()
    {
        //SoundManager.instance.PlayToolComesSound ();
        MoveAction(cat, catEndPoint, 0.4f, iTween.EaseType.linear, iTween.LoopType.none);
        Invoke("sideTablePositioning", 0.5f);
    }

    private void sideTablePositioning()
    {
        SoundManager.instance.PlayCatSound();
        MoveAction(sideTable, sideTableEndPoint, 0.5f, iTween.EaseType.easeInBounce, iTween.LoopType.none);
        Invoke("ratTrapComesInn", 0.7f);
    }

    private void ratTrapComesInn()
    {
        SoundManager.instance.PlayToolComesSound();
        ratTrap.SetActive(true);
        MoveAction(ratTrap, ratTrapEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
        Invoke("makingRatListenerOn", 0.5f);
    }

    private void makingRatListenerOn()
    {
        trapArrow.SetActive(true);
        ratTrap.GetComponent<ApplicatorListener>().enabled = true;
    }


    private void trapShaking()
    {
        SoundManager.instance.PlayScannerSound();
        SoundManager.instance.PlayCatCryingSound();
        rat.SetActive(false);
        ratTrap.GetComponent<Image>().sprite = trapedRat;
        ShakeAction(ratTrap);
        Invoke("stopTrapShaking", 3.0f);
    }

    private void stopTrapShaking()
    {

        iTween.Pause(ratTrap);
        MoveAction(ratTrap, ratTrapEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
        Invoke("ratTrapGoesout", 0.5f);
        Debug.Log("Level1 Done");
    }

    private void ratTrapGoesout()
    {
        catEyeClose.SetActive(true);
        catFace.sprite = faceExpressions[0];
        MoveAction(ratTrap, ratTrapStartPoint, 0.5f, iTween.EaseType.easeInBack, iTween.LoopType.none);
        Invoke("trashComesInn", 0.5f);
    }

    private void trashComesInn()
    {
        SoundManager.instance.PlayToolComesSound();
        trash.SetActive(true);
        MoveAction(trash, trashEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
        Invoke("makingTrashListenerOn", 0.5f);
    }

    private void makingTrashListenerOn()
    {
        trash.GetComponent<BoxCollider2D>().enabled = true;
        leafHand.SetActive(true);
        MoveAction(leafHand, leafHandEndPoint, 1.0f, iTween.EaseType.linear, iTween.LoopType.loop);
    }

    private void trashGoesout()
    {
        MoveAction(trash, trashStartPoint, 0.5f, iTween.EaseType.easeInBack, iTween.LoopType.none);
        Invoke("tweekerComesInn", 0.5f);
    }

    private void rashRemoverComesInn()
    {
        rashRemover.SetActive(true);
        MoveAction(rashRemover, rashRemoverEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
        Invoke("rashBrushListenerOn", 0.5f);
    }

    private void rashBrushListenerOn()
    {
        rashArrow1.SetActive(true);
        rashArrow2.SetActive(true);
        rashArrow3.SetActive(true);
        rashArrow4.SetActive(true);

        rashBrush.GetComponent<ApplicatorListener>().enabled = true;
    }

    private void rashBrushPositioning()
    {
        rashBrush.GetComponent<ApplicatorListener>().enabled = false;
        MoveAction(rashBrush, rashBrushEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
        Invoke("rashRemoverGoesout", 0.7f);

    }

    private void rashRemoverGoesout()
    {
        MoveAction(rashRemover, rashRemoverStartPoint, 0.5f, iTween.EaseType.easeInBack, iTween.LoopType.none);
        Invoke("rashCreamComesInn", 0.6f);
    }

    private void checkRashes()
    {
        if (rashCounter >= 4)
        {
            rashBrushPositioning();
        }
    }

    private void rashCreamComesInn()
    {
        SoundManager.instance.PlayToolComesSound();
        rashCream.SetActive(true);
        MoveAction(rashCream, rashCreamEndPoint, 1.0f, iTween.EaseType.linear, iTween.LoopType.none);
        Invoke("rashCreamListenerOn", 1.0f);
    }

    private void rashCreamListenerOn()
    {
        rashCream1StartPoint.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        rashgermcream1.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        rashCream.GetComponent<ApplicatorListener>().enabled = true;
    }

    private void rashCreamGoesout()
    {
        ParticleManger.instance.showStarParticle(rashgerm1.gameObject);
        ParticleManger.instance.showStarParticle(rashgerm2.gameObject);
        ParticleManger.instance.showStarParticle(rashgerm3.gameObject);
        MoveAction(rashCream, rashCreamStartPoint, 0.5f, iTween.EaseType.easeInBack, iTween.LoopType.none);
        Invoke("bandageComesInn", 0.6f);
    }

    private void bandageComesInn()
    {
        SoundManager.instance.PlayToolComesSound();
        bandage.gameObject.SetActive(true);
        MoveAction(bandage.gameObject, bandageEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
        Invoke("bandageListenerOn", 0.5f);
    }

    private void bandageListenerOn()
    {
        bandageHand.SetActive(true);
        MoveAction(bandageHand.gameObject, bandageHandEndPoint, 1.0f, iTween.EaseType.linear, iTween.LoopType.loop);
        bandage.gameObject.GetComponent<ApplicatorListener>().enabled = true;
    }

    private void meatPlateComesInn()
    {
        SoundManager.instance.PlayToolComesSound();
        meatPlate.SetActive(true);
        MoveAction(meatPlate, plateEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
        Invoke("meatPlateListenerOn", 0.5f);
    }

    private void meatPlateListenerOn()
    {
        meat.GetComponent<ApplicatorListener>().enabled = true;
    }



    private void tweekerComesInn()
    {
        SoundManager.instance.PlayToolComesSound();
        TweekerTool.SetActive(true);
        MoveAction(TweekerTool, tweekerEndPoint, 0.5f, iTween.EaseType.easeInBounce, iTween.LoopType.none);
        Invoke("tweekerListenerOn", 0.6f);
    }

    private void tweekerListenerOn()
    {
        //		tweekerHand.SetActive (true);
        //		MoveAction (tweekerHand, tweekerHandEndPoint, 1.0f, iTween.EaseType.easeInBounce, iTween.LoopType.loop);
        TweekerTool.GetComponent<ApplicatorListener>().enabled = true;
    }

    private void tweekerGoesout()
    {
        MoveAction(TweekerTool, tweekerStartPoint, 0.5f, iTween.EaseType.easeInBack, iTween.LoopType.none);

    }

    private void meatEating1()
    {
        StartCoroutine(FillOutAction(meat.GetComponent<Image>()));
        SoundManager.instance.PlayBiteSound();
        MoveAction(meat, meatEatingPoint1, 0.5f, iTween.EaseType.easeInBack, iTween.LoopType.none);
        Invoke("meatEating2", 0.7f);
    }

    private void meatEating2()
    {
        StartCoroutine(FillOutAction(meat.GetComponent<Image>()));
        SoundManager.instance.PlayBiteSound();
        MoveAction(meat, meatEatingPoint2, 0.5f, iTween.EaseType.easeInBack, iTween.LoopType.none);
        Invoke("meatEating3", 0.7f);
    }

    private void meatEating3()
    {
        StartCoroutine(FillOutAction(meat.GetComponent<Image>()));
        MoveAction(meat, meatEatingPoint3, 0.5f, iTween.EaseType.easeInBack, iTween.LoopType.none);
        Invoke("meatPlateGoesout", 0.7f);
    }

    private void meatPlateGoesout()
    {
        MoveAction(meatPlate, plateStartPoint, 0.5f, iTween.EaseType.easeInBack, iTween.LoopType.none);
        Invoke("toolsCompleted", 0.6f);
    }

    private void toolsCompleted()
    {
        ParticleManger.instance.showPointingParticle(catFace.gameObject);
        if (PlayerPrefs.GetInt("RandomMode") == 0)
        {
            PlayerPrefs.SetInt("AnimalSelected", 1);
        }
        Invoke("popupActive", 2.0f);
        Debug.Log("Level5 Done");
    }

    private void popupActive()
    {
        lastpopup.SetActive(true);
        ScaleAction(lastpopup.transform.GetChild(0).gameObject, 1.0f, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
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
        MoveAction(treamentText, treatmentTextEndPoint, 0.3f, iTween.EaseType.linear, iTween.LoopType.none);

        Invoke("nextButtonActive", 0.7f);
        Invoke("treamentParticleAppear", 0.3f);
    }

    private void treamentParticleAppear()
    {
        ParticleManger.instance.showStarParticle(treamentText);

    }

    private void nextButtonActive()
    {
        nextButton.SetActive(true);
    }

    private void popUpClose()
    {
        StartCoroutine(FadeOutAction(popupImage));
        ScaleAction(originalPopup, 0.0f, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
        Invoke("taleBandgeGoesOut", 1.2f);

    }

    private void taleBandgeGoesOut()
    {
        swelled.SetActive(false);
        SoundManager.instance.PlayToolComesSound();
        MoveAction(taleBandage, taleBandageOutPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
        Invoke("blackScreenActive", 1.5f);
    }

    private void blackScreenActive()
    {
        blackScreen.gameObject.SetActive(true);
        newBg.SetActive(true);
        StartCoroutine(FadeOutAction(blackScreen));
        Invoke("newCatComes", 1.5f);
    }

    private void newCatComes()
    {
        blackScreen.gameObject.SetActive(false);
        newCat.SetActive(true);
        MoveAction(newCat, newCatEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
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
        if (PlayerPrefs.GetInt("RandomMode") == 0)
        {
            PlayerPrefs.SetInt("AnimalSelected", 1);
        }
        lastNextButton.SetActive(true);

    }
    #endregion

    #region CallBack Methods
    public void OnCollisionWithRatTrap()
    {
        catEyeClose.SetActive(false);
        catFace.sprite = faceExpressions[1];
        trapArrow.SetActive(false);
        MoveAction(ratTrap, ratTrapPointingPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
        Invoke("trapShaking", 0.5f);
    }

    public void OnCollisionWithTrash()
    {
        leafHand.SetActive(false);
        if (GameManager.instance.currentItem == "Leaf1")
        {
            MoveAction(leaf1, leafUpperEndPoint, 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
            StartCoroutine(leafGoesInn(leaf1));
        }
        else if (GameManager.instance.currentItem == "Leaf2")
        {
            MoveAction(leaf2, leafUpperEndPoint, 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
            StartCoroutine(leafGoesInn(leaf2));
        }
        else if (GameManager.instance.currentItem == "Leaf3")
        {
            MoveAction(leaf3, leafUpperEndPoint, 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
            StartCoroutine(leafGoesInn(leaf3));
        }
        else if (GameManager.instance.currentItem == "Leaf4")
        {
            MoveAction(leaf4, leafUpperEndPoint, 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
            StartCoroutine(leafGoesInn(leaf4));
        }
        else if (GameManager.instance.currentItem == "Leaf5")
        {
            MoveAction(leaf5, leafUpperEndPoint, 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
            StartCoroutine(leafGoesInn(leaf5));
        }
        else if (GameManager.instance.currentItem == "Leaf6")
        {
            MoveAction(leaf6, leafUpperEndPoint, 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
            StartCoroutine(leafGoesInn(leaf6));
        }
        else if (GameManager.instance.currentItem == "Leaf7")
        {
            MoveAction(leaf7, leafUpperEndPoint, 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
            StartCoroutine(leafGoesInn(leaf7));
        }
        else if (GameManager.instance.currentItem == "Leaf8")
        {
            MoveAction(leaf8, leafUpperEndPoint, 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
            StartCoroutine(leafGoesInn(leaf8));
        }
    }

    public void rashBrushBeginDrag()
    {
        rashArrow1.GetComponent<Image>().enabled = true;
        rashArrow2.GetComponent<Image>().enabled = true;
        rashArrow3.GetComponent<Image>().enabled = true;
        rashArrow4.GetComponent<Image>().enabled = true;

    }

    public void rashBrushEndDrag()
    {
        rashArrow1.GetComponent<Image>().enabled = false;
        rashArrow2.GetComponent<Image>().enabled = false;
        rashArrow3.GetComponent<Image>().enabled = false;
        rashArrow4.GetComponent<Image>().enabled = false;

    }

    public void onCollisionWithRashBrush()
    {
        if (GameManager.instance.currentItem == "Rash1")
        {
            colorDecreases(rash1, 0.2f);
            SoundManager.instance.PlayRubbingLoop(true);
            if (rash1.color.a <= 0f)
            {
                SoundManager.instance.PlayRubbingLoop(false);
                rash1.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                rash1.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                ParticleManger.instance.showStarParticle(rash1.gameObject);
                rashCounter++;
                print("valie is" + rashCounter);
                checkRashes();

            }
        }

        else if (GameManager.instance.currentItem == "Rash2")
        {
            SoundManager.instance.PlayRubbingLoop(true);
            colorDecreases(rash2, 0.2f);
            if (rash2.color.a <= 0f)
            {
                rash2.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                SoundManager.instance.PlayRubbingLoop(false);
                rashArrow2.SetActive(false);
                rash2.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                ParticleManger.instance.showStarParticle(rash2.gameObject);
                rashCounter++;
                print("valie is" + rashCounter);
                checkRashes();

            }
        }

        else if (GameManager.instance.currentItem == "Rash3")
        {
            SoundManager.instance.PlayRubbingLoop(true);
            colorDecreases(rash3, 0.2f);
            if (rash3.color.a <= 0f)
            {
                SoundManager.instance.PlayRubbingLoop(false);
                rash3.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                rash3.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                ParticleManger.instance.showStarParticle(rash3.gameObject);
                rashCounter++;
                print("valie is" + rashCounter);
                checkRashes();

            }
        }

        else if (GameManager.instance.currentItem == "Rash4")
        {
            SoundManager.instance.PlayRubbingLoop(true);
            colorDecreases(rash4, 0.2f);
            if (rash4.color.a <= 0f)
            {
                SoundManager.instance.PlayRubbingLoop(false);
                rash4.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                rash4.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                rashCounter++;
                ParticleManger.instance.showStarParticle(rash4.gameObject);
                print("valie is" + rashCounter);
                checkRashes();

            }
        }

    }

    public void OnCollisionWithRashCream()
    {
        if (GameManager.instance.currentItem == "rashgerm1")
        {
            rashgermcream1.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            MoveAction(rashCream, rashCream1StartPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
            Invoke("rashCreamMovement1", 0.5f);
        }

        else if (GameManager.instance.currentItem == "rashgerm2")
        {
            rashgermcream2.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            MoveAction(rashCream, rashCream2StartPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
            Invoke("rashCreamMovement2", 0.5f);
        }

        else if (GameManager.instance.currentItem == "rashgerm3")
        {
            rashgermcream3.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            MoveAction(rashCream, rashCream3StartPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
            Invoke("rashCreamMovement3", 0.5f);
        }
    }

    private void rashCreamMovement1()
    {
        MoveAction(rashCream, rashCream1EndPoint, 1.0f, iTween.EaseType.linear, iTween.LoopType.none);
        StartCoroutine(FillInAction(rashgermcream1));
        Invoke("rashCreamGoesToTable", 1.1f);
    }

    private void rashCreamMovement2()
    {
        MoveAction(rashCream, rashCream2EndPoint, 1.0f, iTween.EaseType.linear, iTween.LoopType.none);
        StartCoroutine(FillInAction(rashgermcream2));
        Invoke("rashCreamGoesToTable", 1.1f);
    }

    private void rashCreamMovement3()
    {
        MoveAction(rashCream, rashCream3EndPoint, 1.3f, iTween.EaseType.linear, iTween.LoopType.none);
        StartCoroutine(FillInAction(rashgermcream3));
        Invoke("rashCreamGoesToTable", 1.3f);
    }


    private void rashCreamGoesToTable()
    {

        rashCream.GetComponent<ApplicatorListener>().enabled = true;
        MoveAction(rashCream, rashCreamEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
        tubeCounter++;
        if (tubeCounter == 1)
        {
            rashCream2StartPoint.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            rashgermcream2.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }

        if (tubeCounter == 2)
        {
            rashCream3StartPoint.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            rashgermcream3.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }

        if (tubeCounter >= 3)
        {
            rashCream.GetComponent<ApplicatorListener>().enabled = false;
            print("there");
            StartCoroutine(FadeOutAction(rashgerm1));
            StartCoroutine(FadeOutAction(rashgerm2));
            StartCoroutine(FadeOutAction(rashgerm3));
            StartCoroutine(FadeOutAction(rashgermcream1));
            StartCoroutine(FadeOutAction(rashgermcream2));
            StartCoroutine(FadeOutAction(rashgermcream3));
            Invoke("rashCreamGoesout", 1.5f);
        }

    }

    public void onCollisionWithBandage()
    {
        bandageHand.SetActive(false);
        Invoke("meatPlateComesInn", 0.5f);
        Debug.Log("Level4 Done");
    }

    public void OnCollisionWithMeat()
    {
        SoundManager.instance.PlayBiteSound();
        meat.GetComponent<ApplicatorListener>().enabled = false;
        MoveAction(meat, meatEatingPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
        Invoke("meatEating1", 0.7f);
    }

    private void meatStartEating()
    {
        StartCoroutine(FillOutAction(meat.gameObject.GetComponent<Image>()));
    }

    public void tweekerBeginDrag()
    {
        TweekerTool.GetComponent<Image>().sprite = TweekerSprite[0];
    }


    //Tweeker End Drag
    public void tweekerEndDrag()
    {
        catEyeClose.SetActive(true);
        catFace.sprite = faceExpressions[0];
        MoveAction(Tray, TrayStartPosition, 1.0f, iTween.EaseType.linear, iTween.LoopType.none);
        TweekerTool.GetComponent<Image>().sprite = TweekerSprite[0];
        TweekerTool.GetComponent<Image>().SetNativeSize();
        woodWoundsColliderOn();
        CheckingTrayCollision();
    }

    public void tweekerCollision()
    {
        tweekerHand.SetActive(false);
        catEyeClose.SetActive(false);
        catFace.sprite = faceExpressions[1];

        TweekerTool.GetComponent<Image>().sprite = TweekerSprite[1];
        //Move Tray in scene
        MoveAction(Tray, TrayEndPosition, 1.0f, iTween.EaseType.linear, iTween.LoopType.none);
        //TweekerTool.GetComponent<ApplicatorListener> ().enabled = false;
        if (GameManager.instance.currentItem == "Thorn1")
        {
            SoundManager.instance.PlayCatCryingSound();
            GameManager.instance.woundTag = "Thorn1";
            WoodWounds[0].SetActive(false);
            WoodWounds[1].GetComponent<Collider2D>().enabled = false;
            WoodWounds[2].GetComponent<Collider2D>().enabled = false;
            WoodWounds[3].GetComponent<Collider2D>().enabled = false;
            WoodWounds[4].GetComponent<Collider2D>().enabled = false;
        }
        else if (GameManager.instance.currentItem == "Thorn2")
        {
            SoundManager.instance.PlayCatCryingSound();
            //SoundManager.instance.playTweekerCollision ();
            GameManager.instance.woundTag = "Thorn2";
            WoodWounds[1].SetActive(false);
            WoodWounds[0].GetComponent<Collider2D>().enabled = false;
            WoodWounds[2].GetComponent<Collider2D>().enabled = false;
            WoodWounds[3].GetComponent<Collider2D>().enabled = false;
            WoodWounds[4].GetComponent<Collider2D>().enabled = false;
        }
        else if (GameManager.instance.currentItem == "Thorn3")
        {
            SoundManager.instance.PlayCatCryingSound();
            //SoundManager.instance.playTweekerCollision ();
            GameManager.instance.woundTag = "Thorn3";
            WoodWounds[2].SetActive(false);
            WoodWounds[0].GetComponent<Collider2D>().enabled = false;
            WoodWounds[1].GetComponent<Collider2D>().enabled = false;
            WoodWounds[3].GetComponent<Collider2D>().enabled = false;
            WoodWounds[4].GetComponent<Collider2D>().enabled = false;
        }
        else if (GameManager.instance.currentItem == "Thorn4")
        {
            SoundManager.instance.PlayCatCryingSound();
            //SoundManager.instance.playTweekerCollision ();
            GameManager.instance.woundTag = "Thorn4";
            WoodWounds[3].SetActive(false);
            WoodWounds[0].GetComponent<Collider2D>().enabled = false;
            WoodWounds[2].GetComponent<Collider2D>().enabled = false;
            WoodWounds[1].GetComponent<Collider2D>().enabled = false;
            WoodWounds[4].GetComponent<Collider2D>().enabled = false;
        }
        else if (GameManager.instance.currentItem == "Thorn5")
        {
            SoundManager.instance.PlayCatCryingSound();
            //SoundManager.instance.playTweekerCollision ();
            GameManager.instance.woundTag = "Thorn5";
            WoodWounds[4].SetActive(false);
            WoodWounds[0].GetComponent<Collider2D>().enabled = false;
            WoodWounds[2].GetComponent<Collider2D>().enabled = false;
            WoodWounds[3].GetComponent<Collider2D>().enabled = false;
            WoodWounds[1].GetComponent<Collider2D>().enabled = false;
        }
    }

    private void woodWoundsColliderOn()
    {
        WoodWounds[0].GetComponent<Collider2D>().enabled = true;
        WoodWounds[1].GetComponent<Collider2D>().enabled = true;
        WoodWounds[2].GetComponent<Collider2D>().enabled = true;
        WoodWounds[3].GetComponent<Collider2D>().enabled = true;
        WoodWounds[4].GetComponent<Collider2D>().enabled = true;
    }

    private void CheckingTrayCollision()
    {
        if (GameManager.instance.currentItem == "tray" && TrayCounter <= 5)
        {
            SoundManager.instance.PlayCollisionSound();
            TrayWoods[TrayCounter].SetActive(true);
            TrayCounter++;
            print("traycounter is " + TrayCounter);

            //for particles production
            //			print("name of tag is"+GameManager.instance.woundTag);
            //			if(GameManager.instance.currenatTag == Utils.CHECKUP_MODE_TRAY &&  GameManager.instance.woundTag==Utils.CHECKUP_MODE_WOODWOUND1 )
            //			{
            //				SoundManager.instance.playParticleSound ();
            //				ParticleManager.instance.particlePositioning (WoodWounds [0]);
            //
            //			}
            //			if(GameManager.instance.currenatTag ==Utils.CHECKUP_MODE_TRAY &&  GameManager.instance.woundTag==Utils.CHECKUP_MODE_WOODWOUND2)
            //			{
            //				SoundManager.instance.playParticleSound ();
            //				ParticleManager.instance.particlePositioning (WoodWounds [1]);
            //
            //			}
            //			if(GameManager.instance.currenatTag ==Utils.CHECKUP_MODE_TRAY &&  GameManager.instance.woundTag==Utils.CHECKUP_MODE_WOODWOUND3)
            //			{
            //				SoundManager.instance.playParticleSound ();
            //				ParticleManager.instance.particlePositioning (WoodWounds [2]);
            //
            //			}
            //			GameManager.instance.currenatTag="none";
        }
        else if (GameManager.instance.currentItem == "Thorn1")
        {
            WoodWounds[0].SetActive(true);

        }
        else if (GameManager.instance.currentItem == "Thorn2")
        {
            WoodWounds[1].SetActive(true);

        }
        else if (GameManager.instance.currentItem == "Thorn3")
        {
            WoodWounds[2].SetActive(true);

        }
        else if (GameManager.instance.currentItem == "Thorn4")
        {
            WoodWounds[3].SetActive(true);

        }
        else if (GameManager.instance.currentItem == "Thorn5")
        {
            WoodWounds[4].SetActive(true);

        }


        //		else
        //		{
        //
        //		}
        if (TrayCounter == 5)
        {
            TweekerTool.GetComponent<ApplicatorListener>().enabled = false;
            StartCoroutine(FadeOutAction(thornRash1));
            StartCoroutine(FadeOutAction(thornRash2));
            StartCoroutine(FadeOutAction(thornRash3));
            StartCoroutine(FadeOutAction(thornRash4));
            StartCoroutine(FadeOutAction(thornRash5));
            ParticleManger.instance.showPointingParticle(catFace.gameObject);
            MoveAction(TweekerTool, tweekerStartPoint, 0.5f, iTween.EaseType.easeInBack, iTween.LoopType.none);
            Invoke("rashRemoverComesInn", 1.0f);

            Debug.Log("Level3 Done");

        }

    }

    IEnumerator leafGoesInn(GameObject obj)
    {
        yield return new WaitForSeconds(0.3f);
        obj.transform.SetParent(trash.transform);
        obj.transform.SetAsFirstSibling();
        SoundManager.instance.PlayTrashSound();
        MoveAction(obj, leafLowerPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
        leafCount++;
        print("value is" + leafCount);
        if (leafCount >= 8)
        {
            Invoke("trashGoesout", 0.5f);
            Debug.Log("Level2 Done");
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

    IEnumerator FillInAction(Image img)
    {
        if (img.fillAmount < 1.0f)
        {
            img.fillAmount = img.fillAmount + 0.2f;
            yield return new WaitForSeconds(0.2f);
            StartCoroutine(FillInAction(img));
        }
        else if (img.fillAmount >= 1.0f)
        {
            StopCoroutine(FillInAction(img));
        }
    }

    IEnumerator FillOutAction(Image img)
    {
        if (img.fillAmount > 0.0f)
        {
            img.fillAmount = img.fillAmount - 0.2f;
            yield return new WaitForSeconds(0.2f);
            StartCoroutine(FillOutAction(img));
        }
        else if (img.fillAmount <= 0.0f)
        {
            StopCoroutine(FillOutAction(img));

        }
    }

    public void onClickNextButton()
    {
        SoundManager.instance.PlayButtonClickSound();
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
        NavigationManager.instance.ReplaceScene(GameScene.MAINMENU);
        //if (PlayerPrefs.GetInt("RandomMode") == 1)
        //{
        //    NavigationManager.instance.ReplaceScene(GameScene.MAINMENU);
        //}
        //else if(PlayerPrefs.GetInt("PetCareMode") == 1)
        //{
        //    NavigationManager.instance.ReplaceScene(GameScene.MAINMENU);
        //}
        //else
        //{
        //    NavigationManager.instance.ReplaceScene(GameScene.RECEPTIONView);
        //}

    }
    #endregion
}
