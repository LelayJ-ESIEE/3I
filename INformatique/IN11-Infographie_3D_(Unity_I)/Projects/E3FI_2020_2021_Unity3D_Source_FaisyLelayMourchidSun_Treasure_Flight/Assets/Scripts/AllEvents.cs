using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDD.Events;

#region GameManager Events
public class GameMenuEvent : SDD.Events.Event
{
}
public class GamePlayEvent : SDD.Events.Event
{
}
public class GamePauseEvent : SDD.Events.Event
{
}
public class GameResumeEvent : SDD.Events.Event
{
}
public class GameOverEvent : SDD.Events.Event
{
}
public class GameVictoryEvent : SDD.Events.Event
{
}
public class GameStatisticsChangedEvent : SDD.Events.Event
{
	public int eCoinPicked { get; set; }
	public int eCoinTotal { get; set; }
}
#endregion

#region MenuManager Events
public class EscapeButtonClickedEvent : SDD.Events.Event
{
}
public class PlayButtonClickedEvent : SDD.Events.Event
{
}

public class DemoButtonClickedEvent : SDD.Events.Event
{
}
	public class ResumeButtonClickedEvent : SDD.Events.Event
{
}
public class MainMenuButtonClickedEvent : SDD.Events.Event
{
}
#endregion

#region Player Events
public class PlayerCollisonEvent:SDD.Events.Event
{
	public Transform playerTransform;
	public Rigidbody playerRigidbody;
	public float hpLeft;
}

public class PlayerMoveEvent : SDD.Events.Event
{
	public Vector3 velocity;
}

public class PlayerCrashEvent : SDD.Events.Event
{
}

public class PlayerResetEvent : SDD.Events.Event
{
	public Transform playerTransform;
	public Rigidbody playerRigidbody;
}

public class PlayerPressPauseEvent : SDD.Events.Event
{
}

public class CollectItemEvent : SDD.Events.Event
{
	public Collectible item;
}
#endregion