using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SDD.Events;
using UnityEngine.UI;


public enum GameState { gameMenu,gamePlay,gamePause,gameOver,gameVictory}

public class GameManager : Manager<GameManager> {

	//Game State
	private GameState m_GameState;
	private InputSettings controls;
	public bool IsPlaying { get { return m_GameState == GameState.gamePlay; } }

	public RawImage fadeAnim;
	public RawImage crash;
	public AudioSource coinPickUp;
	// TIME SCALE
	private float m_TimeScale;
	public float TimeScale { get { return m_TimeScale; } }
	void SetTimeScale(float newTimeScale)
	{
		m_TimeScale = newTimeScale;
		Time.timeScale = m_TimeScale;
	}

	//Collectibles
	HashSet<GameObject> ActiveCoins;
	private int m_CoinTotal;
	private int m_CoinPicked;
	public int Coins {
		get { return m_CoinPicked; }
		set
		{
			m_CoinPicked = value;
		}
	}

	void IncrementCoins(int increment)
	{
		SetCoins(m_CoinPicked + increment);
	}

	void SetCoins(int coins)
	{
		Coins = coins;
		EventManager.Instance.Raise(new GameStatisticsChangedEvent() { eCoinPicked = m_CoinPicked, eCoinTotal = m_CoinTotal });
	}

	
	#region Events' subscription
	public override void SubscribeEvents()
	{
		base.SubscribeEvents();

		//PlayerController
		EventManager.Instance.AddListener<PlayerCollisonEvent>(PlayerCollision);
		EventManager.Instance.AddListener<PlayerResetEvent>(PlayerReset);
		EventManager.Instance.AddListener<PlayerPressPauseEvent>(PausePressed);

		//MainMenuManager
		EventManager.Instance.AddListener<MainMenuButtonClickedEvent>(MainMenuButtonClicked);
		EventManager.Instance.AddListener<PlayButtonClickedEvent>(PlayButtonClicked);
		EventManager.Instance.AddListener<DemoButtonClickedEvent>(DemoButtonClicked);


		EventManager.Instance.AddListener<ResumeButtonClickedEvent>(ResumeButtonClicked);
		EventManager.Instance.AddListener<EscapeButtonClickedEvent>(EscapeButtonClicked);		

		//Score Item
		EventManager.Instance.AddListener<CollectItemEvent>(CollectibleHasBeenTaken);
	}

	public override void UnsubscribeEvents()
	{
		base.UnsubscribeEvents();

		//PlayerController
		EventManager.Instance.RemoveListener<PlayerCollisonEvent>(PlayerCollision);
		EventManager.Instance.RemoveListener<PlayerResetEvent>(PlayerReset);
		EventManager.Instance.RemoveListener<PlayerPressPauseEvent>(PausePressed);

		//MainMenuManager
		EventManager.Instance.RemoveListener<MainMenuButtonClickedEvent>(MainMenuButtonClicked);
		EventManager.Instance.RemoveListener<PlayButtonClickedEvent>(PlayButtonClicked);
		EventManager.Instance.RemoveListener<DemoButtonClickedEvent>(DemoButtonClicked);
		EventManager.Instance.RemoveListener<ResumeButtonClickedEvent>(ResumeButtonClicked);
		EventManager.Instance.RemoveListener<EscapeButtonClickedEvent>(EscapeButtonClicked);

		//Score Item
		EventManager.Instance.RemoveListener<CollectItemEvent>(CollectibleHasBeenTaken);
	}
	#endregion

	#region Manager implementation
	List<Transform> SpawnPoints;

	override protected void Awake()
    {
		base.Awake();
		DontDestroyOnLoad(this.gameObject);
    }

    protected override IEnumerator InitCoroutine()
	{
		crash.CrossFadeAlpha(0, 0f, false);

		Menu();

		controls = new InputSettings();
		Debug.Log(controls);
		controls.Player.Pause.started += context => Pause();

		yield break;
	}
	#endregion

	private void InitNewGame()
	{
		SetCoins(0);
	}

	#region Callbacks to events issued by Score items
	private void PlayerCollision(PlayerCollisonEvent e)
	{
		if (e.hpLeft <= 0)
		{
			PlayerReset(new PlayerResetEvent() { playerTransform = e.playerTransform, playerRigidbody = e.playerRigidbody });
			EventManager.Instance.Raise(new PlayerCrashEvent());
			
		}
	}

	private void PlayerReset(PlayerResetEvent e)
    {
		Transform resetPoint = SpawnPoints[0];
		float distanceWithPlayer = Vector3.Distance(e.playerTransform.position, resetPoint.position);
		foreach (Transform spawnLocation in SpawnPoints)
        {
			float newDist = Vector3.Distance(e.playerTransform.position, spawnLocation.position);
			if (newDist < distanceWithPlayer)
            {
				resetPoint = spawnLocation;
				distanceWithPlayer = newDist;
            }
        }
		e.playerTransform.position = resetPoint.position;
		e.playerTransform.rotation = resetPoint.rotation;
		e.playerRigidbody.velocity = Vector3.zero;
		e.playerRigidbody.angularVelocity = Vector3.zero;
		crash.CrossFadeAlpha(1, 0.0f, false);
		crash.CrossFadeAlpha(0, 1f, false);
	}
	#endregion

