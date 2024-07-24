using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum Publisher { KIDDLEFIDDLE = 0, HONEYBADGER = 1, SALONMAKEOVER = 2, WOOFIEGAMES = 3, TRUCKERSTUDIO = 4 }

public class GDPRConsent : MonoBehaviour {

	#region Variables, Constants & Initializers
    private const string TAG_GRPD = "GDPR_Consent";
    
    public Publisher publisher;
    public GameScene nextScene;
    
    public GameObject popup;
	public RectTransform popupEndPoint;

	#endregion

	#region Lifecycle Methods

	// Use this for initialization
	void Start () {


		Invoke ("SetViewContents", 0.1f);
	}
	
	// Update is called once per frame
	void Update () {
		#if UNITY_ANDROID || UNITY_WP8
		if (Input.GetKeyDown(KeyCode.Escape)) 
		{ 
			
		}

		#endif
	}

	void Destroy() {
		iTween.Stop ();
	}

	#endregion

	#region Callback Methods

	private void SetViewContents() {

        if (PlayerPrefs.GetInt(TAG_GRPD, 0) == 1)
        {
            OnIAgreeButtonClicked();
        }

        if (popup != null)
		{
			Hashtable tweenParams = new Hashtable();
            tweenParams.Add("y", popupEndPoint.position.y);
			tweenParams.Add ("time", 1f);
			tweenParams.Add ("easetype", iTween.EaseType.easeInOutBounce);
            iTween.MoveTo(popup, tweenParams);
		}
	}

	public void OnIAgreeButtonClicked() {
		GameManager.instance.LogDebug ("IAgree Clicked");

        PlayerPrefs.SetInt(TAG_GRPD, 1);
        PlayerPrefs.Save();

        // for banner ad visibility
        //ShowAdmobMethods.RequestBanner();

        NavigationManager.instance.ReplaceScene(nextScene);
	}

	public void OnPrivacyPolicyButtonClicked() {
		GameManager.instance.LogDebug ("PrivacyPolicy Clicked");

        switch (publisher)
        {
            case Publisher.KIDDLEFIDDLE:
                Application.OpenURL("https://kiddlefiddle.wordpress.com/");
                break;
            case Publisher.HONEYBADGER:
                Application.OpenURL("https://honeybadgerapps.wordpress.com/2017/02/03/first-blog-post/");
                break;
            case Publisher.SALONMAKEOVER:
                Application.OpenURL("https://makeoverspa.wordpress.com/2017/02/03/first-blog-post/");
                break;
            case Publisher.WOOFIEGAMES:
                Application.OpenURL("http://woofiegames.blogspot.com/");
                break;
            case Publisher.TRUCKERSTUDIO:
                Application.OpenURL("https://truckerstudios.wordpress.com/");
                break;
        }
	}
	#endregion
}
