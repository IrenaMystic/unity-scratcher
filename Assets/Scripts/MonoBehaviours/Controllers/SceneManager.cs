using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
	private StateMachine stateMachine = new StateMachine ();

	public State startingState;

	public FadeUIElement fadeElement;

	public float fadeDuration = 1f;

	private State pendingState;

	void Start ()
	{
		stateMachine.ChangeState (startingState);
		fadeElement.FadeFromTo (1, 0, fadeDuration, null);
	}

	public void SwitchState (State newState)
	{
		SwitchState (newState, fadeDuration);
	}

	public void SwitchState(State newState, float duration) {
		pendingState = newState;
		fadeElement.FadeTo (1, duration, true, ChangeState);
	}

	private void ChangeState() {
		stateMachine.ChangeState (pendingState);
		pendingState = null;
		fadeElement.FadeTo (0, fadeDuration, true, null);
	}
}
