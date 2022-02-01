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
	public int eScore { get; set; }
	public float eTime { get; set; }
}
#endregion


#region MenuManager Events
public class EscapeButtonClickedEvent : SDD.Events.Event
{
}
public class PlayButtonClickedEvent : SDD.Events.Event
{
}
public class ResumeButtonClickedEvent : SDD.Events.Event
{
}
public class MainMenuButtonClickedEvent : SDD.Events.Event
{
}
public class NextLevelButtonClickedEvent : SDD.Events.Event
{
}
#endregion

#region Ball events
public class BallHitAGameObjectEvent:SDD.Events.Event
{
	public GameObject eGameObject;
}
#endregion

/*
#region Coin Event
public class CoinHasBeenHitByPlayerEvent : SDD.Events.Event
{
	public Coin eCoin;
}
#endregion

#region Score Event
public class ScoreItemEvent : SDD.Events.Event
{
	public IScore eScore;
}
#endregion

#region Game Manager Additional Event
public class AskToGoToNextLevelEvent : SDD.Events.Event
{
}
public class ReplaySameLevelEvent:SDD.Events.Event
{

}
public class GoToNextLevelEvent : SDD.Events.Event
{
}
#endregion

#region LevelsManager Events
public class LevelHasBeenInstantiatedEvent : SDD.Events.Event
{
	public Level eLevel;
}
#endregion

#region Player
public class PlayerHasBeenHitEvent:SDD.Events.Event
{
}

public class PlayerReachedEndPointEvent:SDD.Events.Event
{ }
#endregion
#region DeathCollider
public class DeathColliderHasBeenHitEvent : SDD.Events.Event
{
}
#endregion
*/