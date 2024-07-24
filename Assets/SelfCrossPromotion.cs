using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SelfCrossPromotion : MonoBehaviour
{
    public Text GameName;
    public Image icon;
    public CrossPromotion[] CP;
    public int currentCP = 0;
    CrossPromotion crossPromotion;

    private void OnEnable()
    {
        SetIndex();
        LoadCP();
    }

    public void CPClicked()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=" + crossPromotion.PackageName);
    }

    void LoadCP()
    {
        crossPromotion = CP[currentCP];
        GameName.text = crossPromotion.GameName;
        icon.sprite = crossPromotion.icon;
    }

    void SetIndex()
    {
        if (PlayerPrefs.HasKey("SelfCrossPromotion"))
        {
            currentCP= PlayerPrefs.GetInt("SelfCrossPromotion", 0);
            currentCP++;
            if (currentCP >= CP.Length)
            {
                currentCP = 0;
            }
            PlayerPrefs.SetInt("SelfCrossPromotion", currentCP);
        }
        else
        {
            PlayerPrefs.SetInt("SelfCrossPromotion", 0);
        }
    }

    [Serializable]
    public class CrossPromotion
    {
        public string GameName;
        public string PackageName;
        public Sprite icon;
    }
}
