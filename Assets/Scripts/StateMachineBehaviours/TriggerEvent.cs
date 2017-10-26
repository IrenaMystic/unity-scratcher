using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : StateMachineBehaviour
{
	public string trigger;

	public float delayTime = 0;

	private float startTime;

	private bool stateTriggered;

	override public void OnStateEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		stateTriggered = false;
		startTime = Time.time + delayTime;
	}

	override public void OnStateUpdate (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (!stateTriggered && Time.time >= startTime) {
			stateTriggered = true;
			animator.SetTrigger (trigger);
		}
	}
}
