using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactionCollection : MonoBehaviour {

	public Reaction[] reactions = new Reaction[0];

	private void Awake() {
		for (int i = 0; i < reactions.Length; i++) {
			reactions [i].Init ();
		}
	}

	public void React() {
		for (int i = 0; i < reactions.Length; i++) {
			reactions [i].React (this);
		}
	}

	public Reaction GetReactionOfType(Type reactionType) {
		for (int i = 0; i < reactions.Length; i++) {
			if (reactions [i].GetType() == reactionType) {
				return reactions [i];
			}
		}

		return null;
	}

	public void SetReactionOfType(Type reactionType, Reaction newReaction) {
		for (int i = 0; i < reactions.Length; i++) {
			if (reactions [i].GetType() == reactionType) {
				reactions [i] = newReaction;
				return;
			}
		}
	}
}
