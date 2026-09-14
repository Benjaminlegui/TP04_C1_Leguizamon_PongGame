using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour
{
    [Header("Pool")]
    [SerializeField] private Obstacle[] prefabs;
    [SerializeField] private int copiesPerPrefab = 4;

    private Queue<Obstacle>[] available;
    private readonly List<Obstacle> active = new List<Obstacle>();

    private void Awake()
    {
        available = new Queue<Obstacle>[prefabs.Length];

        for (int index = 0; index < prefabs.Length; index++)
        {
            available[index] = new Queue<Obstacle>();

            for (int copy = 0; copy < copiesPerPrefab; copy++)
                available[index].Enqueue(CreateCopy(index));
        }
    }

    public Obstacle Take()
    {
        int index = Random.Range(0, prefabs.Length);
        Queue<Obstacle> queue = available[index];
        Obstacle obstacle = queue.Count > 0 ? queue.Dequeue() : CreateCopy(index);

        active.Add(obstacle);

        return obstacle;
    }

    public void Return(Obstacle obstacle)
    {
        if (!active.Remove(obstacle))
            return;

        obstacle.gameObject.SetActive(false);
        available[obstacle.PrefabIndex].Enqueue(obstacle);
    }

    public void ReturnAll()
    {
        for (int index = active.Count - 1; index >= 0; index--)
            Return(active[index]);
    }

    private Obstacle CreateCopy(int prefabIndex)
    {
        Obstacle obstacle = Instantiate(prefabs[prefabIndex], transform);

        obstacle.Prepare(this, prefabIndex);
        obstacle.gameObject.SetActive(false);

        return obstacle;
    }
}
