using System;
using TMPro;
using UnityEngine;

public class UIGameSettings : MonoBehaviour
{
    [SerializeField] private GameSettings gameSettings;
    [SerializeField] private TMP_InputField roundTime;
    [SerializeField] private TMP_InputField bestOfRounds;
    [SerializeField] private int minRoundTime = 5;
    [SerializeField] private int minBestOf = 3;
    private int roundLimitTime => gameSettings.RoundLimitTime;
    private int bestOf => gameSettings.BestOf;

    void Awake()
    {
        if (roundTime != null)
        {
            roundTime.SetTextWithoutNotify(roundLimitTime.ToString());
            roundTime.onEndEdit.AddListener(HandleRoundTimeChange);
        }

        if (bestOfRounds != null)
        {
            bestOfRounds.SetTextWithoutNotify(bestOf.ToString());
            bestOfRounds.onEndEdit.AddListener(HandleBestOfRoundsChange);
        }
    }

    private void HandleRoundTimeChange(string value)
    {
        int parsedValue = ValidateInput(value, minRoundTime);
        gameSettings.SetRoundLimitTime(parsedValue);
        roundTime.SetTextWithoutNotify(parsedValue.ToString());
    }

    private void HandleBestOfRoundsChange(string value)
    {
        int parsedValue = ValidateInput(value, minBestOf);
        gameSettings.SetBestOf(parsedValue);
        bestOfRounds.SetTextWithoutNotify(parsedValue.ToString());
    }

    private int ValidateInput(string value, int minValue)
    {
        if (!int.TryParse(value, out int parsedValue))
            parsedValue = 1;

        parsedValue = Mathf.Max(minValue, parsedValue);

        return parsedValue;
    }
}
