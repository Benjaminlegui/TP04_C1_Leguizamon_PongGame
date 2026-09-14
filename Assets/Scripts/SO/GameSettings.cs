using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Game/Data/GameSettings")]
public class GameSettings : ScriptableObject
{
    [SerializeField] private int bestOf = 5;
    [SerializeField] private int roundLimitTime = 20;
    
    public int BestOf => bestOf;
    public int RoundLimitTime => roundLimitTime;

    public void SetRoundLimitTime(int value)
    {
        roundLimitTime = value;
    }

    public void SetBestOf(int value)
    {
        bestOf = value;
    }
}
