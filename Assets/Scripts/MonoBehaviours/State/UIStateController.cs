using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStateController : MonoBehaviour
{
	private StateMachine stateMachine = new StateMachine ();

	public State startingState;

	public CanvasGroup faderCanvasGroup;

	public float fadeDuration = 1f;

	private bool isFading;

	void Start ()
	{
		faderCanvasGroup.alpha = 1;

		stateMachine.ChangeState (startingState);

		StartCoroutine (Fade (0f, fadeDuration));
	}

	public void SwitchState (State newState)
	{
		SwitchState (newState, fadeDuration);
	}

	public void SwitchState(State newState, float duration) {
		if (!isFading) {
			StartCoroutine (FadeAndSwitch (newState, duration));
		}
	}

	private IEnumerator FadeAndSwitch (State newState, float duration)
	{
		yield return StartCoroutine (Fade (1f, duration));

		stateMachine.ChangeState (newState);

		yield return StartCoroutine (Fade (0f, duration));
	}

	private IEnumerator Fade (float finalAlpha, float duration)
	{
		isFading = true;
		faderCanvasGroup.blocksRaycasts = true;

		float fadeSpeed = Mathf.Abs (faderCanvasGroup.alpha - finalAlpha) / duration;

		while (!Mathf.Approximately (faderCanvasGroup.alpha, finalAlpha)) {
			faderCanvasGroup.alpha = Mathf.MoveTowards (faderCanvasGroup.alpha, finalAlpha, fadeSpeed * Time.deltaTime);
			yield return null;
		}

		isFading = false;
		faderCanvasGroup.blocksRaycasts = false;
	}

}
