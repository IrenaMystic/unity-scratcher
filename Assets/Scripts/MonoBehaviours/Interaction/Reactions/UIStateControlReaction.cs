using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStateControlReaction : Reaction {

	public State newState;

	public float fadeDuration = 1f;

	private UIStateController stateController;

	protected override void SpecificInit() {
		stateController = FindObjectOfType<UIStateController> ();	
	}

	protected override void ImmediateReaction() {
		stateController.SwitchState (newState, fadeDuration);	
	}
}
