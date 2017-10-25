using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeTicketUIState : State
{
	public FadeUIElement fadeElement;

	public float fadeDuration;

	private PrizeTicketUI prizeTicketUI;

	private Prize prize;

	void Awake ()
	{
		prizeTicketUI = GetComponentInChildren<PrizeTicketUI> ();	
	}

	void Start ()
	{
	}

	public void Init (Prize prize)
	{
		this.prize = prize;
	}

	public override void Enter ()
	{
		gameObject.SetActive (true);
		prizeTicketUI.ShowUI (this.prize);
		fadeElement.Fade (1, fadeDuration, prizeTicketUI.ScreenShown);
	}

	public override void Execute ()
	{
	}

	public override void Exit ()
	{
		gameObject.SetActive (false);
	}
}
