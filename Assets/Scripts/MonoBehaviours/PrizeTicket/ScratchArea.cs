using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ScratchArea : MonoBehaviour
{
	public Sticker sticker;

	public GameObject element;

	public Color elementColor = new Color(0.79f, 0.79f, 0.79f);

	public int cubeNumber = 5;

	public int clearPercent = 50;

	public float maxDropTime = 1;

	public float xOffset = 20;

	public float offsetRadius = 300;

	private List<RectTransform> scratchElem;

	private float speed = 0;

	private int cleared = 0;

	private float clearArea = 0;

	private bool isCleared = false;

	void Start ()
	{
		Rect rect = ((RectTransform)transform).rect;
		float cubeWidth = rect.width / cubeNumber;
		float cubeHeight = rect.height / cubeNumber;

		speed = offsetRadius / maxDropTime;

		scratchElem = new List<RectTransform> ();
		for (int i = 0; i < cubeNumber; ++i) {
			for (int j = 0; j < cubeNumber; ++j) {
				RectTransform obj = (RectTransform)(((GameObject)Instantiate (element)).transform);
				obj.GetComponent<Image> ().color = elementColor;
				obj.sizeDelta = new Vector2 (cubeWidth, cubeHeight);
				obj.localPosition = new Vector2 (j * cubeWidth, -i * cubeHeight);
				obj.SetParent (transform, false);
				scratchElem.Add (obj);
			}
		}

		element.SetActive (false);

		clearArea = (Mathf.Pow (cubeNumber, 2) * clearPercent) / 100.0f;
	}

	void DropScratch (int idx)
	{
		Vector2 oldPos = scratchElem [idx].anchoredPosition;
		Vector2 newPos = Random.insideUnitCircle * offsetRadius;

		float dropTime = Vector2.Distance(oldPos, newPos) / speed;

		LeanTween.cancel (scratchElem [idx].gameObject);
		LeanTween.moveLocal (scratchElem [idx].gameObject, newPos, dropTime)
			.setEase(LeanTweenType.easeOutQuad)
			.setOnComplete (RemoveScratch)
			.setOnCompleteParam (idx);

		float delay = dropTime - dropTime / 3.0f;
		LeanTween.alpha (scratchElem [idx], 0, dropTime - delay).setDelay (delay);

		scratchElem [idx].GetComponent<Image> ().raycastTarget = false;
	}

	void RemoveScratch (object id)
	{
		scratchElem [(int)id].gameObject.SetActive (false);
	}

	public void ClearArea (Image obj)
	{
		DropScratch (scratchElem.IndexOf (obj.rectTransform));
		cleared++;

		if (!isCleared && cleared > clearArea) {
			isCleared = true;
			sticker.ActivateSticker ();
		}
	}
}
