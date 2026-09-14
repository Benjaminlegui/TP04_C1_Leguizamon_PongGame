using UnityEngine;

public class FieldSideSwitch : MonoBehaviour
{
    [SerializeField] private Transform ball;

    public PlayerId BallSide => ball.position.x >= transform.position.x
        ? PlayerId.Player2
        : PlayerId.Player1;
    
    public PlayerId OpposingSide => BallSide == PlayerId.Player1
        ? PlayerId.Player2
        : PlayerId.Player1;
}
