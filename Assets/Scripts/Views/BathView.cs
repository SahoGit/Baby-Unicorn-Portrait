using System;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BathView : MonoBehaviour {
    #region Variables, Constants & Initializers
    // Use this for initialization

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

	public Image BodyNew;
	public Image FaceNew;
	public Image EarNew;
	public Image leftLegNew;
	public Image RightLegNew;
	public Image LeftArmNew;
	public Image RightArmNew;
	public Image EyesNew;

	public Image LoadingBody;
	public Image LoadingFace;
	public Image LoadingEar;
	public Image LoadingleftLeg;
	public Image LoadingRightLeg;
	public Image LoadingLeftArm;
	public Image LoadingRightArm;
	public Image LoadingEyes;

	private int teethCounter = 0;
	private int dirtCounter = 0;
	private int soapBubbleCounter = 0;
    public GameObject sideTable;
    public RectTransform sideTableEndPoint;
	public GameObject mirror;
	public RectTransform mirrorStartPoint, mirrorEndPoint, mirrorMouthPoint;
	public GameObject mirrorHand, tubBubbles;
	public RectTransform mirrorHandEndPoint;
	public GameObject teethPopup;
	public Image teethUpperDirt, teethLowerDirt;
	public GameObject dirtPicker;
	public RectTransform DirtPicketEndPoint, DirtPickerStartPoint; 
	public GameObject toothBrush;
	public RectTransform toothBrushStartPoint, toothBrushEndPoint;
	public GameObject paste;
	public GameObject bubbleParent;
	public GameObject lotionBottle, lotion;
	public RectTransform lotionBottleStartPoint, lotionBottleEndPoint, lotionBottleAbovePoint;
    public GameObject lotionHand;
    public RectTransform lotionHandEndPoint;
    public GameObject towelHand;
    public RectTransform towelHandEndPoint;
    public GameObject sponge;
	public RectTransform spongeStartPoint, spongeEndPoint;
	public GameObject soapBubble;
	public float [] bubblesSize;
	public GameObject soapBubbleParent;
	public Image dirt;
	public GameObject shower;
	public RectTransform showerEndPoint, showerStartPoint;
	public GameObject towel;
	public RectTransform towelEndPoint, towelStartPoint;
	public Image waterVapors;
	public GameObject unicornFace;
	public GameObject tub;
	public RectTransform tubEndPoint;
	public GameObject nextButton;
	public GameObject lastpopup, treamentText;
	public RectTransform treatmentTextEndPoint;
	public Image popupImage;
	public GameObject originalPopup;
	public GameObject levelEndParticles;
	public Image blackScreen;
	public GameObject newBg;
	public GameObject newUnicorn;
	public RectTransform newUnicornEndPoint;
	public GameObject frame, cameraButton, lastNextButton;
	public GameObject washroomBubble;
	public GameObject washroomBubbleStartPoint1, washroomBubbleStartPoint2, washroomBubbleStartPoint3;
	public RectTransform  washroomBubbleEndPoint1, washroomBubbleEndPoint2, washroomBubbleEndPoint3;
	public float [] washroomBubbleSize;
    public float[] timer;

    public Sprite[] taskMessageSprite;
    public Image taskMessageImage;
    public GameObject taskePanel;

    public GameObject levelCompletePanel;
    public GameObject objectivePanel;

    public GameObject washroomBubbleParent;
    public GameObject levelComplete;

    public int levelCount;

	private int unicornId;

    public GameObject bgSound;

	public GameObject spongeFilled;

	public Image spongeFilledImage;

    public Text objectiveText;

    public Text animalName;

    #endregion

    #region Lifecycle Methods

    // Use this for initialization
    void Start () {
		if (PlayerPrefs.GetInt("CareerMode") == 1)
		{
			if (PlayerPrefs.GetInt("PlayingLevel") == 2)
			{
				objectiveText.text = PlayerPrefs.GetString("SelectedPetName") + " is dirty, shampoo her hair";
			}
			else if (PlayerPrefs.GetInt("PlayingLevel") == 3)
			{
				objectiveText.text = PlayerPrefs.GetString("SelectedPetName") + " is dirty, make her clean";
			}
			else if (PlayerPrefs.GetInt("PlayingLevel") == 4)
			{
				objectiveText.text = PlayerPrefs.GetString("SelectedPetName") + " is dirty, She need a shower";
			}
			else if (PlayerPrefs.GetInt("PlayingLevel") == 5)
			{
				objectiveText.text = PlayerPrefs.GetString("SelectedPetName") + " is wet, Please dry her with towel";
			}
		}
		if (PlayerPrefs.GetInt("PetCareMode") == 1)
		{
			objectiveText.text = "Clean " + PlayerPrefs.GetString("SelectedPetName") + ", because he is very dirty";
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
        PlayerPrefs.SetInt("ComingFromSplash", 0);
		setUpLoadingUniCorn();

    }

    public void nextLevel()
	{
		PlayerPrefs.SetInt("levelPlayedId", PlayerPrefs.GetInt("levelPlayedId") + 1);
		SoundManager.instance.PlayButtonClickSound();
		if (PlayerPrefs.GetInt("PlayingLevel") == 2)
		{
			PlayerPrefs.SetInt("PlayingLevel", 3);
			NavigationManager.instance.ReplaceScene(GameScene.BATHVIEW);
		}
		else if (PlayerPrefs.GetInt("PlayingLevel") == 3)
		{
			PlayerPrefs.SetInt("PlayingLevel", 4);
			NavigationManager.instance.ReplaceScene(GameScene.BATHVIEW);
		}
		else if (PlayerPrefs.GetInt("PlayingLevel") == 4)
		{
			PlayerPrefs.SetInt("PlayingLevel", 5);
			NavigationManager.instance.ReplaceScene(GameScene.BATHVIEW);
		}
		else if (PlayerPrefs.GetInt("PlayingLevel") == 5)
		{
			PlayerPrefs.SetInt("PlayingLevel", 6);
			NavigationManager.instance.ReplaceScene(GameScene.DRESSUPVIEW);
		}
	}

    public void RestartLevel()
    {
        SoundManager.instance.PlayButtonClickSound();
        NavigationManager.instance.ReplaceScene(GameScene.BATHVIEW);
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

    #endregion

    #region Utility Methods

    private void SetViewContents()
    {
        GameManager.instance.currentScene = GameUtils.BATH_VIEW_SCENE;
		//mirrorComesInn();
		
		instantiateBathroomBubbles ();
		//bubblesActive ();
		//dirtPickeComesInn ();
		//lotionBottleComesInn();
		//spongeComesInn ();

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

	void setUpNewUniCorn()
    {
        BodyNew.GetComponent<Image>().sprite = BodyList[unicornId];
        FaceNew.GetComponent<Image>().sprite = FaceList[unicornId];
        EarNew.GetComponent<Image>().sprite = EarList[unicornId];
        leftLegNew.GetComponent<Image>().sprite = leftLegList[unicornId];
        RightLegNew.GetComponent<Image>().sprite = RightLegList[unicornId];
        LeftArmNew.GetComponent<Image>().sprite = LeftArmList[unicornId];
        RightArmNew.GetComponent<Image>().sprite = RightArmList[unicornId];
        EyesNew.GetComponent<Image>().sprite = EyesList[unicornId];
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

	private void ShakeAction(GameObject obj) {
		Hashtable tweenParams = new Hashtable();
		tweenParams.Add ("amount", new Vector3 (0.05f, 0.05f, 0.05f));
		tweenParams.Add ("time", 1.0f);
		tweenParams.Add ("easetype", iTween.EaseType.easeInCubic);
		tweenParams.Add ("looptype", iTween.LoopType.pingPong);
		iTween.ShakePosition(obj, tweenParams);
	}

	private void instantiateBathroomBubbles(){
		GameObject bubbleClone1 = Instantiate(washroomBubble, new Vector3(-434.0f, -690f, 0f), Quaternion.identity) as GameObject;
		ScaleAction(bubbleClone1, washroomBubbleSize[UnityEngine.Random.Range(0, 2)], 0.2f, iTween.EaseType.linear, iTween.LoopType.none);
		bubbleClone1.transform.SetParent(washroomBubbleParent.transform, false);
		MoveAction(bubbleClone1, washroomBubbleEndPoint1, timer[UnityEngine.Random.Range(0, 2)], iTween.EaseType.linear, iTween.LoopType.none);

		GameObject bubbleClone2 = Instantiate(washroomBubble, new Vector3(15.0f, -690f, 0f), Quaternion.identity) as GameObject;
		ScaleAction(bubbleClone2, washroomBubbleSize[UnityEngine.Random.Range(0, 2)], 0.2f, iTween.EaseType.linear, iTween.LoopType.none);
		bubbleClone2.transform.SetParent(washroomBubbleParent.transform, false);
		MoveAction(bubbleClone2, washroomBubbleEndPoint2, timer[UnityEngine.Random.Range(0, 2)], iTween.EaseType.linear, iTween.LoopType.none);

		GameObject bubbleClone3 = Instantiate(washroomBubble,new Vector3(430.0f, -690f, 0f), Quaternion.identity) as GameObject;
		ScaleAction(bubbleClone3, washroomBubbleSize[UnityEngine.Random.Range(0, 2)], 0.2f, iTween.EaseType.linear, iTween.LoopType.none);
		bubbleClone3.transform.SetParent(washroomBubbleParent.transform, false);
		MoveAction(bubbleClone3, washroomBubbleEndPoint3, timer[UnityEngine.Random.Range(0, 2)], iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("instantiateAgain", 5.0f);
	}

	private void instantiateAgain(){
		instantiateBathroomBubbles ();
	}

	private void colorIncreases(Image img, float val){
		if (img.color.a < 1) {
			img.color = new Vector4 (img.color.r,img.color.g,img.color.b, img.color.a + val);
		}
	}

	private void colorDecreases(Image img , float value){
		if (img.color.a > 0) {
			img.color = new Vector4 (img.color.r,img.color.g,img.color.b, img.color.a - value);
		}
	}

	private void bubblesActive(){
		tubBubbles.GetComponent<Image> ().enabled = true;
		Invoke ("bubblesInActive", 1.5f);
	}

	private void bubblesInActive(){
		tubBubbles.GetComponent<Image> ().enabled = false;
		Invoke ("bubblesActive", 1.5f);
    }

    private void sideTablePositioning()
    {
        SoundManager.instance.PlayToolComesSound();
        MoveAction(sideTable, sideTableEndPoint, 0.5f, iTween.EaseType.easeInBounce, iTween.LoopType.none);
        Invoke("lotionBottleComesInn", 0.7f);
		//Invoke("mirrorComesInn", 0.7f);

	}

	private void sideTablewithTowel()
	{
		SoundManager.instance.PlayToolComesSound();
		MoveAction(sideTable, sideTableEndPoint, 0.5f, iTween.EaseType.easeInBounce, iTween.LoopType.none);
		Invoke("towelComesInn", 0.7f);

	}

	private void sideTablewithSponge()
	{
		SoundManager.instance.PlayToolComesSound();
		MoveAction(sideTable, sideTableEndPoint, 0.5f, iTween.EaseType.easeInBounce, iTween.LoopType.none);
		ScaleAction(lotion, 0.8f, 1.0f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke("spongeComesInn", 0.7f);

	}

	private void sideTablewithShower()
	{
		SoundManager.instance.PlayToolComesSound();
		MoveAction(sideTable, sideTableEndPoint, 0.5f, iTween.EaseType.easeInBounce, iTween.LoopType.none);



		Vector3 pos = GameManager.instance.contact.point;
		Vector3 positionlocal = transform.InverseTransformPoint(pos);
        for (int i = 0; i < 250; i++)
		{
			soapBubbleCounter++;
			GameObject bubbleClone1 = Instantiate(soapBubble, new Vector3(positionlocal.x - Random.Range(-80.0f,100.0f), positionlocal.y + Random.Range(0.0f, 225.0f), positionlocal.z), Quaternion.identity) as GameObject;
			ScaleAction(bubbleClone1, bubblesSize[UnityEngine.Random.Range(0, 1)], 0.1f, iTween.EaseType.linear, iTween.LoopType.none);
			bubbleClone1.transform.SetParent(soapBubbleParent.transform, false);
		}
		
		//ScaleAction(lotion, 0.8f, 1.0f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke("showerComesInn", 0.7f);

	}

	private void mirrorComesInn(){
		SoundManager.instance.PlayToolComesSound ();
		mirror.SetActive (true);
		MoveAction (mirror, mirrorEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("mirrorListenerOn", 0.5f);
	}

	private void mirrorListenerOn(){
		mirrorHand.SetActive (true);
		MoveAction (mirrorHand, mirrorHandEndPoint, 1.0f, iTween.EaseType.linear, iTween.LoopType.loop);
		mirror.GetComponent<ApplicatorListener> ().enabled = true;
	}

	private void mirrorGoesOut(){
		ParticleManger.instance.showPointingParticle (unicornFace.gameObject);
		MoveAction (mirror, mirrorStartPoint, 0.5f, iTween.EaseType.easeInBack, iTween.LoopType.none);
		Invoke("lotionBottleComesInn", 1.0f);
        Debug.Log("Level1 Done");
    }

	private void dirtPickeComesInn(){
		SoundManager.instance.PlayToolComesSound ();
		dirtPicker.SetActive (true);
		MoveAction (dirtPicker, DirtPicketEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("dirtPickerListenerOn", 0.5f);
	}

	private void dirtPickerListenerOn(){
		dirtPicker.GetComponent<ApplicatorListener> ().enabled = true;
	}

	private void dirtPickerGoesOut(){
		MoveAction (dirtPicker, DirtPickerStartPoint, 0.5f, iTween.EaseType.easeInBack, iTween.LoopType.none);
		Invoke ("toothBrushComesInn", 0.7f);
	}

	private void teethPopupOpen(){
		teethPopup.SetActive (true);
		Invoke ("dirtPickeComesInn", 0.5f);
	}

	private void toothBrushComesInn(){
		SoundManager.instance.PlayToolComesSound ();
		toothBrush.SetActive (true);
		MoveAction (toothBrush, toothBrushEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("toothBrushListenerOn", 0.5f);
	}

	private void toothBrushListenerOn(){
		toothBrush.GetComponent<ApplicatorListener> ().enabled = true;
	}

	private void toothBrushGoesOut(){
		MoveAction (toothBrush, toothBrushStartPoint, 0.5f, iTween.EaseType.easeInBack, iTween.LoopType.none);
	}

	private void lotionBottleComesInn(){
		SoundManager.instance.PlayToolComesSound ();
		lotionBottle.SetActive (true);
		MoveAction (lotionBottle, lotionBottleEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("lotionBottleListenerOn", 0.7f);
	}

	private void lotionBottleListenerOn(){
        if (PlayerPrefs.GetInt("isLotionHand") == 0)
		{
			lotionHand.SetActive(true);
			MoveAction(lotionHand, lotionHandEndPoint, 1.0f, iTween.EaseType.linear, iTween.LoopType.loop);
			PlayerPrefs.SetInt("isLotionHand", 1);
		}
		lotionBottle.GetComponent<ApplicatorListener> ().enabled = true;
	}

	private void bottleRotate(){
		RotateAction (lotionBottle, 45.0f, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("shampooActive", 0.5f);
	}

	private void shampooActive(){
		SoundManager.instance.PlayShampooSound ();
		ScaleAction (lotion, 0.8f, 1.0f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("bottleAgainRotate", 1.0f);
	}

	private void bottleAgainRotate(){
		RotateAction (lotionBottle, 0.0f, 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("bottleGoesEndPoint", 0.4f);
	}

	private void bottleGoesEndPoint(){
		MoveAction (lotionBottle, lotionBottleEndPoint, 0.4f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("lotionBottleGoesOut", 0.5f);
	}

	private void lotionBottleGoesOut(){
		MoveAction (lotionBottle, lotionBottleStartPoint, 0.5f, iTween.EaseType.easeInBack, iTween.LoopType.none);
        if (PlayerPrefs.GetInt("CareerMode") == 1)
        {
            if (PlayerPrefs.GetInt("PlayingLevel") == 2)
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
            Invoke("spongeComesInn", 0.5f);
        }
	}

	private void spongeComesInn(){
		SoundManager.instance.PlayToolComesSound ();
		sponge.SetActive (true);
		MoveAction (sponge, spongeEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("spongeListenerOn", 0.5f);
	}

	private void spongeListenerOn(){
		sponge.GetComponent<ApplicatorListener> ().enabled = true;
	}

	private void spongeGoesOut(){

        spongeFilled.SetActive(false);
        MoveAction (sponge, spongeStartPoint, 0.5f, iTween.EaseType.easeInBack, iTween.LoopType.none);
		if (PlayerPrefs.GetInt("CareerMode") == 1)
		{
			if (PlayerPrefs.GetInt("PlayingLevel") == 3)
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
			Invoke("showerComesInn", 0.5f);
		}
	}

	private void showerComesInn(){
		SoundManager.instance.PlayToolComesSound ();
		shower.SetActive (true);
		MoveAction (shower, showerEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("showerListenerOn", 0.5f);
	}

	private void showerListenerOn(){
		shower.GetComponent<ApplicatorListener> ().enabled = true;
	}

	private void showerGoesOut(){
		ParticleManger.instance.showPointingParticle (unicornFace.gameObject);
		MoveAction (shower, showerStartPoint, 0.5f, iTween.EaseType.easeInBack, iTween.LoopType.none);
		if (PlayerPrefs.GetInt("CareerMode") == 1)
		{
			if (PlayerPrefs.GetInt("PlayingLevel") == 4)
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
			Invoke("tubGoesOutside", 0.5f);
		}
	}

	private void tubGoesOutside(){
		MoveAction (tub, tubEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		MoveAction (tubBubbles.gameObject, tubEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("towelComesInn", 0.5f);
        Debug.Log("Level2 Done");
        SoundManager.instance.PlayGoodJobSound();
        taskMessageImage.sprite = taskMessageSprite[Random.Range(0,1)];
        taskePanel.SetActive (true);
		Invoke("taskPanelOff", 3.0f);
    }

	void taskPanelOff()
    {
        taskePanel.SetActive(false);
        if (PlayerPrefs.GetInt("CareerMode") == 1)
        {
            if (PlayerPrefs.GetInt("PlayingLevel") == 5)
            {
                levelCompletePanel.SetActive(true);
                PrefsManager.instance.SetPlayerScore(1000);
                if (PlayerPrefs.GetInt("LevelPlayed") == PlayerPrefs.GetInt("levelPlayedId"))
                {
                    PlayerPrefs.SetInt("LevelPlayed", PlayerPrefs.GetInt("LevelPlayed") + 1);
                }
            }
        }
        //SoundManager.instance.PlaySparkleSound();
    }

	private void towelComesInn(){
		towel.SetActive (true);
		MoveAction (towel, towelEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("towelListenerOn", 0.5f);
	}

	private void towelListenerOn()
	{
		if (PlayerPrefs.GetInt("isTowelHand") == 0)
		{
			towelHand.SetActive(true);
			MoveAction(towelHand, towelHandEndPoint, 1.0f, iTween.EaseType.linear, iTween.LoopType.loop);
			PlayerPrefs.SetInt("isTowelHand", 1);
		}
        towel.GetComponent<ApplicatorListener> ().enabled = true;
	}

	private void towelGoesOut(){
		MoveAction (towel, towelStartPoint, 0.5f, iTween.EaseType.easeInBack, iTween.LoopType.none);
		Invoke ("toolsCompleted", 0.5f);
	}

	private void toolsCompleted(){
		ParticleManger.instance.showPointingParticle (unicornFace.gameObject);
		//Invoke("popupActive", 2.0f);
        Debug.Log("Level3 Done");

        if (PlayerPrefs.GetInt("CareerMode") == 1)
        {
            if (PlayerPrefs.GetInt("PlayingLevel") == 5)
            {
                levelCompletePanel.SetActive(true);
                PrefsManager.instance.SetPlayerScore(1000);
                if (PlayerPrefs.GetInt("LevelPlayed") == PlayerPrefs.GetInt("levelPlayedId"))
                {
                    PlayerPrefs.SetInt("LevelPlayed", PlayerPrefs.GetInt("LevelPlayed") + 1);
                }
            }
        }
		else
        {
            Invoke("popupActive", 2.0f);
        }
    }

	private void popupActive()
    {
        animalName.text = PlayerPrefs.GetString("SelectedPetName");
        lastpopup.SetActive (true);
		ScaleAction (lastpopup.transform.GetChild(0).gameObject, 0.8f, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		SoundManager.instance.PlayPopupCloseSound ();
		Invoke ("treatmentTextAppear", 1.2f);
	}

	private void treatmentTextAppear(){
		SoundManager.instance.PlayGirlSound ();
		ScaleAction (treamentText, 1.0f, 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("treatMentStamp", 0.3f);
	}

	private void treatMentStamp(){
		SoundManager.instance.playstampSound ();
		MoveAction (treamentText, treatmentTextEndPoint, 0.3f, iTween.EaseType.easeInBounce, iTween.LoopType.none);
		Invoke ("nextButtonActive", 0.7f);
		Invoke ("treamentParticleAppear", 0.4f);
	}

	private void treamentParticleAppear(){
		ParticleManger.instance.showStarParticle (treamentText);
      
    }

	private void nextButtonActive(){
		nextButton.SetActive (true);
	}

	private void popUpClose(){
		StartCoroutine (FadeOutAction(popupImage));
		ScaleAction (originalPopup, 0.0f, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("blackScreenActive", 1.5f);

	}

	private void blackScreenActive(){
		blackScreen.gameObject.SetActive (true);
		newBg.SetActive (true);
		StartCoroutine (FadeOutAction(blackScreen));
		Invoke ("newUnicornComes", 2.0f);
	}

	private void newUnicornComes(){
		blackScreen.gameObject.SetActive (false);
		newUnicorn.SetActive (true);
		MoveAction (newUnicorn, newUnicornEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("cameraButtonActive", 0.7f);
	}

	private void cameraButtonActive(){
		cameraButton.SetActive (true);
	}

	private void photoFrameComes(){
		frame.SetActive (true);
		ScaleAction (frame, 1.0f, 0.3f, iTween.EaseType.easeInBounce, iTween.LoopType.none);
		Invoke ("lastNextButtonActive", 0.7f);
	}

	private void lastNextButtonActive(){
		SoundManager.instance.playLevelCompletedSound ();
		levelEndParticles.SetActive (true);
        if (PlayerPrefs.GetInt("PetCareMode") == 1)
        {
            if (PlayerPrefs.GetInt("AnimalPlayed") == 3)
            {
                PlayerPrefs.SetInt("AnimalPlayed", 4);
            }
        }
		lastNextButton.SetActive (true);
      
    }
	#endregion

	#region CallBack Methods

	public void OnCollisionOfMirror(){
		mirrorHand.SetActive (false);
		SoundManager.instance.PlayCollisionSound ();
		MoveAction (mirror, mirrorMouthPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke("teethPopupOpen", 1.0f);
	}

	public void OnCollisuonDirtPicker(){
		teethCounter++;
		SoundManager.instance.PlayCollisionSound ();
		if (teethCounter >= 4) {
			dirtPicker.GetComponent<ApplicatorListener> ().enabled = false;
			MoveAction (dirtPicker, DirtPicketEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
			Invoke ("dirtPickerGoesOut", 0.5f);
		}
	}

	public void onCollisionWithToothBrush(){
		
		if(GameManager.instance.currentItem == "TeethUpperDirt"){
			SoundManager.instance.PlayBrushingLoop (true);
		colorDecreases(teethUpperDirt, 0.015f);
		Vector3 pos = GameManager.instance.contact.point; 
		Vector3 positionlocal = transform.InverseTransformPoint(pos); 
		GameObject bubbleClone1 = Instantiate(soapBubble,new Vector3( positionlocal.x + 100.0f, positionlocal.y,  positionlocal.z) , Quaternion.identity) as GameObject;
		ScaleAction(bubbleClone1, bubblesSize[UnityEngine.Random.Range(0, 2)], 0.1f, iTween.EaseType.linear, iTween.LoopType.none);
		bubbleClone1.transform.SetParent(bubbleParent.transform, false); 
			if(teethUpperDirt.color.a <= 0f){
				teethUpperDirt.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
				dirtCounter++;
				print ("value of dirt counter is"+dirtCounter);
				checkDirtCounter ();
			}
		}

		else if(GameManager.instance.currentItem == "TeethLowerDirt"){
			SoundManager.instance.PlayBrushingLoop (true);
			colorDecreases(teethLowerDirt, 0.015f);
			Vector3 pos = GameManager.instance.contact.point; 
			Vector3 positionlocal = transform.InverseTransformPoint(pos); 
			GameObject bubbleClone1 = Instantiate(soapBubble,new Vector3( positionlocal.x + 100.0f, positionlocal.y,  positionlocal.z) , Quaternion.identity) as GameObject;
			ScaleAction(bubbleClone1, bubblesSize[UnityEngine.Random.Range(0, 2)], 0.1f, iTween.EaseType.linear, iTween.LoopType.none);
			bubbleClone1.transform.SetParent(bubbleParent.transform, false); 
			if(teethLowerDirt.color.a <= 0f){
				teethLowerDirt.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
				dirtCounter++;
				print ("value of dirt counter is"+dirtCounter);
				checkDirtCounter ();
			}

		}

	}

	private void checkDirtCounter(){
		if (dirtCounter == 2) {
			SoundManager.instance.PlayBrushingLoop (false);
			toothBrush.GetComponent<ApplicatorListener> ().enabled = false;
			toothBrush.GetComponent<BoxCollider2D> ().enabled = false;
			MoveAction (toothBrush, toothBrushEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
			Invoke ("toothBrushGoesOut", 0.6f);
			Invoke ("bubblesOff", 2.0f);

		}
	}

	private void bubblesOff(){
		bubbleParent.SetActive (false);
		ParticleManger.instance.showPointingParticle (bubbleParent.gameObject);
		Invoke ("popupClose", 2.0f);
	}

	private void popupClose(){
		SoundManager.instance.PlayPopupCloseSound ();
		teethPopup.SetActive (false);

		MoveAction (mirror, mirrorEndPoint, 0.4f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("mirrorGoesOut", 0.5f);
	}


	public void OnCollisionWithLotionBottle(){
		lotionHand.SetActive (false);
		MoveAction (lotionBottle, lotionBottleAbovePoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("bottleRotate", 0.5f);
	}

	public void onCollisionWithSponge(){
        spongeFilled.SetActive (true);

        SoundManager.instance.PlaySoapLoop (true);
		colorDecreases (dirt, 0.007f);
		colorDecreases (lotion.GetComponent<Image>(), 0.007f);

		Vector3 pos = GameManager.instance.contact.point; 
		Vector3 positionlocal = transform.InverseTransformPoint(pos);
		GameObject bubbleClone1 = Instantiate(soapBubble,new Vector3( positionlocal.x - 0.0f, positionlocal.y + 0.0f,  positionlocal.z) , Quaternion.identity) as GameObject;
		ScaleAction(bubbleClone1, bubblesSize[UnityEngine.Random.Range(0, 2)], 0.1f, iTween.EaseType.linear, iTween.LoopType.none);
		bubbleClone1.transform.SetParent(soapBubbleParent.transform, false); 
		soapBubbleCounter++;
		if (soapBubbleCounter >= 250) {
            SoundManager.instance.PlaySoapLoop (false);
			sponge.GetComponent<ApplicatorListener> ().enabled = false;
			MoveAction (sponge, spongeEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
			Invoke ("spongeGoesOut", 0.6f);
		} else
		{
            spongeFilledImage.fillAmount = spongeFilledImage.fillAmount + 0.004f;
        }
	}

	public void OnCollisionWithShower(){
		soapBubbleCounter--;
		waterVapors.gameObject.SetActive(true);
		dirt.gameObject.SetActive(false);
		if (soapBubbleCounter <= 10) {
			SoundManager.instance.PlayShowerLoop (false);
			soapBubbleParent.SetActive (false);
			shower.transform.GetChild (0).gameObject.SetActive (false);
			shower.GetComponent<ApplicatorListener> ().enabled = false;
			MoveAction (shower, showerEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
			Invoke ("showerGoesOut", 0.6f);
		}
	}

	public void towelBeginDrag(){
		towel.GetComponent<Image> ().enabled = false;
		towel.transform.GetChild (0).gameObject.SetActive (true);
	}

	public void towelEndDrag(){
		towel.GetComponent<Image> ().enabled = true;
		towel.transform.GetChild (0).gameObject.SetActive (false);
	}

	public void OnCollisionWithTowel()
    {
        towelHand.SetActive(false);
        colorDecreases (waterVapors, 0.1f);
		SoundManager.instance.PlayRubbingLoop (true);
		if (waterVapors.color.a <= 0) {
			SoundManager.instance.PlayRubbingLoop (false);
			waterVapors.gameObject.SetActive (false);
			towel.GetComponent<ApplicatorListener> ().enabled = false;
			towel.GetComponent<Image> ().enabled = true;
			towel.transform.GetChild (0).gameObject.SetActive (false);
			MoveAction (towel, towelEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
			Invoke ("towelGoesOut", 0.6f);
		}

		}

	IEnumerator FadeOutAction (Image img)
	{
		if (img.color.a >0) {
			img.color = new Vector4 (img.color.r,img.color.g,img.color.b, img.color.a - 0.03f);
			yield return new WaitForSeconds (0.05f);
			StartCoroutine (FadeOutAction (img));
		}  else if (img.color.a < 0) {
			StopCoroutine (FadeOutAction (img));
		}
	}

	public void onClickNextButton()
	{
		//PlayerPrefs.SetInt("NoLoadingScreen", 1);
		SoundManager.instance.PlayButtonClickSound ();
		nextButton.SetActive (false);
        NavigationManager.instance.ReplaceScene(GameScene.DRESSUPVIEW);
        //popUpClose ();


    }

	public void OnClickCameraButton(){
		SoundManager.instance.playcameraSound ();
		cameraButton.SetActive (false);
		photoFrameComes ();
	}

	public void OnClickLastNext(){
		SoundManager.instance.PlayButtonClickSound ();
        NavigationManager.instance.ReplaceScene(GameScene.DRESSUPVIEW);
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

    public void homeBtn()
    {
        NavigationManager.instance.ReplaceScene(GameScene.MAINMENU);
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
        SoundManager.instance.PlayButtonClickSound();
        objectivePanel.SetActive (true);
        Loading.SetActive(false);
    }

	public void levelStart()
    {
		Debug.Log(PlayerPrefs.GetInt("PlayingLevel"));
        if (PlayerPrefs.GetInt("CareerMode") == 1)
		{
			if (PlayerPrefs.GetInt("PlayingLevel") == 2)
			{
				sideTablePositioning();
			}
			else if (PlayerPrefs.GetInt("PlayingLevel") == 3)
			{
				sideTablewithSponge();
				//sideTablePositioning();
			}
			else if (PlayerPrefs.GetInt("PlayingLevel") == 4)
			{
				sideTablewithShower();
				//sideTablePositioning();
			}
			else if (PlayerPrefs.GetInt("PlayingLevel") == 5)
            {
                sideTablewithTowel();
                dirt.GetComponent<Image>().enabled = false;
                waterVapors.gameObject.SetActive(true);

            }
        }
        else
        {
            sideTablePositioning();
        }
        SoundManager.instance.PlayButtonClickSound();
        objectivePanel.SetActive(false);
        setUpUniCorn();
        setUpNewUniCorn();
        Invoke("SetViewContents", 0.1f);
    }

    void AdCalled()
    {
		AdsManager.Instance.ShowInterstitial("Level Complete");
	}


    #endregion

}
