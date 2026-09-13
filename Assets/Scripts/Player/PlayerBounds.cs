using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    [Header("Internal Components")]
    [SerializeField] private Collider2D playerBodyCollider;

    [Header("Walls")]
    [SerializeField] private Collider2D topWall;
    [SerializeField] private Collider2D bottomWall;
    [SerializeField] private Collider2D leftWall;
    [SerializeField] private Collider2D rightWall;

    private void Awake()
    {
        playerBodyCollider = GetComponentInChildren<Collider2D>();
    }

    public float ClampPlayer(float value, char axis)
    {
        float halfMeassure = playerBodyCollider.bounds.extents.y;
        float minAxis = bottomWall.bounds.max.y + halfMeassure;
        float maxAxis = topWall.bounds.min.y - halfMeassure;

        if (axis == 'x')
        {
            halfMeassure = playerBodyCollider.bounds.extents.x;
            minAxis = leftWall.bounds.max.x + halfMeassure;
            maxAxis = rightWall.bounds.min.x - halfMeassure;
        }

        return Mathf.Clamp(value, minAxis, maxAxis);
    }
}
