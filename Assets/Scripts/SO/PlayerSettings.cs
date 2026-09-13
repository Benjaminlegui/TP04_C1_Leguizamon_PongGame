using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Game/Data/Player")]
public class PlayerSettings : ScriptableObject
{
    [Header("Configuration")]
    [SerializeField] private float playerSpeed = 5.0f;
    [SerializeField] private float playerSize = 2.0f;

    [Header("Movement")]
    [SerializeField] private KeyCode moveUp = KeyCode.W;
    [SerializeField] private KeyCode moveDown = KeyCode.S;
    [SerializeField] private KeyCode moveLeft = KeyCode.A;
    [SerializeField] private KeyCode moveRight = KeyCode.D;
    
    [Header("Color")]
    [SerializeField] private Color playerColor = Color.white;

    public Color PlayerColor => playerColor;
    public float PlayerSpeed => playerSpeed;
    public float PlayerSize => playerSize;
    public KeyCode PlayerMoveUp => moveUp;
    public KeyCode PlayerMoveDown => moveDown;
    public KeyCode PlayerMoveLeft => moveLeft;
    public KeyCode PlayerMoveRight => moveRight;

    public void SetPlayerSpeed(float value)
    {
        playerSpeed = value;
    }

    public void SetPlayerSize(float value)
    {
        playerSize = value;
    }
    
    public void SetPlayerColor(Color value)
    {
        playerColor = value;
    }
}
