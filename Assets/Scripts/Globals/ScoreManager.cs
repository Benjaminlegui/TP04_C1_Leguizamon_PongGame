using System;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private GameSettings gameSettings;
    [SerializeField] private TMP_Text player1ScoreText;
    [SerializeField] private TMP_Text player2ScoreText;
    private int player1Score = 0;
    private int player2Score = 0;
    private int goalsToWin => (gameSettings.BestOf / 2) + 1;
    public event Action<PlayerId> OnWinner;

    public void AddPoint(PlayerId playerId)
    {
        if (playerId == PlayerId.Player1)
        {
            player1Score++;
            player1ScoreText.text = player1Score.ToString();
        }
        else
        {
            player2Score++;
            player2ScoreText.text = player2Score.ToString();
        }
        
        CheckWinner();
    }

    private void CheckWinner()
    {
        // Bug: Comparás con == (acá y en la línea del jugador 2). Si en la pausa se baja el BestOf desde UIGameSettings
        // y un jugador ya tiene más goles que el nuevo goalsToWin, la igualdad no se cumple nunca y la partida no termina.
        // Usá player1Score >= goalsToWin y lo mismo para el jugador 2.
        if (goalsToWin == player1Score)
        {
            OnWinner?.Invoke(PlayerId.Player1);
        }

        if (goalsToWin == player2Score)
        {
            OnWinner?.Invoke(PlayerId.Player2);
        }
    }

    public void ResetScore()
    {
        player1Score = 0;
        player2Score = 0;
        player1ScoreText.text = player1Score.ToString();
        player2ScoreText.text = player2Score.ToString();
    }
}
