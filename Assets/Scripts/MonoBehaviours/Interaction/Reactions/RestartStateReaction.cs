using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartStateReaction : Reaction {

	public State newState;

	protected override void ImmediateReaction() {
		newState.Exit ();	
		newState.Enter ();	
	}
}
