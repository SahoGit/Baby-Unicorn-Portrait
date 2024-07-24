using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnicornController : MonoBehaviour
{
    public int id;
    public Button lockBtn;
    public string petName;
    public GameObject lockImage;
    public GameObject animalImage;
    public GameObject watchAdButton;
    public GameObject watchAdPanel;
    // Start is called before the first frame update
    void Start()
    {
        //// my side line al ////
         PlayerPrefs.SetInt("AnimalUnlock" + id, 1);
         ////// end /////
        if (PlayerPrefs.GetInt("AnimalPlayed") >= id || PlayerPrefs.GetInt("AnimalUnlock" + id) == 1)
        {
            lockImage.SetActive(false);
            lockBtn.GetComponent<Button>().interactable = true;
            animalImage.GetComponent<Image>().color = new Color(255, 255, 255, 255);
            watchAdButton.SetActive(false);
        }
        else
        {
            lockBtn.GetComponent<ActionManager>().enabled = true;
        }
    }

    public void onPlayGame(int petId)
    {
        SoundManager.instance.PlayButtonClickSound();
        PlayerPrefs.SetInt("PetSelected", petId);
        PlayerPrefs.SetString("SelectedPetName", petName);
        if (petId == 0 || petId == 2)
        {
            NavigationManager.instance.ReplaceScene(GameScene.BATHVIEW);
        }
        else
        {
            NavigationManager.instance.ReplaceScene(GameScene.DRESSUPVIEW);
        }
    }

    public void watchAdPanelOn()
    {
        SoundManager.instance.PlayButtonClickSound();
        watchAdPanel.SetActive(true);
    }
}