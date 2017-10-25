using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPrizeReaction : Reaction
{
	public Prize prize;

	private Inventory inventory;

	protected override void SpecificInit ()
	{
		inventory = FindObjectOfType<Inventory> ();
	}

	protected override void ImmediateReaction ()
	{
		if (inventory != null) {
			inventory.AddItem (prize.item, prize.value);
		}
	}
}
