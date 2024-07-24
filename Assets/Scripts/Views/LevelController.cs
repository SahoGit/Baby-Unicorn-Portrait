using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public int levelId;
    public int petSelectedId;
    public string petName;
    public bool isLocked;
    public GameObject levelNumberText;
    public GameObject lockBtn;
    public Sprite lockedImg;
    public Sprite UnLockedImg;
    public Sprite playedImage;
    // Start is called before the first frame update

    void OnValidate()
    {
        //PlayerPrefs.SetInt("LevelPlayed", 60);
        //string[] digits = Regex.Split(this.gameObject.name, @"\D+");
        //foreach (string value in digits)
        //{
        //    int number;
        //    if (int.TryParse(value, out number))
        //    {
        //        levelId = int.Parse(value) - 1;
        //        levelNumberText.GetComponent<Text>().text = int.Parse(value).ToString();
        //    }
        //
        //
        //}
        //levelNumberText = this.gameObject.transform.GetChild(0).gameObject;
        //lockBtn = this.gameObject;


    }
    void Start()
    {
        if (PlayerPrefs.GetInt("LevelPlayed") >= levelId)
        {
            if ((PlayerPrefs.GetInt("LevelPlayed") - 1) >= levelId)
            {
                lockBtn.GetComponent<Image>().sprite = playedImage;
            }
            else
            {
                lockBtn.GetComponent<Image>().sprite = UnLockedImg;
            }
            levelNumberText.SetActive(true);
            lockBtn.GetComponent<Button>().interactable = true;
            lockBtn.GetComponent<ActionManager>().enabled = true;
        } else
        {
            levelNumberText.SetActive(false);
            lockBtn.GetComponent<Image>().sprite = lockedImg;
            lockBtn.GetComponent<Button>().interactable = false;
            lockBtn.GetComponent<ActionManager>().enabled = false;
        }
        Debug.Log((PlayerPrefs.GetInt("LevelPlayed") - 1) >= levelId);
    }

   

    public void CareerModeLevelPlay(int playingLevelId)
    {
        SoundManager.instance.PlayButtonClickSound();
        PlayerPrefs.SetInt("PetSelected", petSelectedId);
        PlayerPrefs.SetInt("levelPlayedId", levelId);
        PlayerPrefs.SetInt("PlayingLevel", playingLevelId);
        PlayerPrefs.SetString("SelectedPetName", petName);
        if (playingLevelId == 0)
        {
            NavigationManager.instance.ReplaceScene(GameScene.SLEEPINGVIEW);
        }
        else if (playingLevelId == 1)
        {
            NavigationManager.instance.ReplaceScene(GameScene.EATINGVIEW);
        }
        else if (playingLevelId == 2)
        {
            NavigationManager.instance.ReplaceScene(GameScene.BATHVIEW);
        }
        else if (playingLevelId == 3)
        {
            NavigationManager.instance.ReplaceScene(GameScene.BATHVIEW);
        }
        else if (playingLevelId == 4)
        {
            NavigationManager.instance.ReplaceScene(GameScene.BATHVIEW);
        }
        else if (playingLevelId == 5)
        {
            NavigationManager.instance.ReplaceScene(GameScene.BATHVIEW);
        }
        else if (playingLevelId == 6)
        {
            NavigationManager.instance.ReplaceScene(GameScene.DRESSUPVIEW);
        }
        else if (playingLevelId == 7)
        {
            NavigationManager.instance.ReplaceScene(GameScene.DRESSUPVIEW);
        }
        else if (playingLevelId == 8)
        {
            NavigationManager.instance.ReplaceScene(GameScene.DRESSUPVIEW);
        }
        else if (playingLevelId == 9)
        {
            NavigationManager.instance.ReplaceScene(GameScene.DRESSUPVIEW);
        }
        else if (playingLevelId == 10)
        {
            NavigationManager.instance.ReplaceScene(GameScene.EATINGVIEW);
        }
        else if (playingLevelId == 11)
        {
            NavigationManager.instance.ReplaceScene(GameScene.SLEEPINGVIEW);
        }
    }
}
