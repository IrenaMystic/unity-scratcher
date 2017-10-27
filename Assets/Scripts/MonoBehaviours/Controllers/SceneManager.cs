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

		DisableInteraction ();

		fadeElement.FadeFromTo (1, 0, fadeDuration, EnableInteraction);
	}

	public void SwitchState (State newState)
	{
		SwitchState (newState, fadeDuration);
	}

	public void SwitchState (State newState, float duration)
	{
		pendingState = newState;

		DisableInteraction ();

		fadeElement.FadeTo (1, duration, ChangeState);
	}

	private void ChangeState ()
	{
		stateMachine.ChangeState (pendingState);

		pendingState = null;

		fadeElement.FadeTo (0, fadeDuration, EnableInteraction);
	}

	private void EnableInteraction ()
	{
		fadeElement.faderCanvasGroup.blocksRaycasts = false;
	}

	private void DisableInteraction ()
	{
		fadeElement.faderCanvasGroup.blocksRaycasts = true;
	}
}
