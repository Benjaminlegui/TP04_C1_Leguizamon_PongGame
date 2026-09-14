using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    [SerializeField] private float speed = 6f;
    [SerializeField] private float serveAngle = 0.5f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    public void ThrowBall()
    {
        float xAxis = Random.value > 0.5f ? 1f : -1f;
        float yAxis = Random.value > 0.5f ? serveAngle : -serveAngle;
        
        Vector2 direction = new Vector2(xAxis, yAxis).normalized;
        rb.AddForce(direction * speed, ForceMode2D.Impulse);
    }

    public void ResetBall()
    {
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.position = Vector2.zero;
        transform.position = Vector2.zero;
    }
}
