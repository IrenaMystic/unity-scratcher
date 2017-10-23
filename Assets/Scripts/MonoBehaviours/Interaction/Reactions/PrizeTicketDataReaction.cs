using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeTicketDataReaction : Reaction {

	public PrizeCollection prizeCollection;

	private PrizeTicket prizeTicket;

	protected override void SpecificInit() {
		prizeTicket = FindObjectOfType<PrizeTicket> ();	
	}

	protected override void ImmediateReaction ()
	{
		prizeTicket.Init (prizeCollection);
	}
}