	#region Callbacks to events issued by Score items
	private void CollectibleHasBeenTaken(CollectItemEvent e)
	{
		if(e.item is Coin)
        {
			IncrementCoins(1);
			Debug.Log("Pièces: " + m_CoinPicked + "/" + m_CoinTotal);
			if (m_CoinPicked == m_CoinTotal) Victory();
		}
	}
	#endregion


	#region Callbacks to Events issued by MenuManager
	private void MainMenuButtonClicked(MainMenuButtonClickedEvent e)
	{
		Menu();
	}

	private void PlayButtonClicked(PlayButtonClickedEvent e)
	{
		Debug.Log("PlayButtonClicked");
		Play();
	}

	private void DemoButtonClicked(DemoButtonClickedEvent e)
	{
		Debug.Log("DemoButtonClicked");
		Demo();
	}

	private void ResumeButtonClicked(ResumeButtonClickedEvent e)
	{
		Resume();
	}

	private void EscapeButtonClicked(EscapeButtonClickedEvent e)
	{
		if (IsPlaying)
			Pause();
	}
	#endregion



	//EVENTS

	
	private void Menu()
	{
		
		SetTimeScale(1);
		m_GameState = GameState.gameMenu;
		MusicLoopsManager.Instance.PlayMusic(Constants.GAMEPLAY_MUSIC);
		
		SceneManager.LoadScene("MainMenu");
		EventManager.Instance.Raise(new GameMenuEvent());
		fadeAnim.CrossFadeAlpha(1, 0.0f, false);
		fadeAnim.CrossFadeAlpha(0, 0.5f, false);

	}

	private void Play()
	{
		
		InitNewGame();
		SetTimeScale(1);
		m_GameState = GameState.gamePlay;
		SceneManager.LoadScene("PetiteIle");
		SceneManager.LoadScene("IleSoufiane", LoadSceneMode.Additive);
        SceneManager.LoadScene("IleLoic2", LoadSceneMode.Additive);
		SceneManager.LoadScene("IleRui", LoadSceneMode.Additive);

		MusicLoopsManager.Instance.PlayMusic(Constants.MENU_MUSIC);

		EventManager.Instance.Raise(new GamePlayEvent());
		StartCoroutine("initPlay");
		fadeAnim.CrossFadeAlpha(1, 0.0f, false);
		fadeAnim.CrossFadeAlpha(0, 1f, false);
	}

	private void Demo()
	{

		InitNewGame();
		SetTimeScale(1);
		m_GameState = GameState.gamePlay;
		SceneManager.LoadScene("Level_0_0");

		MusicLoopsManager.Instance.PlayMusic(Constants.MENU_MUSIC);

		EventManager.Instance.Raise(new GamePlayEvent());
		fadeAnim.CrossFadeAlpha(1, 0.0f, false);
		fadeAnim.CrossFadeAlpha(0, 1f, false);
	}

	IEnumerator initPlay()
    {
		yield return 0;

		GameObject[] CoinContainers = GameObject.FindGameObjectsWithTag("Coins");
		ActiveCoins = new HashSet<GameObject>();
		foreach (GameObject CoinContainer in CoinContainers)
        {
			for (int i = 0; i < CoinContainer.transform.childCount; i++)
			{
				ActiveCoins.Add(CoinContainer.transform.GetChild(i).gameObject);
			}
		}
		m_CoinTotal = ActiveCoins.Count;
		EventManager.Instance.Raise(new GameStatisticsChangedEvent() { eCoinPicked = 0, eCoinTotal = m_CoinTotal });

		// Récupère tout les points de respawn et les stockes dans SpawnPoints
		GameObject[] SpawnPointContainers = GameObject.FindGameObjectsWithTag("Respawn");
		SpawnPoints = new List<Transform>();
		foreach (GameObject SpawnPointContainer in SpawnPointContainers)
        {
			for (int i = 0; i < SpawnPointContainer.transform.childCount; i++)
			{
				SpawnPoints.Add(SpawnPointContainer.transform.GetChild(i));
			}
		}
		Debug.Log("Nombre de points de spawn: " + SpawnPoints.Count);
	}

	void PausePressed(PlayerPressPauseEvent e)
    {
		Pause();
    }

	private void Pause()
	{
		Debug.Log("PauseButtonClicked");
		if (m_GameState == GameState.gamePlay)
        {
			SetTimeScale(0);
			gameObject.transform.Find("GM_UI").gameObject.SetActive(true);

			m_GameState = GameState.gamePause;
			EventManager.Instance.Raise(new GamePauseEvent());
		}
		else if (m_GameState == GameState.gamePause)
        {
			Resume();
        }
	}

	private void Resume()
	{
		gameObject.transform.Find("GM_UI").gameObject.SetActive(false);

		SetTimeScale(1);
		m_GameState = GameState.gamePlay;
		EventManager.Instance.Raise(new GameResumeEvent());
	}

	private void Victory()
	{
		
		SetTimeScale(1);
		SceneManager.LoadScene("VictoryScreen");
		m_GameState = GameState.gameVictory;
		MusicLoopsManager.Instance.PlayMusic(Constants.VICTORY_MUSIC);
		EventManager.Instance.Raise(new GameVictoryEvent());
		fadeAnim.CrossFadeAlpha(1, 0.0f, false);
		fadeAnim.CrossFadeAlpha(0, 2f, false);
	}

	
}
