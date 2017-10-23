using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

[System.Serializable]
public class StickerEvent : UnityEvent<Sticker>
{
}

public class Sticker : MonoBehaviour
{	
	[HideInInspector] public int id;

	[HideInInspector] public StickerEvent OnCleared;

	public Image prizeImg;

	private Prize prize;

	private bool isFinalPrize;

	void Start ()
	{
		if (OnCleared == null)
			OnCleared = new StickerEvent ();	
	}

	public void Init(Prize newPrize, bool finalPrize) {
		prize = newPrize;
		isFinalPrize = finalPrize;
		prizeImg.sprite = prize.item.spriteBig;
	}

	public void ActivateSticker ()
	{
		if (isFinalPrize) {
			OnCleared.Invoke (this);
		}
	}
}
