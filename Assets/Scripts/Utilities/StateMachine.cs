using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
	private State currentState;

	private State previousState;

	public void ChangeState (State newState)
	{
		if (this.currentState != null) {
			this.currentState.Exit ();
		}

		this.previousState = this.currentState;
		this.currentState = newState;
		if (this.currentState != null) {
			this.currentState.Enter ();
		}
	}

	public void ExecuteStateUpdate ()
	{
		if (this.currentState != null) {
			this.currentState.Execute ();
		}
	}

	public void SwitchToPreviousState ()
	{
		if (this.currentState != null) {
			this.currentState.Exit ();
		}

		this.currentState = previousState;
		if (this.currentState != null) {
			this.currentState.Enter ();
		}
	}
}
