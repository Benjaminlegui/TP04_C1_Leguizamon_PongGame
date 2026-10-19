using UnityEngine;

// Suggestion: La clase se llama igual que UnityEngine.Collision y, al estar en el namespace global, la tapa en todo el proyecto.
// Un nombre como PaddleCollisionColor evita la confusión y dice qué hace.
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
        // Suggestion: playerRigidBody se asigna acá pero no se usa en ningún método de la clase, y además pisa lo que tenga el inspector.
        // Borrá el campo y esta línea.
        playerRigidBody = GetComponent<Rigidbody2D>();
        currentColor = playerSettings.PlayerColor;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball =  collision.collider.GetComponent<Ball>();
        
        if (collision.collider == topWall || collision.collider == bottomWall)
        {
            // Warning: Escribís el negro y los colores random dentro del asset PlayerSettings. En el editor los cambios de un .asset quedan guardados
            // al salir de Play, así que el color inicial del SO se pierde (si cortás el Play con la paleta en la pared, el asset queda negro).
            // El color de runtime tiene que vivir en el componente (por ejemplo, en el SpriteRenderer) y el SO quedar solo con el valor inicial.
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
            // Bug: currentColor se toma en Awake o en el último golpe de pelota. Si el jugador elige un color en Settings durante la pausa
            // y después toca una pared, al salir se le vuelve a poner currentColor y el color elegido se pierde.
            // Guardá el color previo en OnCollisionEnter2D, justo antes de pintarla de negro, y restaurá ese.
            playerSettings.SetPlayerColor(currentColor);
        }
    }
}
