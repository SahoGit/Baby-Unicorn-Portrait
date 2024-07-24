 using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum iTweenActionType { SCALE = 0, ROTATE = 1, BLINKEYE = 2, ROTATE360 = 3, ROTATE360FLIPY = 4, SHAKE = 5, PUNCH = 6, BLINK = 7, HALFSCALE = 8, DOUBLESCALE = 9, STARANIMATION = 10, STARANIMATION1 = 11, SMALLSCALE = 12 }

public class ActionManager : MonoBehaviour
{
	#region Variables, Constants & Initializers

	public iTweenActionType actionType;

    #endregion

    #region Lifecycle methods

    // Use this for initialization
    void Start ()
	{
		switch (actionType) {
			case iTweenActionType.SCALE:
				iTweenScaleAction ();
				break;
			case iTweenActionType.ROTATE:
				iTweenRotateAction();
				break;
			case iTweenActionType.PUNCH:
				iTweenPunchAction();
				break;
			case iTweenActionType.SHAKE:
				iTweenShakeAction();
				break;
			case iTweenActionType.BLINKEYE:
				iTweenBlinkEyeAction (0.1f);
				break;
			case iTweenActionType.ROTATE360:
				iTweenRotate360Action();
				break;
            case iTweenActionType.ROTATE360FLIPY:
                iTweenRotate360FlipYAction();
                break;
            case iTweenActionType.BLINK:
                iTweenBlinkAction(0.2f);
                break;
            case iTweenActionType.HALFSCALE:
                iTweenHalfScaleAction();
                break;
            case iTweenActionType.DOUBLESCALE:
                iTweenDoubleScaleAction();
                break;
            case iTweenActionType.STARANIMATION:
                iTweenStarAction();
                break;
			case iTweenActionType.STARANIMATION1:
				iTweenStarAction1();
				break;
			case iTweenActionType.SMALLSCALE:
				iTweenSmallScale();
				break;
		}

	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

    #endregion

    #region Action Methods

    private void iTweenScaleAction()
    {
        Hashtable tweenParams = new Hashtable();
        tweenParams.Add("scale", new Vector3(1.1f, 1.1f, 0));
        tweenParams.Add("time", 0.5f);
        tweenParams.Add("easetype", iTween.EaseType.easeInBounce);
        tweenParams.Add("looptype", iTween.LoopType.pingPong);
        iTween.ScaleTo(gameObject, tweenParams);
    }



    private void iTweenHalfScaleAction()
    {
        Hashtable tweenParams = new Hashtable();
        tweenParams.Add("scale", new Vector3(1.02f, 1.02f, 0));
        tweenParams.Add("time", 0.5f);
        //tweenParams.Add("easetype", iTween.EaseType.easeInBounce);
        tweenParams.Add("looptype", iTween.LoopType.pingPong);
        iTween.ScaleTo(gameObject, tweenParams);
    }
    private void iTweenDoubleScaleAction()
    {
        Hashtable tweenParams = new Hashtable();
        tweenParams.Add("scale", new Vector3(2.05f, 2.05f, 0));
        tweenParams.Add("time", 0.5f);
        tweenParams.Add("easetype", iTween.EaseType.easeInBounce);
        tweenParams.Add("looptype", iTween.LoopType.pingPong);
        iTween.ScaleTo(gameObject, tweenParams);
    }
    private void iTweenStarAction()
    {
        Hashtable tweenParams = new Hashtable();
        tweenParams.Add("scale", new Vector3(0.75f, 0.75f, 0));
        tweenParams.Add("time", 0.5f);
        iTween.ScaleTo(gameObject, tweenParams);
    }
    private void iTweenStarAction1()
    {
        Hashtable tweenParams = new Hashtable();
        tweenParams.Add("scale", new Vector3(1.0f, 1.0f, 0));
        tweenParams.Add("time", 0.5f);
        iTween.ScaleTo(gameObject, tweenParams);
    }
    private void iTweenSmallScale()
	{
		Hashtable tweenParams = new Hashtable();
		tweenParams.Add("scale", new Vector3(0.85f, 0.85f, 0));
		tweenParams.Add("time", 0.5f);
		tweenParams.Add("easetype", iTween.EaseType.easeInBounce);
		tweenParams.Add("looptype", iTween.LoopType.pingPong);
		iTween.ScaleTo(gameObject, tweenParams);
	}
    private void iTweenRotateAction() {
		Hashtable tweenParams = new Hashtable();
		tweenParams.Add ("amount", new Vector3 (0f, 0f, -0.25f));
		tweenParams.Add ("time", 0.6f);
		tweenParams.Add ("easetype", iTween.EaseType.easeInOutQuad);
		tweenParams.Add ("looptype", iTween.LoopType.pingPong);
		iTween.RotateBy(gameObject, tweenParams);
	}

	private void iTweenShakeAction() {
		Hashtable tweenParams = new Hashtable();
		tweenParams.Add ("amount", new Vector3 (2.0f, 2.0f, 2.0f));
		tweenParams.Add ("time", 1.0f);
		tweenParams.Add ("easetype", iTween.EaseType.easeInCubic);
		tweenParams.Add ("looptype", iTween.LoopType.pingPong);
		iTween.ShakePosition(gameObject, tweenParams);
	}

	private void iTweenPunchAction() {
		Hashtable tweenParams = new Hashtable();
		tweenParams.Add ("amount", new Vector3 (0.25f, 0.25f, 0f));
		tweenParams.Add ("time", 1.0f);
		tweenParams.Add ("easetype", iTween.EaseType.easeInOutQuad);
		tweenParams.Add ("looptype", iTween.LoopType.loop);
		iTween.PunchPosition(gameObject, tweenParams);
	}

	private void iTweenRotate360Action() {
		Hashtable tweenParams = new Hashtable();
		tweenParams.Add ("amount", new Vector3 (0f, 0f, -1f));
		tweenParams.Add ("time", 0.8f);
		tweenParams.Add ("easetype", iTween.EaseType.linear);
		tweenParams.Add ("looptype", iTween.LoopType.loop);
		iTween.RotateBy(gameObject, tweenParams);
	}

    private void iTweenRotate360FlipYAction()
    {
        Hashtable tweenParams = new Hashtable();
        tweenParams.Add("amount", new Vector3(0f, -1f, 0f));
        tweenParams.Add("time", 0.8f);
        tweenParams.Add("easetype", iTween.EaseType.linear);
		tweenParams.Add("looptype", iTween.LoopType.loop);
        iTween.RotateBy(gameObject, tweenParams);
    }

    private void iTweenBlinkEyeAction(float time) {
		Hashtable tweenParams = new Hashtable();
		tweenParams.Add ("aplha", 1.0f);
		tweenParams.Add ("time", time);
		tweenParams.Add ("oncompletetarget", gameObject);
		tweenParams.Add ("oncomplete", "BlinkEye");
		iTween.ScaleTo(gameObject, tweenParams);
	}

	private void BlinkEye() {
		if (gameObject.GetComponent<RectTransform> () != null) {
			if (gameObject.GetComponent<RectTransform> ().localScale.x == 0) {
				gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (1, 1, 1);
				iTweenBlinkEyeAction (0.1f);
			} else {
				gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (0, 0, 0);
				int rand = Random.Range (2, 4);
				iTweenBlinkEyeAction (rand);
			}
		} else if (gameObject.GetComponent<Transform> () != null) {
			if (gameObject.transform.localScale.x == 0) {
				gameObject.transform.localScale = new Vector3 (1, 1, 1);
				iTweenBlinkEyeAction (0.1f);
			} else {
				gameObject.transform.localScale = new Vector3 (0, 0, 0);
				int rand = Random.Range (2, 4);
				iTweenBlinkEyeAction (rand);
			}
		}
	}

	private void iTweenBlinkAction(float time) {
		Hashtable tweenParams = new Hashtable();
		tweenParams.Add ("aplha", 1.0f);
		tweenParams.Add ("time", time);
		tweenParams.Add ("oncompletetarget", gameObject);
		tweenParams.Add ("oncomplete", "Blink");
		iTween.ScaleTo(gameObject, tweenParams);
	}

	private void Blink() {
		if (gameObject.GetComponent<RectTransform> () != null) {
			if (gameObject.GetComponent<RectTransform> ().localScale.x == 0) {
				gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (1, 1, 1);
				iTweenBlinkAction (0.2f);
			} else {
				gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (0, 0, 0);
				iTweenBlinkAction (0.2f);
			}
		} else if (gameObject.GetComponent<Transform> () != null) {
			if (gameObject.transform.localScale.x == 0) {
				gameObject.transform.localScale = new Vector3 (1, 1, 1);
				iTweenBlinkAction (0.2f);
			} else {
				gameObject.transform.localScale = new Vector3 (0, 0, 0);
				iTweenBlinkAction (0.2f);
			}
		}
	}

	#endregion

	#region Utility Methods

	public static void PauseAllInScene(GameObject gameObject) {
		iTween.Pause (gameObject, true);
	}

	public static void ResumeAllInScene(GameObject gameObject) {
		iTween.Resume (gameObject, true);
	}

	public static void StopAllInScene(GameObject gameObject) {
		iTween.Stop (gameObject, true);
	}

	#endregion
}

