using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Game")]
    [SerializeField] private FieldSideSwitch fieldSideSwitcher;
    [SerializeField] private Ball ball;
    [SerializeField] private BallCollisions ballCollisions;
    [SerializeField] private PlayerPositionReset player1;
    [SerializeField] private PlayerPositionReset player2;
    [SerializeField] private ObstacleSpawner obstacleSpawner;
    [SerializeField] private int countdownSeconds = 3;
    public bool IsPaused => state == GameState.Paused;
    
    [Header("HUD")]
    [SerializeField] private UITimer uiTimer;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private TMP_Text countdownText;
    [SerializeField] private GameObject winnerUI;
    [SerializeField] private TMP_Text winnerText;
    [SerializeField] private Button restartButton;
    
    private GameState state;
    private GameState stateBeforePause;
    
    void OnEnable()
    {
        uiTimer.OnTimeExpired += HandleTimeout;
        ballCollisions.OnGoal += HandleGoal;
        scoreManager.OnWinner += HandleWin;
        restartButton.onClick.AddListener(RestartGame);
    }
    
    void Start()
    {
        StartCoroutine(RestartRound());
    }

    void OnDisable()
    {
        uiTimer.OnTimeExpired -= HandleTimeout;
        ballCollisions.OnGoal -= HandleGoal;
        scoreManager.OnWinner -= HandleWin;
        restartButton.onClick.RemoveListener(RestartGame);
    }

    void HandleGoal(PlayerId playerId)
    {
        if (state == GameState.Finished)
            return;
        
        scoreManager.AddPoint(playerId);
        
        if (state == GameState.Finished)
            return;
        
        StartCoroutine(RestartRound());
    }

    void HandleTimeout()
    {
        if (state == GameState.Finished)
            return;
        
        scoreManager.AddPoint(fieldSideSwitcher.OpposingSide);

        if (state == GameState.Finished)
            return;
        
        StartCoroutine(RestartRound());
    }

    void HandleWin(PlayerId playerId)
    {
        SetState(GameState.Finished);
        winnerUI.SetActive(true);
        winnerText.text = $"Player {(int)playerId} wins";
    }

    void RestartGame()
    {
        player1.ResetPlayerPosition();
        player2.ResetPlayerPosition();
        scoreManager.ResetScore();
        winnerUI.SetActive(false);
        StartCoroutine(RestartRound());
    }

    void ResetRound()
    {
        ball.ResetBall();
        uiTimer.ResetTimer();
        obstacleSpawner.Clear();
    }

    private void SetState(GameState newState)
    {
        state = newState;
        Time.timeScale = (newState == GameState.Playing) ? 1f : 0f;
    }
    
    public void TogglePause()
    {
        if (state == GameState.Finished)
            return;

        if (state == GameState.Paused)
        {
            SetState(stateBeforePause);
        }
        else
        {
            stateBeforePause = state;
            SetState(GameState.Paused);
        }
    }
    
    IEnumerator CountDown(int secondsToWait)
    {
        countdownText.gameObject.SetActive(true);

        for (int seconds = secondsToWait; seconds > 0; seconds--)
        {
            countdownText.text = seconds.ToString();

            float remaining = 1f;
            while (remaining > 0f)
            {
                if (state != GameState.Paused)
                    remaining -= Time.unscaledDeltaTime;

                yield return null;
            }
        }

        countdownText.gameObject.SetActive(false);
    }
    
    IEnumerator RestartRound()
    {
        SetState(GameState.Countdown);
        ResetRound();

        yield return StartCoroutine(CountDown(countdownSeconds));
        
        if (state == GameState.Finished)
            yield break;

        SetState(GameState.Playing);
        ball.ThrowBall();
    }
}
