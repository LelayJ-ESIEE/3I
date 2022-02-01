using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDD.Events;
using UnityEngine.UI;


public class HudManager : MonoBehaviour, IEventHandler
{
    [SerializeField] Text m_Score;
    [SerializeField] Text m_Time;

    public void SubscribeEvents()
    {
        EventManager.Instance.AddListener<GameStatisticsChangedEvent>(GameStatisticsChanged);
    }

    public void UnsubscribeEvents()
    {
        EventManager.Instance.RemoveListener<GameStatisticsChangedEvent>(GameStatisticsChanged);
    }

    private void OnEnable()
    {
        SubscribeEvents();
    }
    private void OnDisable()
    {
        UnsubscribeEvents();
    }

    void RefreshScoreAndTimeTexts(int score, float time)
    {
        m_Score.text = score.ToString();
        m_Time.text = time.ToString("N01");
    }

    #region Events' callbacks
    void GameStatisticsChanged(GameStatisticsChangedEvent e)
    {
        RefreshScoreAndTimeTexts(e.eScore, Mathf.Max(e.eTime,0));
    }
    #endregion

}
