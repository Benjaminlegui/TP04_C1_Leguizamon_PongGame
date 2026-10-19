// Suggestion: El using System no se usa en este archivo. Borralo.
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

    // Suggestion: Releés el SO y reescribís color y escala en cada frame aunque no hayan cambiado.
    // Con un evento en PlayerSettings (OnColorChanged, OnSizeChanged) aplicás el cambio solo cuando pasa.
    void Update()
    {
        ApplyColor();
        ScalePlayer();
    }
    
    private void ScalePlayer()
    {
        Vector3 scale = transform.localScale;
        scale.y = playerSettings.PlayerSize;
        transform.localScale = scale;
    }
    
    private void ApplyColor()
    {
        sprite.color = playerSettings.PlayerColor;
    }
}
