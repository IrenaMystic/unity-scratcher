using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

	public ReactionCollection defaultReactionCollection;

	public Reaction GetDefaultReaction(Type reactionType) {
		return defaultReactionCollection.GetReactionOfType (reactionType);
	}

	public void SetDefaultReaction(Type reactionType, Reaction newReaction) {
		defaultReactionCollection.SetReactionOfType (reactionType, newReaction);
	}

	public void Interact() {
		defaultReactionCollection.React ();
	}
}
