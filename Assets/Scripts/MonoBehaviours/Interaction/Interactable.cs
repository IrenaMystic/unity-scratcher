using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

	public ReactionCollection dataReactionCollection;

	public ReactionCollection defaultReactionCollection;

	public Reaction GetInitReaction(Type reactionType) {
		return dataReactionCollection.GetReactionOfType (reactionType);
	}

	public void SetInitReaction(Type reactionType, Reaction newReaction) {
		dataReactionCollection.SetReactionOfType (reactionType, newReaction);
	}

	public Reaction GetDefaultReaction(Type reactionType) {
		return defaultReactionCollection.GetReactionOfType (reactionType);
	}

	public void SetDefaultReaction(Type reactionType, Reaction newReaction) {
		defaultReactionCollection.SetReactionOfType (reactionType, newReaction);
	}

	public void Interact() {
		if (dataReactionCollection != null) {
			dataReactionCollection.React ();
		}

		defaultReactionCollection.React ();
	}
}
