using System;
using UnityEngine;
using TMPro;

public class UITimer : MonoBehaviour
{
    [SerializeField] private GameSettings gameSettings;
    [SerializeField] private TMP_Text timerText;
    private float timer;
    
    public event Action OnTimeExpired;
    
    void Start()
    {
        timer = gameSettings.RoundLimitTime;
    }
    
    void Update()
    {
        if (timer <= 0f)
            return;
        
        timer = Mathf.Max(0f, timer - Time.deltaTime);
        timerText.text = Mathf.CeilToInt(timer).ToString();

        if (timer <= 0f)
        {
            OnTimeExpired?.Invoke();
        }
    }

    public void ResetTimer()
    {
        timer = 20f;
    }
}
