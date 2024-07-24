using UnityEngine;
using System.Collections;

public class RateUs : MonoBehaviour {

    public string AndroidBundleID;
    public string IOSBundleID;
    public string WP8AppID;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick () {
#if UNITY_ANDROID
		if(AndroidBundleID != "") {
			Application.OpenURL("market://details?id=" + AndroidBundleID);
		}
#elif UNITY_IPHONE
		if(IOSBundleID != "") {
			Application.OpenURL("itms-apps://itunes.apple.com/app/id"+IOSBundleID);
		}
#elif UNITY_WP8
		if(WP8AppID != "") {
			Application.OpenURL("zune:reviewapp?appid=app" + WP8AppID);
		}
#endif
    }
}
