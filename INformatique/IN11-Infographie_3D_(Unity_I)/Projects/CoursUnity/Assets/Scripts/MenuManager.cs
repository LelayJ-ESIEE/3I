using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDD.Events;

public class MenuManager : MonoBehaviour,IEventHandler
{
    [SerializeField] GameObject m_MainMenuPanel;
    [SerializeField] GameObject m_VictoryPanel;
    [SerializeField] GameObject m_GameOverPanel;

    List<GameObject> m_AllPanels = new List<GameObject>();

    public void SubscribeEvents()
    {
        EventManager.Instance.AddListener<GameMenuEvent>(GameMenu);
        EventManager.Instance.AddListener<GamePlayEvent>(GamePlay);
        EventManager.Instance.AddListener<GameOverEvent>(GameOver);
        EventManager.Instance.AddListener<GameVictoryEvent>(GameVictory);
    }

    public void UnsubscribeEvents()
    {
        EventManager.Instance.RemoveListener<GameMenuEvent>(GameMenu);
        EventManager.Instance.RemoveListener<GamePlayEvent>(GamePlay);
        EventManager.Instance.RemoveListener<GameOverEvent>(GameOver);
        EventManager.Instance.RemoveListener<GameVictoryEvent>(GameVictory);
    }

    private void OnEnable()
    {
        SubscribeEvents();
    }
    private void OnDisable()
    {
        UnsubscribeEvents();
    }

    private void Awake()
    {
        m_AllPanels.AddRange(new GameObject[] { m_MainMenuPanel, m_VictoryPanel, m_GameOverPanel });
    }

    void SetPanel(GameObject panel)
    {
        m_AllPanels.ForEach(item => item.SetActive(panel == item));
    }

    #region Events' callbacks
    void GameMenu(GameMenuEvent e)
    {
        SetPanel(m_MainMenuPanel);
    }
    void GamePlay(GamePlayEvent e)
    {
        SetPanel(null);
    }

    void GameOver(GameOverEvent e)
    {
        SetPanel(m_GameOverPanel);
    }
    void GameVictory(GameVictoryEvent e)
    {
        SetPanel(m_VictoryPanel);
    }
    #endregion

    #region UI callbacks
    public void PlayButtonHasBeenClicked()
    {
        EventManager.Instance.Raise(new PlayButtonClickedEvent());
    }
    public void MenuButtonHasBeenClicked()
    {
        EventManager.Instance.Raise(new MainMenuButtonClickedEvent());
    }
    #endregion


}
