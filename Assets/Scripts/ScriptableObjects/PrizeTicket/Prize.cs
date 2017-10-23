using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prize : ScriptableObject, IRandomizable {
	public Item item;
	public int id;
	public int value;
	public int weight;

	public int GetWeight() {
		return weight;
	}
}
