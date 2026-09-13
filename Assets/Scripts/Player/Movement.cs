using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Movement : MonoBehaviour
{
    [SerializeField] private PlayerSettings playerSettings;
    
    [FormerlySerializedAs("playerBounds")] 
    [SerializeField] private PlayerBounds playerPlayerBounds;
    [SerializeField] private Rigidbody2D body;
    private float moveSpeed => playerSettings.PlayerSpeed;
    private KeyCode moveDown =>  playerSettings.PlayerMoveDown;
    private KeyCode moveUp =>  playerSettings.PlayerMoveUp;
    private KeyCode moveLeft => playerSettings.PlayerMoveLeft;
    private KeyCode moveRight => playerSettings.PlayerMoveRight;
    private Vector2 direction;

    private void Awake()
    {
        playerPlayerBounds = GetComponent<PlayerBounds>();
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bool up = Input.GetKey(moveUp);
        bool down = Input.GetKey(moveDown);
        bool left = Input.GetKey(moveLeft);
        bool right = Input.GetKey(moveRight);

        float x = (right ? 1f : 0f) - (left ? 1f : 0f);
        float y = (up ? 1f : 0f) - (down ? 1f : 0f);

        direction = new Vector2(x, y).normalized;
    }

    void FixedUpdate()
    {
        Vector2 target = body.position + direction * (moveSpeed * Time.fixedDeltaTime);

        target.y = playerPlayerBounds.ClampPlayer(target.y, 'y');
        target.x = playerPlayerBounds.ClampPlayer(target.x, 'x');
        
        body.MovePosition(target);
    }
}
