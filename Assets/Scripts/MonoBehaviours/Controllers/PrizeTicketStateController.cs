using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeTicketStateController : MonoBehaviour
{
	public State prizeTicket;

	public bool loadOnStart = false;

	private StateMachine stateMachine = new StateMachine ();

	private void Start ()
	{
		if (loadOnStart) {
			StartCoroutine (LateStart ());
		}
	}

	private IEnumerator LateStart ()
	{
		yield return null;
		GoToStartState ();
	}

	public void SwitchState (State newState)
	{
		stateMachine.ChangeState (newState);
	}

	public void GoToStartState ()
	{
		SwitchState (prizeTicket);
	}
}
