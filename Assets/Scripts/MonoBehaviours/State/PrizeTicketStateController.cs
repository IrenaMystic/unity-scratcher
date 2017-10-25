using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeTicketStateController : State {

	private StateMachine stateMachine = new StateMachine ();

	public State prizeTicket;

	public bool loadOnStart = false;

	private void Start() {
		gameObject.SetActive (loadOnStart);

		if (loadOnStart) {
			Enter ();
		}
	}

	public void SwitchState(State newState) {
		stateMachine.ChangeState (newState);
	}

	public override void Enter ()
	{
		gameObject.SetActive (true);
		stateMachine.ChangeState (prizeTicket);	
	}

	public override void Execute ()
	{
	}

	public override void Exit ()
	{
		gameObject.SetActive (false);
	}
}
