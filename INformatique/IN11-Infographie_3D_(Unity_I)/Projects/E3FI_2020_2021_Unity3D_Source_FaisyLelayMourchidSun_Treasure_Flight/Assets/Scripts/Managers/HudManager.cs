using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SDD.Events;


public class HudManager : Manager<HudManager>
{
	[Header("HudManager")]
	#region Labels & Values
	[Header("Texts")]
	[SerializeField] private Text m_CoinCountText;
	[SerializeField] private Text m_SpeedText;
	#endregion

	#region Events' subscription
	public override void SubscribeEvents()
	{
		base.SubscribeEvents();

		EventManager.Instance.AddListener<PlayerMoveEvent>(PlayerMove);
	}


	public override void UnsubscribeEvents()
	{
		base.UnsubscribeEvents();

		EventManager.Instance.AddListener<PlayerMoveEvent>(PlayerMove);
	}
	#endregion

	#region Manager implementation
	protected override IEnumerator InitCoroutine()
	{
		yield break;
	}
	#endregion

	#region Callbacks to GameManager events
	protected override void GameStatisticsChanged(GameStatisticsChangedEvent e)
	{
		m_CoinCountText.text = e.eCoinPicked + "/" + e.eCoinTotal;
	}

	protected void PlayerMove(PlayerMoveEvent e)
	{
		m_SpeedText.text = e.velocity.magnitude.ToString();
	}
	#endregion
}
