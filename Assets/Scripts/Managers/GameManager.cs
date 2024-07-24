using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using BeeAdsSDK;
[System.Serializable]
public class GameManager : MonoBehaviour {

	#region Variables, Constants & Initializers

	public bool ShowDebugLogs;
    [SerializeField]
    public ArrayList charactersDataList;
    [SerializeField] 
	public ArrayList hatsDataList;
    [SerializeField] 
	public ArrayList beardStylesDataList;
    [SerializeField] 
	public ArrayList glassesDataList;
    [SerializeField]
    public ArrayList dressDataList;
    [SerializeField]
    public ArrayList hornDataList;
    [SerializeField]
    public ArrayList shoesDataList;
    [SerializeField]
    public ArrayList lensDataList;

    //[HideInInspector]
    public bool isGameFirstLoop;
	//[HideInInspector]
	public string currentSalonMode;
	//[HideInInspector]
	public string currentScene;
	//[HideInInspector]
	public string currentItem;
	//[HideInInspector]
	public string woundTag;
	//[HideInInspector] 
	public ContactPoint2D contact;
	public BaseItem selectedCharacter;

    public BaseItem CurrentDressupItem;
    public BaseItem selectedDress;
    public BaseItem selectedHorn;
    public BaseItem selectedShoes;
    public BaseItem selectedLens;

    public Player player;

    //[HideInInspector]
    public bool isGamePaused;
	
	// persistant singleton
    private static GameManager _instance;

	#endregion
	
	#region Lifecycle methods

    public static GameManager instance
	{
		get
		{
			if(_instance == null)
			{
                _instance = GameObject.FindObjectOfType<GameManager>();

				//Tell unity not to destroy this object when loading a new scene!
				DontDestroyOnLoad(_instance.gameObject);
			}
			
			return _instance;
		}
	}
	
	void Awake() 
	{
		Debug.Log("Awake Called");

		if(_instance == null)
		{
			//If I am the first instance, make me the Singleton
			_instance = this;
			DontDestroyOnLoad(this);
		}
		else
		{
			//If a Singleton already exists and you find
			//another reference in scene, destroy it!
			if(this != _instance)
				Destroy(gameObject);
		}
	}

	void Start ()
	{
		Debug.Log("Start Called");

		// for any init behavior setup
		this.isGamePaused = false;
		this.isGameFirstLoop = true;

		this.SetData();
	}
	
	void OnEnable()
	{
		//AdsManager.Instance.ShowBanner();
		Debug.Log("OnEnable Called");

	}
	
	void OnDisable()
	{
		Debug.Log("OnDisable Called");

	}

	#endregion

	#region Utility Methods 

	private void SetData() {

		this.charactersDataList = DataProvider.GetCharactersDataList ();
		this.hatsDataList = DataProvider.GetHatsDataList ();
		this.glassesDataList = DataProvider.GetGlassesDataList ();
		this.beardStylesDataList = DataProvider.GetBeardStylesDataList ();
        this.dressDataList = DataProvider.GetDressDataList();
        this.hornDataList = DataProvider.GetHornDataList();
        this.shoesDataList = DataProvider.GetShoesDataList();
        this.lensDataList = DataProvider.GetLensDataList();
    }

	public void LogDebug(string message) {
		if (ShowDebugLogs)
			Debug.Log ("GameManager >> " + message);
	}
	
	private void LogErrorDebug(string message) {
		if (ShowDebugLogs)
			Debug.LogError ("GameManager >> " + message);
	}

	#endregion

	#region Callback Methods 


	#endregion
}
