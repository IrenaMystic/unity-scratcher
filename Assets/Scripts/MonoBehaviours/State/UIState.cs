using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIState : State
{
	public override void Enter ()
	{
		gameObject.SetActive (true);
	}

	public override void Execute ()
	{
		
	}

	public override void Exit ()
	{
		gameObject.SetActive (false);
	}
}
