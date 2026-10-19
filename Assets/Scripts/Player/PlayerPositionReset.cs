// Suggestion: El using System no se usa en este archivo. Borralo.
using System;
using UnityEngine;

public class PlayerPositionReset : MonoBehaviour
{
    private Vector2 initialPosition;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        initialPosition = rb.position;
    }

    public void ResetPlayerPosition()
    {
        rb.position = initialPosition;
        transform.position = initialPosition;
    }
}
