using UnityEngine;
using System.Collections;

public class ContinuousZRotation : MonoBehaviour {

	[Range (-1,1)]public int direction;

	public float time = 10;

	void Start () {
	
	}

	void OnEnable()
	{
		LeanTween.cancel (gameObject);
	}

	public void Rotate()
	{
		LeanTween.rotateAroundLocal (gameObject, Vector3.forward, Mathf.Sign(direction)*360, time)
			.setOnComplete (CompleteRotation);
	}

	void CompleteRotation()
	{
		Rotate ();
	}
}
