using System;
using System.Collections;
using System.Collections.Generic;	
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class ReceptionView : MonoBehaviour {
	#region Variables, Constants & Initializers
	public GameObject randomAnimalAnimation;
	public GameObject gamePlay;
	public Image animalRandomImage;
	public Sprite[] animalRandomImages;
	public GameObject leftDoor, rightDoor;
	public RectTransform leftDoorEndPoint, rightDoorEndPoint, leftDoorStartPoint, rightDoorStartPoint;
	public GameObject[] animals;
	public RectTransform animalCounterPoint;
	public GameObject Counter;
	public GameObject popup;
	public Image animalImage;
	public Text nameText, dignosisText, treatmentText;
	public Sprite[] animalsSprite;
	public String[] animalsNames;
	public GameObject Content;
	public RectTransform contentEndPoint;
	public GameObject scrollStopImage;
	public GameObject cat, dog, bunny, tiger, panda;
	public GameObject homeButton;

	public Text PetName;

	private int animalNumber;

	// Use this for initialization
	#endregion

	#region Lifecycle Methods

	// Use this for initialization
	void Start () {
        //PlayerPrefs.SetInt ("AnimalSelected", 0 );
        PlayerPrefs.SetInt("ComingFromSplash", 0);
        animalNumber = 0;
		if (PlayerPrefs.GetInt("RandomMode") == 1)
		{
			gamePlay.SetActive(false);
			randomAnimalAnimation.SetActive(true);
			animalNumber = Random.Range(0, 4);
			Debug.Log(animalNumber);
			if (animalNumber == PlayerPrefs.GetInt("animalNumber"))
			{
				if (animalNumber == 4)
				{
					animalNumber = animalNumber - 1;
				} else
				{
					animalNumber = animalNumber + 1;
				}
				PlayerPrefs.SetInt("animalNumber", animalNumber);
			} else
			{
				PlayerPrefs.SetInt("animalNumber", animalNumber);
			}
			InvokeRepeating("AnimalRandomImageShuffle", 0.1f, 0.1f);
			Invoke("cancelRandomImageShuffle", 3.0f);

		}
		//else if (PlayerPrefs.GetInt("PetCareMode") == 1)
        //{
        //    animalNumber = PlayerPrefs.GetInt("PetSelected");
        //}
		//else
		//{
		//	animalNumber = PlayerPrefs.GetInt("AnimalSelected");
		//}
        Invoke ("SetViewContents", 0.1f);
		checkAnimalActive ();
		
		Debug.Log(animalNumber);
	}

    void cancelRandomImageShuffle()
    {
        CancelInvoke("AnimalRandomImageShuffle");
        animalRandomImage.GetComponent<Image>().sprite = animalRandomImages[animalNumber];
		animalRandomImage.GetComponent<Image>().SetNativeSize();
		Invoke("GamePlay", 1.0f);
    }
	private int petId;
    void AnimalRandomImageShuffle()
	{
		petId = Random.Range(0, animalRandomImages.Length - 1);
		animalRandomImage.GetComponent<Image>().sprite = animalRandomImages[petId];
		animalRandomImage.GetComponent<Image>().SetNativeSize();
		PetName.text = animalsNames[petId];
		SoundManager.instance.PlayShuffleSound();
    }

	void GamePlay()
    {
        PlayerPrefs.SetInt("PetSelected", animalNumber);
        NavigationManager.instance.ReplaceScene(GameScene.BATHVIEW);
        //gamePlay.SetActive(true);
        //randomAnimalAnimation.SetActive(false);
    }

    #endregion

    #region Utility Methods

    private void SetViewContents() {
        //PlayerPrefs.DeleteAll ();
        //PlayerPrefs.SetInt ("AnimalSelected", 0 );
        if (PlayerPrefs.GetInt("RandomMode") == 1)
        {
            Invoke("contentMovement", 4.0f);
        } else
		{
			contentMovement();
        }
		//doorOpen ();
	
	}

	private void checkAnimalActive(){
		switch(animalNumber){
		case 0:
			dog.SetActive (true);
			panda.SetActive (true);
			tiger.SetActive (true);
			break;

		case 1:
			cat.SetActive (true);
			panda.SetActive (true);
			bunny.SetActive (true);
			break;

		case 2:
			cat.SetActive (true);
			panda.SetActive (true);
			tiger.SetActive (true);
			break;

		case 3:
			dog.SetActive (true);
			panda.SetActive (true);
			bunny.SetActive (true);
			break;

		case 4:
			cat.SetActive (true);
			panda.SetActive (false);
			bunny.SetActive (true);
			break;
		}


	}

	private void contentMovement(){
		MoveAction (Content, contentEndPoint, 2.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("doorOpen", 2.5f);

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
		

	private void doorOpen(){
	//	scrollStopImage.SetActive (false);
		homeButton.SetActive(true);
		animals [animalNumber].SetActive (true);
		MoveAction (rightDoor, rightDoorEndPoint, 1.0f, iTween.EaseType.linear, iTween.LoopType.none);
		MoveAction (leftDoor, leftDoorEndPoint, 1.0f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("AnimalComes", 1.1f);	
	}

	private void doorClosed(){
		MoveAction (rightDoor, rightDoorStartPoint, 1.0f, iTween.EaseType.linear, iTween.LoopType.none);
		MoveAction (leftDoor, leftDoorStartPoint, 1.0f, iTween.EaseType.linear, iTween.LoopType.none);
	}

	private void AnimalComes(){

		Invoke ("AnimalComesToCounter", 0.5f);
	}

	private void AnimalComesToCounter(){
		animals [animalNumber].transform.SetParent (Counter.transform);
		//MoveAction (animals [animalNumber], animalCounterPoint, 1.0f, iTween.EaseType.linear, iTween.LoopType.none );
		animals [animalNumber].gameObject.GetComponent<RectTransform>().position = animalCounterPoint.gameObject.GetComponent<RectTransform>().position;
		animals [animalNumber].gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (0.55f, 0.55f, 0.55f);
		//ScaleAction (animals [animalNumber], 0.55f, 1.0f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("doorClosed", 0.8f);
		Invoke ("popupOpen", 2.0f);
	}

	private void popupOpen(){
		animalImage.sprite = animalsSprite [animalNumber];
		animalImage.gameObject.SetActive (true);
		animalImage.SetNativeSize ();
		switch(animalNumber){
		case 0:
			nameText.text = "Cat";
			dignosisText.text = "Injured";
			treatmentText.text = "";
			break;

		case 1:
			nameText.text = "Dog";
			dignosisText.text = "Stomach Disease";
			treatmentText.text = "";
			break;

		case 2:
			nameText.text = "Buuny";
			dignosisText.text = "Skin Allergy";
			treatmentText.text = "";
			break;

		case 3:
			nameText.text = "Tiger";
			dignosisText.text = "Dirty";
			treatmentText.text = "";
			break;

		case 4:
			nameText.text = "Panda";
			dignosisText.text = "Bone Fracture";
			treatmentText.text = "";
			break;
		}
		popup.SetActive (true);
		SoundManager.instance.PlayPopupCloseSound ();
		ScaleAction (popup.transform.GetChild(0).gameObject, 1.0f, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("GotoGamePlay", 3.5f);


	}

	private void GotoGamePlay(){
        PlayerPrefs.SetInt("PetSelected", animalNumber);
        NavigationManager.instance.ReplaceScene(GameScene.BATHVIEW);
	}
			
	public void onClickHome(){
       
       NavigationManager.instance.ReplaceScene (GameScene.MAINMENU);
	}

	#endregion

	#region CallBack Methods

	#endregion

}
