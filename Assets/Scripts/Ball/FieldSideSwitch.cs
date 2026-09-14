using UnityEngine;

public class FieldSideSwitch : MonoBehaviour
{
    [SerializeField] private Transform ball;
    [SerializeField] private Transform centreLine;

    public PlayerId BallSide => ball.position.x >= centreLine.position.x
        ? PlayerId.Player2
        : PlayerId.Player1;
    
    public PlayerId OpposingSide => BallSide == PlayerId.Player1
        ? PlayerId.Player2
        : PlayerId.Player1;
}
