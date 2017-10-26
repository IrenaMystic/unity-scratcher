using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeTicketControllerState : State
{
	private PrizeTicketStateController prizeTicketStateController;

	void Awake () {
		prizeTicketStateController = GetComponent<PrizeTicketStateController>();
	}

	public override void Enter ()
	{
		prizeTicketStateController.GoToStartState();
	}

	public override void Execute ()
	{
	}

	public override void Exit ()
	{
		prizeTicketStateController.SwitchState(null);
	}
}
