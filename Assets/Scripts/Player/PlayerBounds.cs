using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    [Header("Internal Components")]
    [SerializeField] private Collider2D playerBodyCollider;

    [Header("Walls")]
    [SerializeField] private Collider2D topWall;
    [SerializeField] private Collider2D bottomWall;

    private void Awake()
    {
        playerBodyCollider = GetComponentInChildren<Collider2D>();
    }

    public float ClampPlayer(float value)
    {
        float halfHeight = playerBodyCollider.bounds.extents.y;
        float minY = bottomWall.bounds.max.y + halfHeight;
        float maxY = topWall.bounds.min.y - halfHeight;

        return Mathf.Clamp(value, minY, maxY);
    }
}
