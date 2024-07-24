using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum GameScene { MAINMENU = 0, BATHVIEW = 1, DRESSUPVIEW = 2, EATINGVIEW = 3, SLEEPINGVIEW = 4, RECEPTIONView = 5 }

public class NavigationManager : MonoBehaviour {

	#region Variables, Constants & Initializers

	public bool ShowDebugLogs;

	private Dictionary<string, Stack> navigationStacks = new Dictionary<string, Stack>();
	public Stack navigationStack;
	public GameScene launchScene;

	public GameObject mainMenu;
    public GameObject bathView;
    public GameObject DressUpView;
    public GameObject EatingView;
    public GameObject SleepingView;
    public GameObject ResceptionView;

    private GameObject runningScene;

	// persistant singleton
    private static NavigationManager _instance;

	#endregion
	
	#region Lifecycle methods

    public static NavigationManager instance
	{
		get
		{
			if(_instance == null)
			{
                _instance = GameObject.FindObjectOfType<NavigationManager>();

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

	// Update is called once per frame
	void Update () {
		OnBackKeyPressed ();
	}

	void Start ()
	{
        //Debug.Log("Start Called");

        // for any init behavior setup
		runningScene = null;
        navigationStack = new Stack();
		SetGameScene (launchScene);
    }
	
	void OnEnable()
	{
		//Debug.Log("OnEnable Called");
		AdsManager.Instance.ShowBanner();

	}
	
	void OnDisable()
	{
		//Debug.Log("OnDisable Called");

	}

	#endregion

	#region Utility Methods 

	private void SetGameScene(GameScene scene) {
		if(runningScene != null) {
			Destroy (runningScene);
		}

		switch (scene) {
			case GameScene.MAINMENU:
				runningScene = GetGameSceneInstance (mainMenu);
				break;
            case GameScene.BATHVIEW:
                runningScene = GetGameSceneInstance(bathView);
                break;
            case GameScene.DRESSUPVIEW:
                runningScene = GetGameSceneInstance(DressUpView);
                break;
            case GameScene.EATINGVIEW:
                runningScene = GetGameSceneInstance(EatingView);
                break;
            case GameScene.SLEEPINGVIEW:
                runningScene = GetGameSceneInstance(SleepingView);
                break;
            case GameScene.RECEPTIONView:
                runningScene = GetGameSceneInstance(ResceptionView);
                break;

        }

		navigationStack.Push (scene);

		runningScene.SetActive (true);
	}

	private GameObject GetGameSceneInstance(GameObject prefab) {
		GameObject gameScene = GameObject.Instantiate(prefab) as GameObject;
		gameScene.name = prefab.name;
		gameScene.GetComponent<Canvas>().worldCamera = Camera.main;

		return gameScene;
	}

	public void ReplaceScene(GameScene scene) {
		SetGameScene (scene);
	}

	public void ReplaceSceneWithClear(GameScene scene) {
		navigationStack.Clear();
		SetGameScene (scene);
	}

	#endregion

	#region Callback Methods 

	private void OnBackKeyPressed() {
#if UNITY_ANDROID || UNITY_WP8
		if (Input.GetKeyDown(KeyCode.Escape) && (!GameManager.instance.isGamePaused)) 
		{ 
			switch ((GameScene) navigationStack.Peek()) {
			case GameScene.MAINMENU:
				//Application.Quit();
				break;
			case GameScene.BATHVIEW:
				navigationStack.Clear();
				ReplaceScene(GameScene.MAINMENU);
				break;
			case GameScene.DRESSUPVIEW:
				navigationStack.Clear();
				ReplaceScene(GameScene.MAINMENU);
				break;
			case GameScene.EATINGVIEW:
				navigationStack.Clear();
				ReplaceScene(GameScene.MAINMENU);
				break;
			case GameScene.SLEEPINGVIEW:
				navigationStack.Clear();
				ReplaceScene(GameScene.MAINMENU);
				break;
			case GameScene.RECEPTIONView:
				navigationStack.Clear();
				ReplaceScene(GameScene.MAINMENU);
				break;
			}
		}
#endif
    }

    #endregion
}
