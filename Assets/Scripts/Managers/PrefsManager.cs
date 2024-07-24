using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefsManager : MonoBehaviour
{
    private static PrefsManager _instance;

    public static PrefsManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<PrefsManager>();

                //Tell unity not to destroy this object when loading a new scene!
                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }

    void Awake()
    {
        //Debug.Log("Awake Called");

        if (_instance == null)
        {
            //If I am the first instance, make me the Singleton
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            //If a Singleton already exists and you find
            //another reference in scene, destroy it!
            if (this != _instance)
                Destroy(gameObject);
        }
    }

    public int GetPlayerScore()
    {
        return PlayerPrefs.GetInt("PlayerScore");
    }
    public void SetPlayerScore(int score)
    {
        PlayerPrefs.SetInt("PlayerScore", PlayerPrefs.GetInt("PlayerScore") + score);
    }
    public void PurchasePlayerScore(int score)
    {
        PlayerPrefs.SetInt("PlayerScore", PlayerPrefs.GetInt("PlayerScore") - score);
    }
    public int GetLevelPlayed()
    {
        return PlayerPrefs.GetInt("LevelPlayed");
    }
    public void SetLevelPlayed(int levelUpdate)
    {
        PlayerPrefs.SetInt("LevelPlayed", PlayerPrefs.GetInt("LevelPlayed") + levelUpdate);
    }
    public void SetPlayedPet(int PetId)
    {
        PlayerPrefs.SetInt("LevelPlayed", PetId);
    }
}
