using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Game")]
    [SerializeField] private FieldSideSwitch fieldSideSwitcher;
    [SerializeField] private Ball ball;
    [SerializeField] private PlayerPositionReset player1;
    [SerializeField] private PlayerPositionReset player2;
    private bool matchFinished;
    
    [Header("HUD")]
    [SerializeField] private UITimer uiTimer;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private TMP_Text countdownText;
    [SerializeField] private GameObject winnerUI;
    [SerializeField] private TMP_Text winnerText;
    [SerializeField] private Button restartButton;
    
    private int player1Score;
    private int player2Score;
    
    void OnEnable()
    {
        uiTimer.OnTimeExpired += HandleTimeout;
        ball.OnGoal += HandleGoal;
        scoreManager.OnWinner += HandleWin;
        restartButton.onClick.AddListener(RestartGame);
    }

    void OnDisable()
    {
        uiTimer.OnTimeExpired -= HandleTimeout;
        ball.OnGoal -= HandleGoal;
        scoreManager.OnWinner -= HandleWin;
        restartButton.onClick.RemoveListener(RestartGame);
    }

    void HandleGoal(int playerId)
    {
        if (matchFinished)
            return;
        
        scoreManager.AddPoint(playerId);
        
        if (matchFinished)
            return;
        
        StartCoroutine(RestartRound());
    }

    void HandleTimeout()
    {
        if (matchFinished)
            return;
        
        if (fieldSideSwitcher.Side > 0)
        {
            scoreManager.AddPoint(1);
        }
        else
        {
            scoreManager.AddPoint(1);
        }

        if (matchFinished)
            return;
        
        StartCoroutine(RestartRound());
    }

    void HandleWin(int playerId)
    {
        matchFinished = true;
        Time.timeScale = 0f;
        winnerUI.SetActive(true);
        winnerText.text = $"Player {playerId} wins";
    }

    void RestartGame()
    {
        matchFinished = false;
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
    }
    
    IEnumerator CountDown(int secondsToWait)
    {
        countdownText.gameObject.SetActive(true);

        for (int seconds = secondsToWait; seconds > 0; seconds--)
        {
            countdownText.text = seconds.ToString();
            yield return new WaitForSecondsRealtime(1f);
        }

        countdownText.gameObject.SetActive(false);
    }
    
    IEnumerator RestartRound()
    {
        Time.timeScale = 0f;
        ResetRound();

        yield return StartCoroutine(CountDown(3));

        Time.timeScale = 1f;
        ball.ThrowBall();
    }
}
