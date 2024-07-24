using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BunnyView : MonoBehaviour {
	#region Variables, Constants & Initializers
	// Use this for initialization\
	private int myCounter = 1;
	private int eyecounter = 0;
	private int pimpleCounter = 0;
	private int eatingCounter = 0;
	private bool injectionFlag = false;
	public GameObject bottomTable;
	public GameObject sideTable;
	public GameObject bunny;
	public RectTransform bottomTableEndPoint, sideTableEndPoint, bunnyEndPoint;
	public GameObject eyeDropper, rightEyeDrop, leftEyeDrop;
	public RectTransform eyeDropperEndPoint, eyeDropperStartPoint, leftEyePoint, rightEyePoint;
	public Image redLeftEyeImage, redRightEyeImage;
	public GameObject eyeHand;
	public RectTransform eyeHandEndPoint;
	public GameObject injection, injectionUsed;
	public RectTransform injectionHitPoint, injectionEndPoint, injectionStartPoint;
	public GameObject injectionHandle; 
	public RectTransform injectionHandleEndPoint;
	public GameObject injectionHand;
	public RectTransform injectionHandEndPoint;
	public Image surringeImage;
	public GameObject mirror;
	public RectTransform mirrorStartPoint,mirrorEndPoint, mirrorHitPoint;
	public GameObject swabBottle, brush;
	public RectTransform swabBottleEndPoint, swabBottleStartPoint, brushStartPoint;
	public Image pimple1, pimple2, pimple3, pimple4;
	public GameObject plate, spoon;
	public Sprite [] spoonSprites;
	public RectTransform plateEndPoint, plateStartPoint, spoonEndPoint, spoonMouthPoint;

	private int counter = 0;
	private int killingCounter=0;
	private int insect1,insect2,insect3,insect4,insect5=0;
	public GameObject earGerm;
	public RectTransform earGermEndPoint, earGermStartPoint;
	public GameObject [] germs;
	public GameObject germsPopup;
	public GameObject [] insects;
	public GameObject [] insectPositions;
	public GameObject [] germsButton;

	public GameObject bunnyFace;
	public GameObject eyeClose;
	public GameObject nextButton;
	public GameObject lastpopup, treamentText;
	public RectTransform treatmentTextEndPoint;
	public GameObject mouth;
	public Image popupImage;
	public GameObject originalPopup;

	public Image blackScreen;
	public GameObject newBg;
	public GameObject newBunny;
	public RectTransform newBunnyEndPoint;
	public GameObject frame, cameraButton, lastNextButton;
	public GameObject levelEndParticles;
	public Image expressions;
	public Sprite [] faceImages;
	public GameObject rashArrow1, rashArrow2, rashArrow3, rashArrow4;
    public GameObject levelComplete;

    public int levelCount;

    #endregion

    #region Lifecycle Methods

    // Use this for initialization
    void Start () {
        PlayerPrefs.SetInt("ComingFromSplash", 0);
        Invoke ("SetViewContents", 0.1f);
        Debug.Log(PlayerPrefs.GetInt("LevelPlayID"));
        if (PlayerPrefs.GetInt("LevelPlayID") >= 11)
        {
            redLeftEyeImage.enabled = false;
            redRightEyeImage.enabled = false;
        }
        if (PlayerPrefs.GetInt("LevelPlayID") >= 13)
        {
			earGerm.SetActive(false);
        }
        if (PlayerPrefs.GetInt("LevelPlayID") >= 14)
        {
            pimple1.enabled = false;
            pimple2.enabled = false;
            pimple3.enabled = false;
            pimple4.enabled = false;
        }
    }

	#endregion

	#region Utility Methods

	private void SetViewContents() {
		GameManager.instance.currentScene = GameUtils.BUNNY_VIEW_SCENE;
		bottomTablePositioning ();
		animalFaceMovement ();

		//eyeDropperComesInn ();
		//injectionComesInn();
		//mirrorComesInn();;
		//BottleComesInn();
		//openGermsPopUp();
		//plateComesInn();
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

	private void animalFaceMovement(){
		RotateAction (bunnyFace, 4.0f, 4.0f, iTween.EaseType.linear, iTween.LoopType.pingPong);
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
		Invoke ("bunnyPositioning", 0.7f);
	}

	private void earGermActive(){
		MoveAction (earGerm, earGermEndPoint, 1.0f, iTween.EaseType.linear, iTween.LoopType.none);
		ScaleAction (earGerm, 0.5f, 1.0f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("earGermInActive",1.5f);
	}

	private void earGermInActive(){
		MoveAction (earGerm, earGermStartPoint, 1.0f, iTween.EaseType.linear, iTween.LoopType.none);
		ScaleAction (earGerm, 1.0f, 1.0f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("earGermActive",1.5f);
	}

	private void bunnyPositioning(){
		MoveAction (bunny, bunnyEndPoint , 0.4f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("sideTablePositioning", 0.5f);
	}

	private void sideTablePositioning(){
		earGermActive ();
		MoveAction (sideTable, sideTableEndPoint, 0.5f, iTween.EaseType.easeInBounce, iTween.LoopType.none);
		if (PlayerPrefs.GetInt("CareerMode") == 1)
        {
            if (PlayerPrefs.GetInt("LevelPlayID") == 10)
            {
                Invoke("eyeDropperComesInn", 0.7f);
            }
            else if (PlayerPrefs.GetInt("LevelPlayID") == 11)
            {
                Invoke("injectionComesInn", 0.7f);
            }
            else if (PlayerPrefs.GetInt("LevelPlayID") == 12)
            {
                Invoke("mirrorComesInn", 0.7f);
            }
            else if (PlayerPrefs.GetInt("LevelPlayID") == 13)
            {
                Invoke("BottleComesInn", 0.7f);
            }
            else if (PlayerPrefs.GetInt("LevelPlayID") == 14)
            {
                Invoke("plateComesInn", 0.7f);
            }
        }
		else
        {
            Invoke("eyeDropperComesInn", 0.7f);
        }
    }

	private void eyeDropperComesInn(){
		SoundManager.instance.PlayToolComesSound ();
		eyeDropper.SetActive (true);
		MoveAction (eyeDropper, eyeDropperEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("eyeDrooperListenerOn", 0.5f);
		if (eyecounter == 0) {
			Invoke ("eyeDrooperListenerOn", 0.5f);
		} else {
			Invoke ("eyeDropperGoesToStartPoint", 0.5f);
		}
	}

	private void eyeDrooperListenerOn(){
		if (myCounter == 1) {
			eyeHand.SetActive (true);
			MoveAction (eyeHand, eyeHandEndPoint, 1.0f, iTween.EaseType.linear, iTween.LoopType.loop);
			myCounter = 2;
		}
		eyeDropper.GetComponent<ApplicatorListener> ().enabled = true;
	}

	private void eyeDropperGoesToStartPoint(){
		ParticleManger.instance.showPointingParticle (eyeClose.gameObject);
		MoveAction (eyeDropper, eyeDropperStartPoint, 0.5f, iTween.EaseType.easeInBack, iTween.LoopType.none);
        Invoke("injectionComesInn", 0.6f);
        Debug.Log("Level1 Done");
        if (PlayerPrefs.GetInt("CareerMode") == 1)
        {
            levelCompletePanel(10, 7);
        }
    }

	private void eyeDropperRotation(){
		if (eyecounter == 0) {
			print ("there");
			RotateAction (eyeDropper, 90.0f, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		} else {

			RotateAction (eyeDropper, -90.0f, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		}
		Invoke ("eyeDropActive", 0.5f);
	}

	private void eyeDropActive(){
		if (eyecounter == 0) {
			SoundManager.instance.playDropSound ();
			rightEyeDrop.SetActive (true);
			Destroy (rightEyeDrop, 0.3f);
		

		} else {
			SoundManager.instance.playDropSound ();
			leftEyeDrop.SetActive (true);
			Destroy (leftEyeDrop, 0.3f);
		
		}

		Invoke ("rednessRemoved", 0.4f);

	}

	private void rednessRemoved(){
		if (eyecounter == 0) {
			StartCoroutine (FadeOutAction(redRightEyeImage));
		} else {
			StartCoroutine (FadeOutAction(redLeftEyeImage));
		}

		Invoke ("eyeDropperStraight", 1.4f);
	}

	private void eyeDropperStraight(){
		RotateAction (eyeDropper,0.0f, 0.3f, iTween.EaseType.linear, iTween.LoopType.none); 
		Invoke ("eyeDropperComesInn", 0.4f);
	}

	private void injectionComesInn(){
		SoundManager.instance.PlayToolComesSound ();
		eyeClose.SetActive (true);
		injection.SetActive (true);
		MoveAction (injection, injectionEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("makingInjectionListenerOn", 0.5f);
	}

	private void makingInjectionListenerOn(){
		injectionHand.SetActive (true);
		MoveAction (injectionHand, injectionHandEndPoint, 1.0f, iTween.EaseType.linear, iTween.LoopType.loop);
		injection.GetComponent<ApplicatorListener> ().enabled = true;
		Invoke("usedInjectionTablePoint", 5f);
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

	private void usedInjectionTablePoint(){
		injectionGoesout ();
//		MoveAction (injectionUsed, injectionEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
//		Invoke("", 0.6f);
	}

	private void injectionGoesout(){
		expressions.sprite = faceImages [0];
		eyeClose.SetActive (true);
		MoveAction (injectionUsed, injectionStartPoint, 0.5f, iTween.EaseType.easeInBack, iTween.LoopType.none);
        Invoke("mirrorComesInn", 0.7f);
        Debug.Log("Level2 Done");
        if (PlayerPrefs.GetInt("CareerMode") == 1)
        {
            levelCompletePanel(11, 15);
        }
    }

	private void mirrorComesInn(){
		SoundManager.instance.PlayToolComesSound ();
		mirror.SetActive (true);
		MoveAction (mirror, mirrorEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("mirrorListenerOn", 0.5f);
	}

	private void mirrorListenerOn(){
		injectionHand.SetActive (true);
		MoveAction (injectionHand, injectionHandEndPoint, 1.0f, iTween.EaseType.linear, iTween.LoopType.loop);
		mirror.GetComponent<ApplicatorListener> ().enabled = true;
	}

	private void mirrorGoesOut(){
		expressions.sprite = faceImages [0];
		eyeClose.SetActive (true);
		MoveAction (mirror, mirrorStartPoint, 0.5f, iTween.EaseType.easeInBack, iTween.LoopType.none);
	}

	private void BottleComesInn(){
		germsPopup.SetActive (false);
		SoundManager.instance.PlayToolComesSound ();
		swabBottle.SetActive (true);
		MoveAction (swabBottle, swabBottleEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("brushListenerOn", 0.5f);
	}

	private void brushListenerOn(){
		brush.GetComponent<ApplicatorListener> ().enabled = true;
		pimple1.gameObject.transform.GetChild (0).gameObject.SetActive (true);
		pimple2.gameObject.transform.GetChild (0).gameObject.SetActive (true);
		pimple3.gameObject.transform.GetChild (0).gameObject.SetActive (true);
		pimple4.gameObject.transform.GetChild (0).gameObject.SetActive (true);
	}

	private void bottleGoesOut(){
		expressions.sprite = faceImages [0];
		eyeClose.SetActive (true);
		MoveAction (swabBottle, swabBottleStartPoint, 0.5f, iTween.EaseType.easeInBack, iTween.LoopType.none);
		Invoke ("plateComesInn", 0.6f);
        Debug.Log("Level4 Done");
        if (PlayerPrefs.GetInt("CareerMode") == 1)
        {
            levelCompletePanel(13, 11);
        }
    }

	private void brushPositioning(){
		ParticleManger.instance.showPointingParticle (bunny.gameObject);
		brush.GetComponent<ApplicatorListener> ().enabled = false;
		MoveAction (brush, brushStartPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("bottleGoesOut", 0.7f);
	}

	private void checkPimples(){
		if (pimpleCounter >= 4) {
			brushPositioning ();
		}
	}

	private void plateComesInn(){
		SoundManager.instance.PlayToolComesSound ();
		plate.SetActive (true);
		MoveAction (plate, plateEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("spoonListenerOn", 0.6f);
	}

	private void spoonListenerOn(){
		spoon.GetComponent<ApplicatorListener> ().enabled = true;
	}

	private void platesGoOutside(){
		//ParticleManger.instance.showPointingParticle (bunny.gameObject);
		MoveAction (plate, plateStartPoint, 0.5f, iTween.EaseType.easeInBack  , iTween.LoopType.none);
		Invoke ("toolsCompleted", 0.5f);
	}

	private void toolsCompleted(){
		ParticleManger.instance.showPointingParticle (bunnyFace.gameObject);
		//Invoke ("popupActive", 2.0f);
        Debug.Log("Level5 Done");
        if (PlayerPrefs.GetInt("CareerMode") == 1)
        {
            levelCompletePanel(14, 3);
        }
        else
        {
            Invoke("popupActive", 2.0f);
        }
    }

	private void popupActive(){
		lastpopup.SetActive (true);
		ScaleAction (lastpopup.transform.GetChild(0).gameObject, 1.0f, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		SoundManager.instance.PlayPopupCloseSound ();
		Invoke ("treatmentTextAppear", 1.2f);
	}

	private void treatmentTextAppear(){
		SoundManager.instance.PlayGirlSound ();
		ScaleAction (treamentText, 1.0f, 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("treatMentStamp", 0.4f);
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
		Invoke ("newBunnyComes", 2.0f);
	}

	private void newBunnyComes(){
		blackScreen.gameObject.SetActive (false);
		newBunny.SetActive (true);
		MoveAction (newBunny, newBunnyEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
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
            if (PlayerPrefs.GetInt("AnimalPlayed") == 2)
            {
                PlayerPrefs.SetInt("AnimalPlayed", 3);
            }
        }
		lastNextButton.SetActive (true);

	}



	#endregion

	#region Utility Methods
	public void OnCollisionWithEyes(){
		eyeHand.SetActive (false);
		if (GameManager.instance.currentItem == "LeftEye") {
			eyecounter = 1;
			MoveAction (eyeDropper, leftEyePoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
			Invoke ("eyeDropperRotation", 0.5f);
		}
		else if(GameManager.instance.currentItem == "RightEye"){
			eyecounter = 0;
			print ("123");
			MoveAction (eyeDropper, rightEyePoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
			leftEyePoint.gameObject.GetComponent<BoxCollider2D> ().enabled = true;
			Invoke ("eyeDropperRotation", 0.5f);
		}
	}

	public void onCollisionWithInjection(){
		expressions.sprite = faceImages [1];
		eyeClose.SetActive (false);
		injectionHand.SetActive (false);
		MoveAction (injection, injectionHitPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("injectionRotate", 0.5f);
	}



	public void OnDragSurringe(){
		if (injectionFlag) {
			SoundManager.instance.playInjectionSound ();
			MoveAction (injectionHandle, injectionHandleEndPoint, 1.0f, iTween.EaseType.linear, iTween.LoopType.none);
			StartCoroutine(FillOutAction (surringeImage));
			injectionFlag = false;
			Invoke ("usedInjectionTablePoint", 1.5f);
		}
	}

	public void OnCollisionOfMirror(){
		expressions.sprite = faceImages [1];
		eyeClose.SetActive (false);
		injectionHand.SetActive (false);
		SoundManager.instance.PlayCollisionSound ();
		MoveAction (mirror, mirrorHitPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke("openGermsPopUp", 1.0f);
	}

	public void SwabBrushBeginDrag(){
		rashArrow1.GetComponent<Image>().enabled= true;
		rashArrow2.GetComponent<Image>().enabled= true;
		rashArrow3.GetComponent<Image>().enabled= true;
		rashArrow4.GetComponent<Image>().enabled= true;

	}

	public void SwabBrushEndDrag(){
		rashArrow1.GetComponent<Image>().enabled= false;
		rashArrow2.GetComponent<Image>().enabled= false;
		rashArrow3.GetComponent<Image>().enabled= false;
		rashArrow4.GetComponent<Image>().enabled= false;

	}
	public void onCollisionWithSwabBrush(){
		expressions.sprite = faceImages [1];
		eyeClose.SetActive (false);
		if (GameManager.instance.currentItem == "Pimple1") {
			colorDecreases (pimple1, 0.2f);
			if (pimple1.color.a <= 0f) {
				pimple1.gameObject.transform.GetChild (0).gameObject.SetActive (false);
				ParticleManger.instance.showStarParticle (pimple1.gameObject);
				pimple1.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
				pimpleCounter++;
				checkPimples ();

			}
		}

		else if (GameManager.instance.currentItem == "Pimple2") {
			colorDecreases (pimple2, 0.2f);
			if (pimple2.color.a <= 0f) {
				pimple2.gameObject.transform.GetChild (0).gameObject.SetActive (false);
				ParticleManger.instance.showStarParticle (pimple2.gameObject);
				pimple2.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
				pimpleCounter++;
				checkPimples ();

			}
		}

		else if (GameManager.instance.currentItem == "Pimple3") {
			colorDecreases (pimple3, 0.2f);
			if (pimple3.color.a <= 0f) {
				pimple3.gameObject.transform.GetChild (0).gameObject.SetActive (false);
				ParticleManger.instance.showStarParticle (pimple3.gameObject);
				pimple3.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
				pimpleCounter++;
				checkPimples ();

			}
		}

		else if (GameManager.instance.currentItem == "Pimple4") {
			colorDecreases (pimple4, 0.2f);
			if (pimple4.color.a <= 0f) {
				pimple4.gameObject.transform.GetChild (0).gameObject.SetActive (false);
				ParticleManger.instance.showStarParticle (pimple4.gameObject);
				pimple4.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
				pimpleCounter++;
				checkPimples ();

			}
		}

	}

	private void openGermsPopUp(){
		SoundManager.instance.PlayPopupCloseSound ();
		ScaleAction (germsPopup, 1.0f, 1.0f, iTween.EaseType.easeInBack,iTween.LoopType.none);
		germsPopup.SetActive (true);
		StartCoroutine( insectPositioning ());

	}

	IEnumerator insectPositioning()
	{
		yield return new WaitForSeconds (0.5f);
		if (counter <= 2) {
			counter = counter + 1;

		} else {
			counter = 1;
		}
		if (counter == 1) {
			if (insect1 == 1) {
			} else {
				MoveAction (insects [0], insectPositions [0].GetComponent<RectTransform> (), 1.0f, iTween.EaseType.linear, iTween.LoopType.none);
			}
			if (insect2 == 1) {
			} else {
				MoveAction (insects [1], insectPositions [1].GetComponent<RectTransform> (), 1.0f, iTween.EaseType.linear, iTween.LoopType.none);
			}
			if (insect3 == 1) {
			} else {
				MoveAction (insects [2], insectPositions [2].GetComponent<RectTransform> (), 1.0f, iTween.EaseType.linear, iTween.LoopType.none);
			}
			if (insect4 == 1) {
			} else {
				MoveAction (insects [3], insectPositions [3].GetComponent<RectTransform> (), 1.0f, iTween.EaseType.linear, iTween.LoopType.none);
			}
			if (insect5 == 1) {
			} else {
				MoveAction (insects [4], insectPositions [4].GetComponent<RectTransform> (), 1.0f, iTween.EaseType.linear, iTween.LoopType.none);
			}
			//counter++;
			StartCoroutine (insectPositioning ());
		} 
		if (counter == 2) {
			if (insect1 == 1) {
			} else {
				MoveAction (insects [0], insectPositions [4].GetComponent<RectTransform> (), 1.0f, iTween.EaseType.linear, iTween.LoopType.none);
			}
			if (insect2 == 1) {
			} else {
				MoveAction (insects [1], insectPositions [3].GetComponent<RectTransform> (), 1.0f, iTween.EaseType.linear, iTween.LoopType.none);
			}
			if (insect3 == 1) {
			} else {
				MoveAction (insects [2], insectPositions [5].GetComponent<RectTransform> (), 1.0f, iTween.EaseType.linear, iTween.LoopType.none);
			}
			if (insect4== 1) {
			} else {
				MoveAction (insects [3], insectPositions [1].GetComponent<RectTransform> (), 1.0f, iTween.EaseType.linear, iTween.LoopType.none);
			}
			if (insect5== 1) {
			} else {
				MoveAction (insects [4], insectPositions [0].GetComponent<RectTransform> (), 1.0f, iTween.EaseType.linear, iTween.LoopType.none);
			}
			//counter++;
			StartCoroutine (insectPositioning ());
		} if (counter == 3) {
			if (insect1 == 1) {
			} else {
				MoveAction (insects [0], insectPositions [7].GetComponent<RectTransform> (), 1.0f, iTween.EaseType.linear, iTween.LoopType.none);
			}
			if (insect2 == 1) {
			} else {
				MoveAction (insects [1], insectPositions [8].GetComponent<RectTransform> (), 1.0f, iTween.EaseType.linear, iTween.LoopType.none);
			}
			if (insect3 == 1) {
			} else {
				MoveAction (insects [2], insectPositions [1].GetComponent<RectTransform> (), 1.0f, iTween.EaseType.linear, iTween.LoopType.none);
			}
			if (insect4 == 1) {
			} else {
				MoveAction (insects [3], insectPositions [6].GetComponent<RectTransform> (), 1.0f, iTween.EaseType.linear, iTween.LoopType.none);
			}
			if (insect5 == 1) {
			} else {
				MoveAction (insects [4], insectPositions [3].GetComponent<RectTransform> (), 1.0f, iTween.EaseType.linear, iTween.LoopType.none);
			}
			//counter++;
			StartCoroutine (insectPositioning ());
		} 
	}

	private void closeGermsPopUp(){
		SoundManager.instance.PlayPopupCloseSound ();
		StartCoroutine (FadeOutAction(germsPopup.GetComponent<Image>()));
		ScaleAction (germsPopup.transform.GetChild(0).gameObject, 0.0f, 1.0f, iTween.EaseType.easeInBack, iTween.LoopType.none);
		ParticleManger.instance.showPointingParticle (earGerm.gameObject);
		Invoke ("BottleComesInn", 1.0f);
        Debug.Log("Level3 Done");
        if (PlayerPrefs.GetInt("CareerMode") == 1)
        {
            levelCompletePanel(12, 20);
        }
    }

	public void germKillingDown(int tag){
		print ("function call"+tag);
		if(tag==1 && insect1 != 1)
        {
            SoundManager.instance.PlayGermSound();
            killingCounter = killingCounter + 1;
			Destroy (insects[0]);
			insect1 = 1;
		}
		if (tag == 2 && insect2 != 1)
        {
            SoundManager.instance.PlayGermSound();
            killingCounter = killingCounter + 1;
			Destroy (insects[1]);
			insect2 = 1;
		}
		if (tag == 3 && insect3 != 1)
        {
            SoundManager.instance.PlayGermSound();
            killingCounter = killingCounter + 1;
			insect3 = 1;
			Destroy (insects[2]);
		}
		if (tag == 4 && insect4 != 1)
        {
            SoundManager.instance.PlayGermSound();
            killingCounter = killingCounter + 1;
			insect4 = 1;
			Destroy (insects[3]);
		}
		if (tag == 5 && insect5 != 1)
        {
            SoundManager.instance.PlayGermSound();
            killingCounter = killingCounter + 1;
			insect5 = 1;
			Destroy (insects[4]);
		}

		if (killingCounter >= 5)
        {
            SoundManager.instance.PlayGermSound();
            earGerm.GetComponent<Image> ().enabled = false;
			mirror.SetActive (false);
			Invoke ("closeGermsPopUp",0.5f);
		}

	}

	public void onCollisionSpoonWithMouth(){
		expressions.sprite = faceImages [0];
		eyeClose.SetActive (true);
		if (GameManager.instance.currentItem == "mouth") {
			MoveAction (spoon, spoonMouthPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
			Invoke ("spoonEmpty", 0.8f);
		}
		else if (GameManager.instance.currentItem == "Plate") {
			spoon.GetComponent<Image>().sprite = spoonSprites [1];
		}
	}

	private void spoonEmpty(){
		SoundManager.instance.PlayBiteSound ();
		spoon.GetComponent<Image>().sprite = spoonSprites [0];
		Invoke ("smoothStartPoint", 0.3f);
	}

	private void smoothStartPoint(){
		MoveAction (spoon, spoonEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke("spoonAgainActive", 0.7f);
	}

	private void spoonAgainActive(){
		
//		 {
			spoon.GetComponent<ApplicatorListener> ().enabled = true;
			spoon.GetComponent<BoxCollider2D> ().enabled = true;
			plate.GetComponent<BoxCollider2D> ().enabled = true;
			mouth.GetComponent<BoxCollider2D> ().enabled = true;
			print ("eatingCounter"+ ++eatingCounter);
		if (eatingCounter >= 3) {
			spoon.GetComponent<ApplicatorListener> ().enabled = false;
			spoon.GetComponent<BoxCollider2D> ().enabled = false;
			plate.GetComponent<BoxCollider2D> ().enabled = false;
			mouth.GetComponent<BoxCollider2D> ().enabled = false;
			Invoke("platesGoOutside", 0.7f);
		}
		//} 
//		else {
//			
//		}
	
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
        if (levelCount == 14)
        {
            PlayerPrefs.SetInt("LevelPlayID", 4);
            NavigationManager.instance.ReplaceScene(GameScene.BATHVIEW);
        }
        if (levelCount == 13)
        {
            PlayerPrefs.SetInt("LevelPlayID", 3);
            NavigationManager.instance.ReplaceScene(GameScene.BATHVIEW);
        }
        if (levelCount == 12)
        {
            NavigationManager.instance.ReplaceScene(GameScene.BATHVIEW);
        }
        if (levelCount == 11)
        {
            PlayerPrefs.SetInt("LevelPlayID", 1);
            NavigationManager.instance.ReplaceScene(GameScene.BATHVIEW);
        }
        if (levelCount == 10)
        {
            PlayerPrefs.SetInt("LevelPlayID", 0);
            NavigationManager.instance.ReplaceScene(GameScene.BATHVIEW);
        }
        //if (levelCount == 14)
        //{
        //    PlayerPrefs.SetInt("LevelPlayID", 15);
        //    NavigationManager.instance.ReplaceScene(GameScene.TIGERVIEW);
        //}
        levelComplete.SetActive(false);
    }

    void levelCompletePanel(int levelId, int levelPlayingID)
    {
        int levelPlayID = levelPlayingID - 1;
        Debug.Log(PlayerPrefs.GetInt("LevelPlayed"));
        if (PlayerPrefs.GetInt("CareerMode") == 1)
        {
            ParticleManger.instance.showPointingParticle(bunnyFace.gameObject);
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
