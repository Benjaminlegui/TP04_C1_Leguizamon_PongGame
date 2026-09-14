using System;
using UnityEngine;

public class BallCollisions : MonoBehaviour
{
    [Header("Speed")]
    [SerializeField] private float speedBoost = 1.05f;
    [SerializeField] private float minSpeed = 6f;
    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private FieldSideSwitch fieldSideSwitch;
    
    private bool  notInitialKick = false;
    private Rigidbody2D rb;
    public event Action<int> OnGoal;
    
    
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

        float boosted = rb.linearVelocity.magnitude * speedBoost; // boosted grabs the direction that the physics engine calculated and we only change the magnitude by multiplying it by speedBoot
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
        string wall = collision.gameObject.name;
        
        if (wall == "Left")
        {
            OnGoal?.Invoke(2);
        } else if (wall == "Right")
        {
            OnGoal?.Invoke(1);
        }
    }
}
