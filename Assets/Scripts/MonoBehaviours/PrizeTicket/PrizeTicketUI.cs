using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

[RequireComponent(typeof(Interactable))]
public class PrizeTicketUI : MonoBehaviour
{
	public Prize prize;

	public Image prizeIcon;

	public Text prizeTitle;

	public Text prizeNameTxt;

	public Text doublePrizeTxt;

	public Image rays;

	public GameObject sparkles;

	[Header ("Buttons")]

	public Button doubleUp;

	public Button scratchAgain;

	public Button toMenu;

	private Interactable interactable;

	private RectTransform prizeNameContainer;

	private CanvasGroup prizeNameContainerCg;

	private Text doubleUpTxt;

	private bool isDoubledUp;

	void Awake ()
	{
		prizeNameContainer = (RectTransform)prizeNameTxt.transform.parent;
		prizeNameContainerCg = prizeNameTxt.transform.parent.GetComponent<CanvasGroup> ();
		doubleUpTxt = doubleUp.GetComponentInChildren<Text> ();
		interactable = GetComponent<Interactable> ();
	}

	public void ShowUI (Prize prize)
	{
		gameObject.SetActive (true);
		isDoubledUp = false;

		this.prize = prize;

		UpdateData ();

		AnimateUI ();
	}

	private void Init ()
	{
		ResetTween ();

		if (isDoubledUp) {
			prizeIcon.sprite = prize.item.spriteDouble;
			prizeNameTxt.text = Enum.GetName (typeof(ItemType), prize.item.type) + " x" + (2 * prize.value);
			prizeTitle.text = "Now you have";
			doubleUpTxt.text = "Continue";		
		} else {
			prizeIcon.sprite = prize.item.spriteBig;
			prizeNameTxt.text = Enum.GetName (typeof(ItemType), prize.item.type) + " x" + prize.value;
			prizeTitle.text = "You have won";
			doubleUpTxt.text = "DoubleUp";	
		}

		prizeIcon.rectTransform.localScale = Vector3.zero;
		doubleUp.transform.localScale = Vector3.zero;
		scratchAgain.transform.localScale = Vector3.zero;
		doublePrizeTxt.rectTransform.localScale = Vector3.zero;

		prizeNameContainerCg.alpha = 0;

		Vector2 pos = prizeNameContainer.anchoredPosition;
		pos.y -= 10;
		prizeNameContainer.anchoredPosition = pos;

		sparkles.SetActive (false);
		rays.gameObject.SetActive (false);
	}

	private void AnimateUI ()
	{
		Init ();

		LeanTween.scale (prizeIcon.rectTransform, new Vector3 (1.2f, 1.2f, 1.2f), 0.2f).setDelay (0.5f).setOnComplete (() => {
			LeanTween.scale (prizeIcon.rectTransform, new Vector3 (0.9f, 0.9f, 0.9f), 0.2f).setDelay (0.06f).setOnComplete (() => {
				LeanTween.scale (prizeIcon.rectTransform, Vector3.one, 0.2f).setDelay (0.06f).setOnComplete (() => {
					
					sparkles.SetActive (true);

					if (isDoubledUp) {
						rays.gameObject.SetActive (true);
						LeanTween.alpha (rays.rectTransform, 1, 0.2f);
						rays.SendMessage ("Rotate", SendMessageOptions.DontRequireReceiver);

						LeanTween.scale (doublePrizeTxt.rectTransform, Vector3.one, 0.2f);
					}

					LeanTween.value (prizeNameContainer.gameObject, 0, 1, 0.5f).setOnUpdate ((value) => {
						prizeNameContainerCg.alpha = value;
					});

					LeanTween.moveLocalY (prizeNameContainer.gameObject, prizeNameContainer.anchoredPosition.y + 15, 0.3f)
					.setOnComplete (() => {
							LeanTween.moveLocalY (prizeNameContainer.gameObject, prizeNameContainer.anchoredPosition.y - 5, 0.2f);
						LeanTween.scale (doubleUp.gameObject, Vector3.one, 0.3f).setDelay (0.1f);
						LeanTween.scale (scratchAgain.gameObject, Vector3.one, 0.3f).setDelay (0.1f);
					});
				});		
			});		
		});						
	}

	public void ScreenShown ()
	{
		toMenu.interactable = true;
	}

	private void ResetTween ()
	{
		LeanTween.cancel (prizeNameContainerCg.gameObject);
		LeanTween.cancel (scratchAgain.gameObject);
		LeanTween.cancel (prizeIcon.gameObject);
		LeanTween.cancel (doubleUp.gameObject);
	}

	public void DoubleUp ()
	{
		if (isDoubledUp) {
			toMenu.onClick.Invoke ();
		} else {
			isDoubledUp = true;

			UpdateData ();

			AnimateUI ();	
		}
	}

	private void UpdateData ()
	{
		AddPrizeReaction reaction = (AddPrizeReaction)interactable.GetDefaultReaction (typeof(AddPrizeReaction));
		reaction.prize = prize;
		interactable.SetDefaultReaction (typeof(AddPrizeReaction), reaction);
		interactable.Interact ();
	}
}
