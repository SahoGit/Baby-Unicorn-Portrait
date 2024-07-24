using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetController : MonoBehaviour
{
    public int id;
    public Button lockBtn;
    public GameObject lockImage;
    public GameObject animalImage;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("AnimalPlayed") >= id)
        {
            lockImage.SetActive(false);
            lockBtn.GetComponent<Button>().interactable = true;
            animalImage.GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }
        else
        {
            lockBtn.GetComponent<ActionManager>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onPlayGame(int petId)
    {
        PlayerPrefs.SetInt("PetSelected", petId);
        NavigationManager.instance.ReplaceScene(GameScene.BATHVIEW);
    }
}
