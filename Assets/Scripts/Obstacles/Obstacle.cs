using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private BoxCollider2D body;
    private ObstaclePool pool;
    private int prefabIndex;
    private float lifetime;
    private float aliveTime;

    public int PrefabIndex => prefabIndex;
    public Vector2 Size => Vector2.Scale(body.size, transform.localScale);

    private void Awake()
    {
        body = GetComponent<BoxCollider2D>();
    }

    public void Prepare(ObstaclePool owner, int index)
    {
        pool = owner;
        prefabIndex = index;
    }

    public void Place(Vector2 position, float angle, float secondsAlive)
    {
        transform.SetPositionAndRotation(position, Quaternion.Euler(0f, 0f, angle));

        lifetime = secondsAlive;
        aliveTime = 0f;

        gameObject.SetActive(true);
    }

    void Update()
    {
        aliveTime += Time.deltaTime;

        if (aliveTime >= lifetime)
            pool.Return(this);
    }
}
