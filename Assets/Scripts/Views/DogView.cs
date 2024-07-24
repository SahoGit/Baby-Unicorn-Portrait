using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DogView : MonoBehaviour {

	#region Variables, Constants & Initializers
	// Use this for initialization\
	private int itemsPick = 0;
	private bool injectionFlag = false;
	public GameObject bottomTable;
	public GameObject sideTable;
	public GameObject dog;
	public RectTransform bottomTableEndPoint, sideTableEndPoint, dogEndPoint;
	public GameObject scannerMachine, scanner, scanImage, blankImage, warningImage;
	public RectTransform scannerMachineEndPoint,scannerMachineStartPoint, scannerStartPoint, scannerEndPoint, blankImageStartPoint, blankImageMovingPoint ;
	public GameObject picker;
	public Sprite openPicker, closedPicker;
	public RectTransform pickerStartPoint, pickerEndPoint, packetPickPoint, fishPickPoint, coinPickPoint, bonePickPoint, fruitPickPoint, candyPickPoint, pickerTrashPoint;
	public GameObject trash;
	public RectTransform trashUpperPoint, trashLowerPoint, basketStartPoint, basketEndPoint;
	public RectTransform trashStartPoint, trashEndPoint;
	public GameObject leafHand;
	public RectTransform leafHandEndPoint;
	public GameObject injection, injectionUsed;
	public RectTransform injectionHitPoint, injectionEndPoint, injectionStartPoint;
	public GameObject injectionHandle;
	public RectTransform injectionHandleEndPoint;
	public GameObject injectionHand;
	public RectTransform injectionHandEndPoint;
	public Image surringeImage;
	public GameObject medicineTray, medicine;
	public RectTransform medicineTrayEndPoint, medicineTrayStartPoint, medicineEndPoint, medicineMouthPoint;
	public GameObject bandageBox, bandage1, bandage2;
	public RectTransform  bandage1EndPoint, bandage2EndPoint, bandageBoxStartPoint, bandageBoxEndPoint, bandageOutsidePoint, bandageOutsidePoint2;
	public GameObject cut1, cut2;
	public GameObject meatPlate, meat;
	public RectTransform plateStartPoint, plateEndPoint, meatEatingPoint, meatEatingPoint1, meatEatingPoint2, meatEatingPoint3, meatEatingPoint4;
	public GameObject stomachPopup;
	public GameObject packet, bone, coin, candy, fruit, fish;
	public GameObject dogFace, dogTale;
	public GameObject nextButton;
	public GameObject dogBody;
	public GameObject lastpopup, treamentText, popupChild;
	public Image popupImage;
	public GameObject originalPopup;
	public RectTransform treatmentTextEndPoint;
	public Image blackScreen;
	public GameObject newBg;
	public GameObject newDog;
	public RectTransform newDogEndPoint;
	public GameObject frame, cameraButton, lastNextButton;
	public GameObject levelEndParticles;
	public Image expressions;
	public Sprite [] faceImages;
	public GameObject eyeClose;
    public GameObject levelComplete;

    public int levelCount;
    #endregion

    #region Lifecycle Methods

    // Use this for initialization
    void Start () {
        PlayerPrefs.SetInt("ComingFromSplash", 0);
        Invoke ("SetViewContents", 0.1f);
		if(PlayerPrefs.GetInt("CareerMode", 1)!=0)
        {
			if (PlayerPrefs.GetInt("LevelPlayID") >= 9)
			{
				cut1.SetActive(false);
				cut2.SetActive(false);
			}
		}
       

    }

	//// Update is called once per frame
	//void Update () {

	//}

	#endregion

	#region Utility Methods

	private void SetViewContents() {
		GameManager.instance.currentScene = GameUtils.DOG_VIEW_SCENE;
		bottomTablePositioning ();
		animalFaceMovement ();
		//scannerMachineComesInn();
		//injectionComesInn();
		//medicineTrayComesInn();
		//bandageBoxComesInn ();
		//meatPlateComesInn();
		//stomachPopupActive();
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

	private void RotateActionFull(GameObject obj,float roatationamount,float t,iTween.EaseType actionType,iTween.LoopType loopType){
		Hashtable tweenParams = new Hashtable ();
		tweenParams.Add ("z", roatationamount);
		tweenParams.Add ("time", t);
		tweenParams.Add ("easetype", actionType);
		tweenParams.Add ("looptype", loopType);
		iTween.RotateBy (obj, tweenParams);
	}

	private void ShakeAction(GameObject obj) {
		Hashtable tweenParams = new Hashtable();
		tweenParams.Add ("amount", new Vector3 (0.05f, 0.05f, 0.05f));
		tweenParams.Add ("time", 1.0f);
		tweenParams.Add ("easetype", iTween.EaseType.easeInCubic);
		tweenParams.Add ("looptype", iTween.LoopType.pingPong);
		iTween.ShakePosition(obj, tweenParams);
	}

	private void animalFaceMovement(){
		RotateAction (dogFace, -5.0f, 4.0f, iTween.EaseType.linear, iTween.LoopType.pingPong);
		RotateAction (dogTale, -10.0f, 2.0f, iTween.EaseType.linear, iTween.LoopType.pingPong);

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


	private void bottomTablePositioning(){
		SoundManager.instance.PlayToolComesSound ();
		MoveAction (bottomTable, bottomTableEndPoint, 0.5f, iTween.EaseType.easeInBounce, iTween.LoopType.none);
		Invoke ("dogPositioning", 0.7f);
	}

	private void dogPositioning(){
		MoveAction (dog, dogEndPoint, 0.4f, iTween.EaseType.easeInBounce, iTween.LoopType.none);
		Invoke ("sideTablePositioning", 0.5f);
	}

	private void sideTablePositioning(){
		SoundManager.instance.PlayDogSound ();
		MoveAction (sideTable, sideTableEndPoint, 0.5f, iTween.EaseType.easeInBounce, iTween.LoopType.none);
        if (PlayerPrefs.GetInt("CareerMode") == 1)
        {
            if (PlayerPrefs.GetInt("LevelPlayID") == 5)
            {
                Invoke("scannerMachineComesInn", 0.7f);
            }
            else if (PlayerPrefs.GetInt("LevelPlayID") == 6)
            {
                Invoke("injectionComesInn", 0.7f);
            }
            else if (PlayerPrefs.GetInt("LevelPlayID") == 7)
            {
                Invoke("medicineTrayComesInn", 0.7f);
            }
            else if (PlayerPrefs.GetInt("LevelPlayID") == 8)
            {
                Invoke("bandageBoxComesInn", 0.7f);
            }
            else if (PlayerPrefs.GetInt("LevelPlayID") == 9)
            {
                Invoke("meatPlateComesInn", 0.7f);
            }
        }

        else
        {
            Invoke("scannerMachineComesInn", 0.7f);
        }

    }

	private void scannerMachineComesInn(){
		SoundManager.instance.PlayToolComesSound ();
		scannerMachine.SetActive (true);
		MoveAction (scannerMachine, scannerMachineEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("makingScannerListenerOn", 0.5f);
	}

	private void makingScannerListenerOn(){
		scanner.GetComponent<ApplicatorListener> ().enabled = true;
	}

	private void scannerWorking(){
		blankImage.SetActive (false);
		scanImage.SetActive (true);
		warningImage.SetActive (true);
		SoundManager.instance.playWarningSound ();
		Invoke ("scanneGoesOut", 2.5f);
	}


	private void scanneGoesOut(){
		expressions.sprite = faceImages [0];
		eyeClose.SetActive (true);
		warningImage.SetActive (false);
		MoveAction (scanner, scannerStartPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("scannerMachineGoesOut", 1.0f);
	}

	private void scannerMachineGoesOut(){
		MoveAction (scannerMachine, scannerMachineStartPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("stomachPopupActive", 0.6f);
	}

	private void injectionComesInn(){
		injection.SetActive (true);
		MoveAction (injection, injectionEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("makingInjectionListenerOn", 0.5f);
	}

	private void makingInjectionListenerOn(){
		injectionHand.SetActive (true);
		MoveAction (injectionHand, injectionHandEndPoint, 1.0f, iTween.EaseType.linear, iTween.LoopType.loop);
		injection.GetComponent<ApplicatorListener> ().enabled = true;

		Invoke("usedInjectionTablePoint", 3f);
	}

	private void injectionGoesout(){
		//RotateActionFull (injectionUsed, 1.0f, 0.5f, iTween.EaseType.linear, iTween.LoopType.pingPong);
		expressions.sprite = faceImages [0];
		eyeClose.SetActive (true);
		ParticleManger.instance.showPointingParticle(injectionHitPoint.gameObject);
		MoveAction (injectionUsed, injectionStartPoint, 0.5f, iTween.EaseType.easeInBack, iTween.LoopType.none);
		Invoke ("medicineTrayComesInn", 0.7f);
        Debug.Log("Level2 Done");
        if (PlayerPrefs.GetInt("CareerMode") == 1)
        {
            levelCompletePanel(6, 14);
        }
    }

	private void medicineTrayComesInn(){
		SoundManager.instance.PlayToolComesSound ();
		medicineTray.SetActive (true);
		MoveAction (medicineTray, medicineTrayEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("makingMedicineListenerOn", 0.5f);
	}

	private void makingMedicineListenerOn(){
		medicine.GetComponent<ApplicatorListener> ().enabled = true;
	}

	private void medicineTrayGoesout(){
		expressions.sprite = faceImages [0];
		eyeClose.SetActive (true);
		ParticleManger.instance.showPointingParticle(dogFace.gameObject);
		MoveAction (medicineTray, medicineTrayStartPoint, 0.5f, iTween.EaseType.easeInBack, iTween.LoopType.none);
		Invoke ("bandageBoxComesInn", 0.7f);
        Debug.Log("Level3 Done");
        if (PlayerPrefs.GetInt("CareerMode") == 1)
        {
            levelCompletePanel(7, 18);
        }
    }

	private void bandageBoxComesInn(){
		SoundManager.instance.PlayToolComesSound ();
		bandageBox.SetActive (true);
		MoveAction (bandageBox, bandageBoxEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("makingBandage1ListenerOn", 0.5f);
	}

	private void makingBandage1ListenerOn(){
		bandage1.GetComponent<ApplicatorListener> ().enabled = true;
	}

	private void bandageBoxGoesout(){
		expressions.sprite = faceImages [0];
		eyeClose.SetActive (true);
		MoveAction (bandageBox, bandageBoxStartPoint, 0.5f, iTween.EaseType.easeInBack, iTween.LoopType.none);
		Invoke ("meatPlateComesInn", 0.7f);
        Debug.Log("Level4 Done");
        if (PlayerPrefs.GetInt("CareerMode") == 1)
        {
            levelCompletePanel(8, 10);
        }
    }

	private void meatPlateComesInn(){
		expressions.sprite = faceImages [0];
		eyeClose.SetActive (true);
		SoundManager.instance.PlayToolComesSound ();
		meatPlate.SetActive (true);
		MoveAction (meatPlate, plateEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("meatPlateListenerOn", 0.5f);
	}

	private void meatPlateListenerOn(){
		meat.GetComponent<ApplicatorListener> ().enabled = true;
	}
		
	private void meatEating1(){
		SoundManager.instance.PlayBiteSound ();
		StartCoroutine (FillOutAction (meat.GetComponent<Image> ()));
		MoveAction (meat, meatEatingPoint1, 0.5f, iTween.EaseType.easeInBack, iTween.LoopType.none);
		Invoke ("meatEating2", 0.5f);
	}

	private void meatEating2(){
		SoundManager.instance.PlayBiteSound ();
		StartCoroutine (FillOutAction (meat.GetComponent<Image> ()));
		MoveAction (meat, meatEatingPoint2, 0.5f, iTween.EaseType.easeInBack, iTween.LoopType.none);
		Invoke ("meatEating3", 0.5f);
	}

	private void meatEating3(){
		StartCoroutine (FillOutAction (meat.GetComponent<Image> ()));
		MoveAction (meat, meatEatingPoint3, 0.5f, iTween.EaseType.easeInBack, iTween.LoopType.none);
		Invoke ("plateGoesOut", 0.6f);
	}

	private void plateGoesOut(){
		//ParticleManger.instance.showPointingParticle(dogFace.gameObject);
		MoveAction (meatPlate, plateStartPoint, 0.5f, iTween.EaseType.easeInBack, iTween.LoopType.none);
		Invoke ("toolsCompleted", 0.5f);
	}

	private void toolsCompleted(){
		ParticleManger.instance.showPointingParticle (dogFace.gameObject);
		//Invoke ("popupActive", 2.0f);
        Debug.Log("Level5 Done");
        if (PlayerPrefs.GetInt("CareerMode") == 1)
        {
            levelCompletePanel(9, 2);
        }
        else
        {
            Invoke("popupActive", 2.0f);
        }
    }

	private void popupActive(){
		lastpopup.SetActive (true);
		ScaleAction (popupChild, 1.0f, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
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
		Invoke ("treamentParticleAppear", 0.3f);
		Invoke ("nextButtonActive", 0.7f);
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
		Invoke ("dogBandgeGoesOut", 0.7f);

	}

	private void dogBandgeGoesOut(){
		SoundManager.instance.PlayShampooSound ();
		MoveAction (bandage1, bandageOutsidePoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		MoveAction (bandage2, bandageOutsidePoint2, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("blackScreenActive", 1.5f);
	}

	private void blackScreenActive(){
		blackScreen.gameObject.SetActive (true);
		newBg.SetActive (true);
		StartCoroutine (FadeOutAction(blackScreen));
		Invoke ("newDogComes", 1.0f);
	}

	private void newDogComes(){
		blackScreen.gameObject.SetActive (false);
		newDog.SetActive (true);
		MoveAction (newDog, newDogEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
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
            if (PlayerPrefs.GetInt("AnimalPlayed") == 1)
            {
                PlayerPrefs.SetInt("AnimalPlayed", 2);
            }
        }
		lastNextButton.SetActive (true);
      

    }

	private void stomachPopupActive(){
		SoundManager.instance.PlayPopupCloseSound ();
		stomachPopup.SetActive (true);
		Invoke ("trashComesInn", 0.5f);

	}

	private void trashComesInn(){
		SoundManager.instance.PlayToolComesSound ();
		trash.SetActive (true);
		MoveAction (trash, trashEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("makingTrashListenerOn", 0.5f);
	}

	private void makingTrashListenerOn(){
		picker.SetActive (true);
		MoveAction (picker, pickerEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		trash.GetComponent<BoxCollider2D> ().enabled = true;
//		leafHand.SetActive (true);
//		MoveAction (leafHand, leafHandEndPoint, 1.0f, iTween.EaseType.linear, iTween.LoopType.loop);
		Invoke ("pickerListenerOn", 0.5f);
	}

	private void pickerListenerOn(){
		picker.GetComponent<ApplicatorListener> ().enabled = true;
	}

	private void trashGoesout(){
		MoveAction (trash, trashStartPoint, 0.5f, iTween.EaseType.easeInBack, iTween.LoopType.none);
	}
	#endregion

	#region CallBack Methods

	public void scannerBeginDrag(){
		expressions.sprite = faceImages [1];
		eyeClose.SetActive (false);
		iTween.Resume (blankImage);
		MoveAction (blankImage, blankImageMovingPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.pingPong);
	}

	public void scannerEndDrag(){
		iTween.Pause (blankImage);
		blankImage.transform.position = blankImageStartPoint.gameObject.transform.position; 
	}

	public void onCollisionWithScanner(){
		MoveAction (scanner, scannerEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		SoundManager.instance.PlayscanningLoop (false);
		SoundManager.instance.PlayBeepSound ();
		Invoke ("scannerWorking", 0.6f);
	}

	public void pickerBeginDrag(){

	}

	public void pickerEndDrag(){
		if (picker.transform.GetChild (0).gameObject.tag == "stomachobjects") {
			Invoke ("pickergoesTrashPoint", 0.3f);

		} else {

			picker.GetComponent<Image> ().sprite = openPicker;
		}
	}

	private void pickergoesTrashPoint(){
		picker.GetComponent<ApplicatorListener> ().enabled = false;
		MoveAction (picker , pickerTrashPoint, 0.5f, iTween.EaseType.linear,iTween.LoopType.none);
		Invoke ("trashGoesTop", 0.5f);

	}

	public void onColisionWithPicker(){
		makingColliderOff ();
        SoundManager.instance.PlayGermSound();
        picker.GetComponent<Image> ().sprite = closedPicker;
		if(GameManager.instance.currentItem == "Coin"){
			MoveAction (coin, coinPickPoint, 0.2f, iTween.EaseType.linear, iTween.LoopType.none);
			coin.transform.SetParent (picker.transform);
			coin.transform.SetAsFirstSibling ();
		}
		else if(GameManager.instance.currentItem == "Packet"){
			MoveAction (packet, packetPickPoint, 0.2f, iTween.EaseType.linear, iTween.LoopType.none);
			packet.transform.SetParent (picker.transform);
			packet.transform.SetAsFirstSibling ();
		}

		else if(GameManager.instance.currentItem == "Bone"){
			MoveAction (bone, bonePickPoint, 0.2f, iTween.EaseType.linear, iTween.LoopType.none);
			bone.transform.SetParent (picker.transform);
			bone.transform.SetAsFirstSibling ();
		}

		else if(GameManager.instance.currentItem == "Candy"){
			MoveAction (candy, candyPickPoint, 0.2f, iTween.EaseType.linear, iTween.LoopType.none);
			candy.transform.SetParent (picker.transform);
			candy.transform.SetAsFirstSibling ();
		}

		else if(GameManager.instance.currentItem == "Fruit"){
			MoveAction (fruit, fruitPickPoint, 0.2f, iTween.EaseType.linear, iTween.LoopType.none);
			fruit.transform.SetParent (picker.transform);
			fruit.transform.SetAsFirstSibling ();
		}

		else if(GameManager.instance.currentItem == "Fish"){
			MoveAction (fish, fishPickPoint, 0.2f, iTween.EaseType.linear, iTween.LoopType.none);
			fish.transform.SetParent (picker.transform);
			fish.transform.SetAsFirstSibling ();
		}

		else if(GameManager.instance.currentItem == "trash"){
			picker.GetComponent<ApplicatorListener> ().enabled = false;
			MoveAction (picker , pickerTrashPoint, 0.5f, iTween.EaseType.linear,iTween.LoopType.none);
			Invoke ("trashGoesTop", 0.5f);

		}

	}

	private void makingColliderOff(){
		coin.GetComponent<BoxCollider2D> ().enabled = false;
		fish.GetComponent<BoxCollider2D> ().enabled = false;
		fruit.GetComponent<BoxCollider2D> ().enabled = false;
		candy.GetComponent<BoxCollider2D> ().enabled = false;
		packet.GetComponent<BoxCollider2D> ().enabled = false;
		bone.GetComponent<BoxCollider2D> ().enabled = false;
	}

	private void makingColliderOn(){
		coin.GetComponent<BoxCollider2D> ().enabled = true;
		fish.GetComponent<BoxCollider2D> ().enabled = true;
		fruit.GetComponent<BoxCollider2D> ().enabled = true;
		candy.GetComponent<BoxCollider2D> ().enabled = true;
		packet.GetComponent<BoxCollider2D> ().enabled = true;
		bone.GetComponent<BoxCollider2D> ().enabled = true;
	}
		

	private void trashGoesTop(){
		GameObject temp =picker.transform.GetChild (0).gameObject;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           
		temp.transform.SetParent (trash.transform);
		picker.GetComponent<Image> ().sprite = openPicker;
		MoveAction (temp , trashUpperPoint, 0.5f, iTween.EaseType.linear,iTween.LoopType.none);
		StartCoroutine (trashGoesInn(temp));

	}

	IEnumerator trashGoesInn(GameObject obj){
		yield return new WaitForSeconds (0.3f);
		obj.transform.SetParent (trash.transform);
		obj.transform.SetAsFirstSibling ();
		MoveAction (obj, trashLowerPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none );
		Invoke ("pickerAgaiActive", 0.5f);
	}

	private void pickerAgaiActive(){
		picker.GetComponent<ApplicatorListener> ().enabled = true;
		makingColliderOn ();
        SoundManager.instance.PlayTrashSound();
        ParticleManger.instance.showTrashParticle (trashUpperPoint.gameObject);
		MoveAction (picker, pickerEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		itemsPick++;
		if (itemsPick >= 6) {
			MoveAction (trash, basketStartPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
			Invoke ("popupClose", 1.0f);
        }
	}

	private void popupClose(){
		stomachPopup.SetActive (false);
		ParticleManger.instance.showPointingParticle (dogBody.gameObject);
		Invoke ("injectionComesInn", 1.5f);
		Debug.Log("Level1 Done");
        if (PlayerPrefs.GetInt("CareerMode") == 1)
        {
            levelCompletePanel(5, 6);
        }
    }

	public void onCollisionWithInjection(){
		expressions.sprite = faceImages [1];
		eyeClose.SetActive (false);
		injectionHand.SetActive (false);
		SoundManager.instance.PlayDogSound ();
		MoveAction (injection, injectionHitPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("injectionRotate", 0.5f);
	}

	private void injectionRotate(){
		RotateAction (injection, 60.0f, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("usedInjectionActive", 0.5f);
	}

	private void usedInjectionActive(){
		injectionUsed.SetActive (true);
		injection.SetActive (false);
		injectionFlag = true;

	}

	public void OnDragSurringe(){
		if (injectionFlag) {
			SoundManager.instance.playInjectionSound ();
			MoveAction (injectionHandle, injectionHandleEndPoint, 1.0f, iTween.EaseType.linear, iTween.LoopType.none);
			StartCoroutine(FillOutAction (surringeImage));
			injectionFlag = false;
			Invoke ("usedInjectionTablePoint", 1.1f);
		}
	}

	private void usedInjectionTablePoint(){
		//MoveAction (injectionUsed, injectionEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		//Invoke("", 0.6f);
		injectionGoesout ();
	}

	public void onCollisionOfMedicine(){
		expressions.sprite = faceImages [1];
		eyeClose.SetActive (false);
		MoveAction (medicine, medicineMouthPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("scaleOutMedicine", 0.5f);
	}

	private void scaleOutMedicine(){
		SoundManager.instance.playmedicineSound ();
		ScaleAction (medicine, 0.0f, 1.0f,iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("medicineTrayGoesout", 1.0f);
	}

	private GameObject plaster;
	private int plasterCounter = 0;
	public void onCollisionWithPaster1(){
		expressions.sprite = faceImages [1];
		eyeClose.SetActive (false);
		SoundManager.instance.PlayCollisionSound ();
		if (GameManager.instance.currentItem == "Cut1") {
			bandage1.transform.SetParent (dogBody.transform);
			MoveAction (bandage1, bandage1EndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
			plaster = bandage1;
			Invoke ("bandageGoesOut", 0.5f);
		}
		else if(GameManager.instance.currentItem == "Cut2"){
			SoundManager.instance.PlayCollisionSound ();
			bandage1.transform.SetParent (dogBody.transform);
			MoveAction (bandage1, bandage2EndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
			plaster = bandage1;
			Invoke ("bandageGoesOut", 01.5f);
		}

	}

	public void onCollisionWithPaster2(){
		if (GameManager.instance.currentItem == "Cut1") {
			SoundManager.instance.PlayCollisionSound ();
			bandage2.transform.SetParent (dogBody.transform);
			MoveAction (bandage2, bandage1EndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
			plaster = bandage2;
			Invoke ("bandageGoesOut", 0.5f);
		}
		else if(GameManager.instance.currentItem == "Cut2"){
			SoundManager.instance.PlayCollisionSound ();
			bandage2.transform.SetParent (dogBody.transform);
			MoveAction (bandage2, bandage2EndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
			plaster = bandage2;
			Invoke ("bandageGoesOut", 0.5f);
		}
	}

	private void bandageGoesOut(){
		if (GameManager.instance.currentItem == "Cut1") {
			cut1.SetActive (false);
		}
		else if(GameManager.instance.currentItem == "Cut2"){
			cut2.SetActive (false);
		}
		plasterCounter++;

		Invoke ("checkPlasterCounter", 0.5f);
	}

	private void checkPlasterCounter(){
		if(plasterCounter == 1){
			bandage2.SetActive (true);
		}

		if(plasterCounter == 2){
			Invoke ("bandageBoxGoesout", 0.5f);
		}

	}

	public void OnCollisionWithMeat(){
		meat.GetComponent<ApplicatorListener> ().enabled = false;
		MoveAction (meat, meatEatingPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("meatEating1", 0.7f);
	}

//	private void meatStartEating(){
//		StartCoroutine (FillOutAction (meat.gameObject.GetComponent<Image>()));
//	}


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

	IEnumerator FillInAction (Image img){
		if (img.fillAmount < 1.0f) {
			img.fillAmount = img.fillAmount + 0.2f;
			yield return new WaitForSeconds (0.2f);
			StartCoroutine (FillInAction (img));
		}  else if (img.fillAmount >= 1.0f) {
			StopCoroutine (FillInAction (img));
		}
	}

	IEnumerator FillOutAction (Image img){
		if (img.fillAmount > 0.0f) {
			yield return new WaitForSeconds (0.5f);
			img.fillAmount = img.fillAmount - 0.35f;
		}
	}

	public void onClickNextButton(){
		SoundManager.instance.PlayButtonClickSound ();
		nextButton.SetActive (false);
		popUpClose ();


	}

	public void OnClickCameraButton(){
		SoundManager.instance.playcameraSound ();
		cameraButton.SetActive (false);
		photoFrameComes ();
	}

	public void OnClickLastNext(){
		SoundManager.instance.PlayButtonClickSound ();
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

    public void homeBtn()
    {
        NavigationManager.instance.ReplaceScene(GameScene.MAINMENU);
    }

    public void nextBtn()
    {
        if (levelCount == 9)
        {
            PlayerPrefs.SetInt("LevelPlayID", 14);
            NavigationManager.instance.ReplaceScene(GameScene.BATHVIEW);
        }
        if (levelCount == 8)
        {
            PlayerPrefs.SetInt("LevelPlayID", 13);
            NavigationManager.instance.ReplaceScene(GameScene.BATHVIEW);
        }
        if (levelCount == 7)
        {
            PlayerPrefs.SetInt("LevelPlayID", 2);
            NavigationManager.instance.ReplaceScene(GameScene.BATHVIEW);
        }
        if (levelCount == 6)
        {
            PlayerPrefs.SetInt("LevelPlayID", 11);
            NavigationManager.instance.ReplaceScene(GameScene.BATHVIEW);
        }
        if (levelCount == 5)
        {
            PlayerPrefs.SetInt("LevelPlayID", 10);
            NavigationManager.instance.ReplaceScene(GameScene.BATHVIEW);
        }
        //if (levelCount == 9)
        //{
        //    PlayerPrefs.SetInt("LevelPlayID", 10);
        //    NavigationManager.instance.ReplaceScene(GameScene.BUNNYVIEW);
        //}
        levelComplete.SetActive(false);
    }

    void levelCompletePanel(int levelId, int levelPlayingID)
    {
        int levelPlayID = levelPlayingID - 1;
        Debug.Log(PlayerPrefs.GetInt("LevelPlayed"));
        if (PlayerPrefs.GetInt("CareerMode") == 1)
        {
            ParticleManger.instance.showPointingParticle(dogFace.gameObject);
            if (PlayerPrefs.GetInt("LevelPlayed") == levelPlayID)
            {
                PlayerPrefs.SetInt("LevelPlayed", levelPlayID + 1);

            }
        }
        levelCount = levelId;
        levelComplete.SetActive(true);
    }
    #endregion
}
