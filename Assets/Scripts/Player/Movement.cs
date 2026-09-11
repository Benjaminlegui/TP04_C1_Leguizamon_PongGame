using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Movement : MonoBehaviour
{
    [SerializeField] private PlayerSettings playerSettings;
    [FormerlySerializedAs("playerBounds")] [SerializeField] private PlayerBounds playerPlayerBounds;
    [SerializeField] private Rigidbody2D body;
    private float moveSpeed => playerSettings.PlayerSpeed;
    private KeyCode moveDown =>  playerSettings.PlayerMoveDown;
    private KeyCode moveUp =>  playerSettings.PlayerMoveUp;
    private float direction;

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

        direction = (up ? 1f : 0f) - (down ? 1f : 0f);
    }

    void FixedUpdate()
    {
        Vector2 target = body.position + Vector2.up * (direction * moveSpeed * Time.fixedDeltaTime);

        target.y = playerPlayerBounds.ClampPlayer(target.y);
        
        body.MovePosition(target);
    }
}
