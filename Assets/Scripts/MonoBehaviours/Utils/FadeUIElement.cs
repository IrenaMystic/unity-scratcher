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

	public void FadeFromTo (float fromAlpha, float toAlpha, float fadeDuration, Action callback)
	{
		FadeFromTo (fromAlpha, toAlpha, fadeDuration, false, callback);
	}

	public void FadeFromTo (float fromAlpha, float toAlpha, float fadeDuration, bool changeRaycasts, Action callback)
	{
		faderCanvasGroup.alpha = fromAlpha;
		FadeTo (toAlpha, fadeDuration, changeRaycasts, callback);
	}

	public void FadeTo (float alpha, float fadeDuration)
	{
		FadeTo (alpha, fadeDuration, false, null);
	}

	public void FadeTo (float alpha, float fadeDuration, bool changeRaycasts, Action callback)
	{
		if (!isFading) {
			StartCoroutine (DoFade (alpha, fadeDuration, changeRaycasts, callback));
		}
	}

	private IEnumerator DoFade (float alpha, float fadeDuration, bool changeRaycasts, Action callback)
	{
		isFading = true;
		if (changeRaycasts) {
			faderCanvasGroup.blocksRaycasts = true;
		}

		float fadeSpeed = Mathf.Abs (faderCanvasGroup.alpha - alpha) / fadeDuration;

		while (!Mathf.Approximately (faderCanvasGroup.alpha, alpha)) {
			faderCanvasGroup.alpha = Mathf.MoveTowards (faderCanvasGroup.alpha, alpha, fadeSpeed * Time.deltaTime);
			yield return null;
		}

		isFading = false;
		if (changeRaycasts) {
			faderCanvasGroup.blocksRaycasts = false;
		}

		if (callback != null) {
			callback ();
		}
	}

}
