using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Game/Data/Player")]
public class PlayerSettings : ScriptableObject
{
    [Header("Configuration")]
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private float playerSize = 2f;

    [Header("Movement")]
    [SerializeField] private KeyCode moveUp = KeyCode.W;
    [SerializeField] private KeyCode moveDown = KeyCode.S;
    
    [Header("Color")]
    [SerializeField] private Color playerColor = Color.white;

    public Color PlayerColor => playerColor;
    public float PlayerSpeed => playerSpeed;
    public float PlayerSize => playerSize;
    public KeyCode PlayerMoveUp => moveUp;
    public KeyCode PlayerMoveDown => moveDown;

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
