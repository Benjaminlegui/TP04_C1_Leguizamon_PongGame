using UnityEngine;

public class Collision : MonoBehaviour
{
    [Header("Player vars")]
    [SerializeField] private Rigidbody2D playerRigidBody;
    [SerializeField] private PlayerSettings playerSettings;
    [SerializeField] private Color wallTouchColor = Color.black;
    private Color currentColor;
    
    [Header("Walls")]
    [SerializeField] private Collider2D topWall;
    [SerializeField] private Collider2D bottomWall;
    
    void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        currentColor = playerSettings.PlayerColor;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball =  collision.collider.GetComponent<Ball>();
        
        if (collision.collider == topWall || collision.collider == bottomWall)
        {
            playerSettings.SetPlayerColor(wallTouchColor);
        }

        if (ball != null)
        {
            currentColor = new Color(Random.value, Random.value, Random.value); 
            playerSettings.SetPlayerColor(currentColor);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider == topWall || collision.collider == bottomWall)
        {
            playerSettings.SetPlayerColor(wallTouchColor);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider == topWall || collision.collider == bottomWall)
        {
            playerSettings.SetPlayerColor(currentColor);
        }
    }
}
