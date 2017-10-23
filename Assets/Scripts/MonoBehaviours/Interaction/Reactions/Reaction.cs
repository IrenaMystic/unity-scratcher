using UnityEngine;
using System;

public class Reaction : MonoBehaviour
{
	public void Init ()
	{
		SpecificInit ();
	}

	public void React (MonoBehaviour monoBehaivour)
	{
		ImmediateReaction ();
	}

	protected virtual void SpecificInit ()
	{
	}

	protected virtual void ImmediateReaction ()
	{
	}
}
