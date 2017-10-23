using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeUIElement : MonoBehaviour
{
	public CanvasGroup faderCanvasGroup;

	private bool isFading;

	void Start ()
	{
		
	}

	public void Fade (float alpha, float fadeDuration)
	{
		Fade (alpha, fadeDuration, null);
	}

	public void Fade (float alpha, float fadeDuration, Action callback)
	{
		if (!isFading) {
			faderCanvasGroup.alpha = (alpha == 1) ? 0 : 1;
			StartCoroutine (DoFade (alpha, fadeDuration, callback));
		}
	}

	private IEnumerator DoFade (float alpha, float fadeDuration, Action callback)
	{
		isFading = true;

		float fadeSpeed = Mathf.Abs (faderCanvasGroup.alpha - alpha) / fadeDuration;

		while (!Mathf.Approximately (faderCanvasGroup.alpha, alpha)) {
			faderCanvasGroup.alpha = Mathf.MoveTowards (faderCanvasGroup.alpha, alpha, fadeSpeed * Time.deltaTime);
			yield return null;
		}

		isFading = false;

		if (callback != null) {
			callback ();
		}
	}

}
