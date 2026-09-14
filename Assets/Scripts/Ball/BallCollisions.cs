using System;
using UnityEngine;

public class BallCollisions : MonoBehaviour
{
    [Header("Speed")]
    [SerializeField] private float speedBoost = 1.05f;
    [SerializeField] private float minSpeed = 6f;
    [SerializeField] private float maxSpeed = 10f;
    
    [Header("Walls")]
    [SerializeField] private FieldSideSwitch fieldSideSwitch;
    [SerializeField] private Collider2D leftGoal;
    [SerializeField] private Collider2D rightGoal;
    
    private bool  notInitialKick = false;
    private Rigidbody2D rb;
    public event Action<PlayerId> OnGoal;
    
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        HandlePlayerCollision(other);
        HandleWallCollision(other);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        HandleSwitcherCollision(other);
    }

    private void HandlePlayerCollision(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        
        if (player == null)
            return;

        float boosted = rb.linearVelocity.magnitude * speedBoost;
        float speed = Mathf.Clamp(boosted, minSpeed, maxSpeed);

        rb.linearVelocity = rb.linearVelocity.normalized * speed;
    }
    
    private void HandleSwitcherCollision(Collider2D other)
    {
        FieldSideSwitch switcher = other.gameObject.GetComponent<FieldSideSwitch>();

        if (switcher == fieldSideSwitch && notInitialKick)
        {
            switcher.ChangeSide();
        }

        notInitialKick = true;
    }

    private void HandleWallCollision(Collision2D collision)
    {
        if (collision.collider == leftGoal)
        {
            OnGoal?.Invoke(PlayerId.Player2);
        } else if (collision.collider == rightGoal)
        {
            OnGoal?.Invoke(PlayerId.Player1);
        }
    }
}
