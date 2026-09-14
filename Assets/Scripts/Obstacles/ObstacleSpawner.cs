using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Pool")]
    [SerializeField] private ObstaclePool pool;

    [Header("Timing")]
    [SerializeField] private float spawnInterval = 3f;
    [SerializeField] private float minLifetime = 3f;
    [SerializeField] private float maxLifetime = 7f;

    [Header("Area")]
    [SerializeField] private Vector2 areaMin = new Vector2(-5f, -3.5f);
    [SerializeField] private Vector2 areaMax = new Vector2(5f, 3.5f);
    [SerializeField] private float centerKeepOut = 2f;

    [Header("Placement")]
    [SerializeField] private LayerMask blockingLayers;
    [SerializeField] private float clearance = 0.3f;
    [SerializeField] private int placementAttempts = 10;

    private Coroutine spawnRoutine;

    void OnEnable()
    {
        spawnRoutine = StartCoroutine(SpawnRoutine());
    }

    void OnDisable()
    {
        if (spawnRoutine != null)
            StopCoroutine(spawnRoutine);

        spawnRoutine = null;
    }

    public void Clear()
    {
        pool.ReturnAll();
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            TrySpawn();
        }
    }

    private void TrySpawn()
    {
        Obstacle obstacle = pool.Take();

        for (int attempt = 0; attempt < placementAttempts; attempt++)
        {
            Vector2 position = RandomPosition();

            if (position.magnitude < centerKeepOut)
                continue;

            float angle = Random.Range(0f, 360f);

            if (IsBlocked(position, obstacle.Size, angle))
                continue;

            obstacle.Place(position, angle, Random.Range(minLifetime, maxLifetime));

            return;
        }

        pool.Return(obstacle);
    }

    private Vector2 RandomPosition()
    {
        return new Vector2(
            Random.Range(areaMin.x, areaMax.x),
            Random.Range(areaMin.y, areaMax.y));
    }

    private bool IsBlocked(Vector2 position, Vector2 size, float angle)
    {
        return Physics2D.OverlapBox(position, size + Vector2.one * clearance, angle, blockingLayers) != null;
    }
}
