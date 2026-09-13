using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Game Settings SO")]
    [SerializeField] private PlayerSettings playerSettings;
    
    [Header("Internal Components")]
    [SerializeField] private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        ApplyColor();
        // ScalePlayer();
    }
    
    
    
    // private void ScalePlayer()
    // {
    //     Vector3 scale = transform.localScale;
    //     scale.y = playerSettings.PlayerSize;
    //     transform.localScale = scale;
    // }
    
    private void ApplyColor()
    {
        sprite.color = playerSettings.PlayerColor;
    }
}
