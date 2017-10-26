using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStateControlReaction : Reaction {

	public State newState;

	public float fadeDuration = 1f;

	private SceneManager sceneManager;

	protected override void SpecificInit() {
		sceneManager = FindObjectOfType<SceneManager> ();	
	}

	protected override void ImmediateReaction() {
		sceneManager.SwitchState (newState, fadeDuration);	
	}
}
