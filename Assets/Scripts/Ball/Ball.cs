using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    [SerializeField] private float speed = 6f;
    [SerializeField] private FieldSideSwitch fieldSideSwitch;
    private bool  notInitialKick = false;

    private Rigidbody2D rb;
    public event Action<int> OnGoal;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        ThrowBall();
    }
    
    public void ThrowBall()
    {
        float xAxis = Random.value > 0.5f ? 1f : -1f;
        float yAxis = Random.value > 0.5f ? 0.5f : -0.5f;
        
        Vector2 direction = new Vector2(xAxis, yAxis).normalized;
        rb.AddForce(direction * speed, ForceMode2D.Impulse);
        
        fieldSideSwitch.SetInitialSide(xAxis);
    }

    public void ResetBall()
    {
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.position = Vector2.zero;
        transform.position = Vector2.zero;
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
        
        if (player != null)
        {
            Vector2 direction = rb.linearVelocity.normalized;
            rb.AddForce(direction * 0.5f, ForceMode2D.Impulse);
        }
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
