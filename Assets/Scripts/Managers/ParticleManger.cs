using UnityEngine;
using System.Collections;

public class ParticleManger : MonoBehaviour {

	public GameObject StarParticle;
	public GameObject pointinParticle;
	public GameObject trashParticle;


	private static ParticleManger _instance;

	public static ParticleManger instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = GameObject.FindObjectOfType<ParticleManger>();

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


	#region Utility Methods 

	private void MoveAction(GameObject obj,RectTransform pos,float time,iTween.EaseType easetype)
	{
		Hashtable tweenParams = new Hashtable();
		tweenParams.Add ("x", pos.position.x);
		tweenParams.Add ("y", pos.position.y);
		tweenParams.Add ("time", time);
		tweenParams.Add ("easetype", easetype);
		iTween.MoveTo (obj, tweenParams);
	}
		
	public void showStarParticle(GameObject obj) {
		SoundManager.instance.PlaySparkleSound ();
		GameObject temp	= (GameObject)Instantiate (StarParticle, obj.transform.position, Quaternion.identity);
		Destroy (temp, 0.8f);
	}

	public void showPointingParticle(GameObject obj) {
		SoundManager.instance.PlaySparkleSound ();
		GameObject temp	= (GameObject)Instantiate (pointinParticle, obj.transform.position, Quaternion.identity);
		Destroy (temp, 2.0f);
	}

	public void showTrashParticle(GameObject obj) {
		GameObject temp	= (GameObject)Instantiate (trashParticle, obj.transform.position, Quaternion.identity);
		Destroy (temp, 1.5f);
	}


		
	#endregion
}
