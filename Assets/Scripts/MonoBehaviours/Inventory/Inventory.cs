using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
	public Image[] itemImages = new Image[numItemSlots];
	public Text[] itemTexts = new Text[numItemSlots];
	public Item[] items = new Item[numItemSlots];
	public int[] itemValues = new int[numItemSlots];

	public const int numItemSlots = 4;

	void Awake() {
		InitInventory ();
	}

	private void InitInventory() {
		for (int i = 0; i < numItemSlots; i++) {
			itemImages [i].sprite = items [i].sprite;
			itemImages [i].preserveAspect = true;
			itemTexts [i].text = itemValues[i].ToString();
		}
	}

	public void AddItem (Item newItem, int addValue)
	{
		for (int i = 0; i < numItemSlots; i++) {
			if (items [i].type == newItem.type) {
				itemValues [i] += addValue;
				itemTexts [i].text = itemValues[i].ToString();
			}
		}
	}

	public void RemoveItem (Item removeItem, int subtractValue)
	{
		for (int i = 0; i < numItemSlots; i++) {
			if (items [i].type == removeItem.type) {
				itemValues[i] -= subtractValue;
				itemTexts [i].text = itemValues[i].ToString();
				return;
			}
		}
	}
}
