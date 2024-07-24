using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	#region Variables, Constants & Initializers

	public bool isTesting;

	public AudioSource backgroundLoop;

	public AudioSource dryer;
	public AudioSource rubbingLoop;
	public AudioSource scanningLoop;
	public AudioSource showerLoop;
	public AudioSource brushingLoop;
	public AudioSource soapLoop;

    public AudioClip shuffleSound;
    public AudioClip buttonClick;
    public AudioClip catSound;
	public AudioClip catCryingSound;
	public AudioClip toolComesSound;
	public AudioClip toolGoesSound;
	public AudioClip popupOpenSound;
	public AudioClip popupCloseSound;
	public AudioClip trashSound;
	public AudioClip sparkleSound;
	public AudioClip scannerSound;
	public AudioClip collisionSound;
	public AudioClip biteSound;
	public AudioClip [] girlsSound;
	public AudioClip dogSound;
	public AudioClip dogCryingSound;
	public AudioClip beepSound;
	public AudioClip warningSound;
	public AudioClip injectionSound;
	public AudioClip medicineSound;
	public AudioClip stampSound;
	public AudioClip cameraSound;
	public AudioClip levelCompletedSound;
	public AudioClip dropSound;
	public AudioClip insectKillingSound;
    public AudioClip shampooSound;
    public AudioClip germLaugh;
    public AudioClip goodJob;

    public AudioClip sideBtn;
    public AudioClip playbtn;
    public AudioClip titleDrop;
    public AudioClip alarmClock;
    public bool showDebugLogs;

	// persistant singleton
    private static SoundManager _instance;

	#endregion
	
	#region Lifecycle methods

    public static SoundManager instance
	{
		get
		{
			if(_instance == null)
			{
                _instance = GameObject.FindObjectOfType<SoundManager>();

				//Tell unity not to destroy this object when loading a new scene!
				DontDestroyOnLoad(_instance.gameObject);
			}
			
			return _instance;
		}
	}
	
	void Awake() 
	{
		//Debug.Log("Awake Called");

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

	#endregion

	#region Utility Methods 

	public void SetBackgroundMusicVolume(float value) {
		backgroundLoop.volume = value;
	}

	public void SetBackgroundMusicPitch(float value) {
		backgroundLoop.pitch = value;
    }

    public void PlaySideBtnSound()
    {
        if (PlayerPrefs.GetInt("SoundContoller") == 1)
        {
            if (sideBtn)
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(sideBtn);
            }
        }
            
    }

    public void PlayPlayBtnSound()
    {
        if (PlayerPrefs.GetInt("SoundContoller") == 1)
        {
            if (playbtn)
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(playbtn);
            }
        }
    }

    public void PlayTitleDropSound()
    {
        if (PlayerPrefs.GetInt("SoundContoller") == 1)
        {
            if (titleDrop)
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(titleDrop);
            }
        }
    }

    public void PlayAlarmClockSound()
    {
        if (PlayerPrefs.GetInt("SoundContoller") == 1)
        {
            if (alarmClock)
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(alarmClock);
            }
        }
    }

    public void PlayButtonClickSound()
    {
        if (PlayerPrefs.GetInt("SoundContoller") == 1)
        {
            if (buttonClick)
			{
				gameObject.GetComponent<AudioSource>().PlayOneShot(buttonClick);
            }
        }
    }

    public void PlayShuffleSound()
    {
        if (PlayerPrefs.GetInt("SoundContoller") == 1)
		{
            if (shuffleSound)
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(shuffleSound);
            }
        }
            
    }
    public void PlayCatSound()
    {
        if (PlayerPrefs.GetInt("SoundContoller") == 1)
		{
            if (catSound)
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(catSound);
            }
        }

    }

    public void PlayGermSound()
    {
        if (PlayerPrefs.GetInt("SoundContoller") == 1)
        {
            if (germLaugh)
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(germLaugh);
            }
        }
    }

    public void PlayGoodJobSound()
    {
        if (PlayerPrefs.GetInt("SoundContoller") == 1)
        {
            if (goodJob)
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(goodJob);
            }
        }
    }
    public void PlayCatCryingSound() {
        if (PlayerPrefs.GetInt("SoundContoller") == 1)
        {
            if (catCryingSound)
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(catCryingSound);
            }
        }
	}

	public void PlayToolComesSound() {
        if (PlayerPrefs.GetInt("SoundContoller") == 1)
        {
            if (toolComesSound)
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(toolComesSound);
            }
        }
	}

	public void PlayToolGoesSound() {
        if (PlayerPrefs.GetInt("SoundContoller") == 1)
        {
            if (toolGoesSound)
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(toolGoesSound);
            }
        }
	}

	public void PlayPopupOpenGoesSound() {
        if (PlayerPrefs.GetInt("SoundContoller") == 1)
        {
            if (popupOpenSound)
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(popupOpenSound);
            }
        }
	}

	public void PlayPopupCloseSound() {
        if (PlayerPrefs.GetInt("SoundContoller") == 1)
        {
            if (popupCloseSound)
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(popupCloseSound);
            }
        }
	}

	public void PlayTrashSound() {
        if (PlayerPrefs.GetInt("SoundContoller") == 1)
        {
            if (trashSound)
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(trashSound, 0.5f);
            }
        }
	}

	public void PlaySparkleSound() {
        if (PlayerPrefs.GetInt("SoundContoller") == 1)
        {
            if (sparkleSound)
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(sparkleSound);
            }
        }
	}

	public void PlayScannerSound() {
        if (PlayerPrefs.GetInt("SoundContoller") == 1)
        {
            if (scannerSound)
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(scannerSound);
            }
        }
	}

	public void PlayCollisionSound() {
        if (PlayerPrefs.GetInt("SoundContoller") == 1)
        {
            if (collisionSound)
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(collisionSound);
            }
        }
	}

	public void PlayBiteSound() {
        if (PlayerPrefs.GetInt("SoundContoller") == 1)
        {
            if (biteSound)
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(biteSound, 0.5f);
            }
        }
	}

	public void PlayGirlSound() {
		int i = Random.Range (0, girlsSound.Length);
        if (PlayerPrefs.GetInt("SoundContoller") == 1)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(girlsSound[i]);
        }

	}

	public void PlayDogSound() {
        if (PlayerPrefs.GetInt("SoundContoller") == 1)
        {
            if (dogSound)
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(dogSound);
            }
        }
	}

	public void PlayBeepSound() {
        if (PlayerPrefs.GetInt("SoundContoller") == 1)
        {
            if (beepSound)
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(beepSound);
            }
        }
	}

	public void playWarningSound() {
        if (PlayerPrefs.GetInt("SoundContoller") == 1)
        {
            if (warningSound)
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(warningSound);
            }
        }
	}

	public void playInjectionSound() {
        if (PlayerPrefs.GetInt("SoundContoller") == 1)
        {
            if (injectionSound)
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(injectionSound);
            }
        }
	}

	public void playmedicineSound() {
        if (PlayerPrefs.GetInt("SoundContoller") == 1)
        {
            if (medicineSound)
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(medicineSound);
            }
        }
	}

	public void playstampSound() {
        if (PlayerPrefs.GetInt("SoundContoller") == 1)
        {
            if (stampSound)
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(stampSound);
            }
        }
	}

	public void playcameraSound() {
        if (PlayerPrefs.GetInt("SoundContoller") == 1)
        {
            if (cameraSound)
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(cameraSound);
            }
        }
	}

	public void playLevelCompletedSound() {
        if (PlayerPrefs.GetInt("SoundContoller") == 1)
        {
            if (levelCompletedSound)
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(levelCompletedSound);
            }
        }
	}

	public void playDropSound() {
        if (PlayerPrefs.GetInt("SoundContoller") == 1)
        {
            if (dropSound)
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(dropSound);
            }
        }
	}

	public void PlayInsectKillingSound() {
        if (PlayerPrefs.GetInt("SoundContoller") == 1)
        {
            if (insectKillingSound)
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(insectKillingSound);
            }
        }
	}

	public void PlayShampooSound() {
        if (PlayerPrefs.GetInt("SoundContoller") == 1)
        {
            if (shampooSound)
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(shampooSound);
            }
        }
	}


	public void PlayDryerLoop(bool enable) {
        if (PlayerPrefs.GetInt("SoundContoller") == 1)
        {
            if (dryer && enable)
            {
                if (!dryer.isPlaying)
                    dryer.Play();
            }
            else
            {
                dryer.Stop();
            }
        }
	}

	public void PlayRubbingLoop(bool enable) {
        if (PlayerPrefs.GetInt("SoundContoller") == 1)
        {
            if (rubbingLoop && enable)
            {
                if (!rubbingLoop.isPlaying)
                    rubbingLoop.Play();
            }
            else
            {
                rubbingLoop.Stop();
            }
        }
	}

	public void PlayscanningLoop(bool enable) {
        if (PlayerPrefs.GetInt("SoundContoller") == 1)
        {
            if (scanningLoop && enable)
            {
                if (!scanningLoop.isPlaying)
                    scanningLoop.Play();
            }
            else
            {
                scanningLoop.Stop();
            }
        }
	}

	public void PlayBrushingLoop(bool enable) {
        if (PlayerPrefs.GetInt("SoundContoller") == 1)
        {
            if (brushingLoop && enable)
            {
                if (!brushingLoop.isPlaying)
                    brushingLoop.Play();
            }
            else
            {
                brushingLoop.Stop();
            }
        }
	}

	public void PlayShowerLoop(bool enable) {
        if (PlayerPrefs.GetInt("SoundContoller") == 1)
        {
            if (showerLoop && enable)
            {
                if (!showerLoop.isPlaying)
                    showerLoop.Play();
            }
            else
            {
                showerLoop.Stop();
            }
        }
	}

	public void PlaySoapLoop(bool enable) {
        if (PlayerPrefs.GetInt("SoundContoller") == 1)
        {
            if (soapLoop && enable)
            {
                if (!soapLoop.isPlaying)
                    soapLoop.Play();
            }
            else
            {
                soapLoop.Stop();
            }
        }
	}


	#endregion

	#region Callback Methods 


	#endregion
}
