using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Interactable))]
public class PrizeTicket : MonoBehaviour {

	public const int numStickerSlots = 6;

	public GameObject stickerPrefab;

	public Transform grid;

	private Sticker[] stickers = new Sticker[numStickerSlots];

	private PrizeCollection prizeCollection;

	private List<Prize> additionalPrizes;

	private Prize finalPrize;

	private Interactable interactable;

	private int countFinalPrize = 0;

	void Awake() {
		interactable = GetComponent<Interactable> ();
	}

	void Start () {
		
	}

	public void Init(PrizeCollection collection) {
		if (collection != null) {
			prizeCollection = collection;
		}

		if (prizeCollection == null)
			return;

		GeneratePrizes ();

		GenerateStickers ();

		PopulateStickers ();
	}

	private void GeneratePrizes ()
	{
		List<IRandomizable> allPrizes = new List<IRandomizable> (prizeCollection.prizes);

		finalPrize = (Prize)Randomizable.GetRandomItem (allPrizes);
		allPrizes.Remove (finalPrize);

		additionalPrizes = new List<Prize> ();
		for (int i = 0; i < 3; ++i) {
			Prize temp = (Prize)Randomizable.GetRandomItem (allPrizes);
			Predicate<Prize> predicate = new Predicate<Prize> (a => a.id == temp.id); 
			additionalPrizes.Add (temp);

			int first = additionalPrizes.FindIndex (predicate);
			int last = additionalPrizes.FindLastIndex (predicate);

			if (first != last) {
				allPrizes.Remove (temp);
			}
		}
	}

	private void GenerateStickers ()
	{
		for (int i = 0; i < stickers.Length; i++) {
			if (stickers [i] != null) {
				DestroyImmediate (stickers [i].gameObject);
			}
		}

		stickers = new Sticker[numStickerSlots];

		int countStickers = 0;
		for (int i = 0; i < 2; ++i) {
			for (int j = 0; j < 3; ++j) {
				Transform obj = ((GameObject)Instantiate (stickerPrefab)).transform;
				obj.SetParent (grid, false);
				stickers[countStickers] = obj.GetComponent<Sticker> ();
				countStickers++;
			}
		}
	}

	private void PopulateStickers () 
	{
		int countOtherPrizes = 0;
		for (int i = 0; i < stickers.Length; ++i) {
			float chance = UnityEngine.Random.Range (0.0f, 1.0f);
			if ((chance > 0.5f && countFinalPrize < 3) || countOtherPrizes >= additionalPrizes.Count) {
				stickers [i].Init(finalPrize, true);
				countFinalPrize++;
			} else {
				stickers [i].Init(additionalPrizes [countOtherPrizes++], false);
			}

			stickers [i].OnCleared.AddListener (OnCleared);
		}
	}

	public void OnCleared (Sticker sticker)
	{
		countFinalPrize--;
		if (countFinalPrize == 0) {
			PrizeTicketUIDataReaction reaction = (PrizeTicketUIDataReaction) interactable.GetInitReaction (typeof(PrizeTicketUIDataReaction));
			reaction.SetPrize (finalPrize);
			interactable.SetInitReaction (typeof(PrizeTicketDataReaction), reaction);
			interactable.Interact ();
		}
	}

}
