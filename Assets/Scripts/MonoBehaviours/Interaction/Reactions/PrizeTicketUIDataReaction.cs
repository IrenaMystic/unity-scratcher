using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeTicketUIDataReaction : Reaction {

	public PrizeTicketUIState prizeTicketUI;

	private Prize prize;

	public void SetPrize(Prize prize) {
		this.prize = prize;
	}

	protected override void ImmediateReaction ()
	{
		prizeTicketUI.Init (prize);
	}
}
