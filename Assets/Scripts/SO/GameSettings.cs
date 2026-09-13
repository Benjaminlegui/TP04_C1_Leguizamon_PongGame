using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Game/Data/GameSettings")]
public class GameSettings : ScriptableObject
{
    [SerializeField] private int bestOf = 5;
    [SerializeField] private float roundLimitTime = 20f;
    
    public int BestOf => bestOf;
    public float RoundLimitTime => roundLimitTime;
}
