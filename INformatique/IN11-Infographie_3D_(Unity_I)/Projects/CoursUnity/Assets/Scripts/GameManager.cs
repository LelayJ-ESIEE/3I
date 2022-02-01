using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDD.Events;
public enum GameState { menu,play,pause,resume,goToNextLevel,victory,gameover}

public class GameManager : MonoBehaviour, IEventHandler
{

    private static GameManager m_Instance;
    public static GameManager Instance
    {
        get { return m_Instance; }
    }

    GameState m_State;
    public bool IsPlaying { get { return m_State == GameState.play; } }

    int m_Score;
    [SerializeField] int m_ScoreToVictory;

    float m_CountDown;
    [SerializeField] float m_CountDownStartValue;


    public void SubscribeEvents()
    {
        EventManager.Instance.AddListener<PlayButtonClickedEvent>(PlayButtonClicked);
        EventManager.Instance.AddListener<MainMenuButtonClickedEvent>(MainMenuButtonClicked);
        EventManager.Instance.AddListener<BallHitAGameObjectEvent>(BallHitAGameObject);
    }

    public void UnsubscribeEvents()
    {
        EventManager.Instance.RemoveListener<PlayButtonClickedEvent>(PlayButtonClicked);
        EventManager.Instance.RemoveListener<MainMenuButtonClickedEvent>(MainMenuButtonClicked);
        EventManager.Instance.RemoveListener<BallHitAGameObjectEvent>(BallHitAGameObject);
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
        if (!m_Instance) m_Instance = this;
        else Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        ChangeState(GameState.menu);
    }

    private void Update()
    {
        if(IsPlaying)
        {
            m_CountDown -= Time.deltaTime;
            SetStatistics(m_Score, m_CountDown);
            if(m_CountDown<=0)
            {
                ChangeState(GameState.gameover);
            }
        }
    }

    void IncrementScore(int increment)
    {
        SetStatistics(m_Score + increment, m_CountDown);
        if (m_Score >= m_ScoreToVictory)
            ChangeState(GameState.victory);
    }

    void SetStatistics(int score,float countDown)
    {
        m_CountDown = countDown;
        m_Score = score;
        EventManager.Instance.Raise(new GameStatisticsChangedEvent() { eScore = m_Score, eTime = m_CountDown });
    }

    void InitGame()
    {
        SetStatistics(0, m_CountDownStartValue);
    }

    void ChangeState(GameState targetState)
    {
        m_State = targetState;

        switch (m_State)
        {
            case GameState.menu:
                SetStatistics(0, m_CountDownStartValue);
                EventManager.Instance.Raise(new GameMenuEvent());
                break;
            case GameState.play:
                InitGame();
                EventManager.Instance.Raise(new GamePlayEvent());
                break;
            case GameState.pause:
                break;
            case GameState.resume:
                break;
            case GameState.goToNextLevel:
                break;
            case GameState.victory:
                EventManager.Instance.Raise(new GameVictoryEvent());
                break;
            case GameState.gameover:
                EventManager.Instance.Raise(new GameOverEvent());
                break;
            default:
                break;
        }
    }

    #region Events' callbacks
    void PlayButtonClicked(PlayButtonClickedEvent e)
    {
        ChangeState(GameState.play);
    }

    void MainMenuButtonClicked(MainMenuButtonClickedEvent e)
    {
        ChangeState(GameState.menu);
    }

    void BallHitAGameObject(BallHitAGameObjectEvent e)
    {
        if (!IsPlaying) return;

        IScore score = e.eGameObject.GetComponentInChildren<IScore>();
        if (score != null) IncrementScore(score.Score);
    }
    #endregion

}
