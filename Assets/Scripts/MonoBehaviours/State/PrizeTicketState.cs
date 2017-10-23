using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeTicketState : State {

	public float delay = 0.5f;

	void Start () {
		
	}
		
	public override void Enter ()
	{
		gameObject.SetActive (true);
	}

	public override void Execute ()
	{
		
	}

	public override void Exit ()
	{
		StartCoroutine (Deactivate ());
	}

	private IEnumerator Deactivate() {
		yield return new WaitForSeconds (delay);

		gameObject.SetActive (false);
	}
}
