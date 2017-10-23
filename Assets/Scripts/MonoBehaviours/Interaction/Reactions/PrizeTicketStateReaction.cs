using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeTicketStateReaction : Reaction 
{
	public State newState;

	private PrizeTicketStateController stateController;

	protected override void SpecificInit() {
		stateController = FindObjectOfType<PrizeTicketStateController> ();	
	}

	protected override void ImmediateReaction() {
		stateController.SwitchState (newState);	
	}

}
