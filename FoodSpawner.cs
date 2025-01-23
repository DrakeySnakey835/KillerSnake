using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject foodPrefab;
    public float spawnAreaSize = 50f;
    public int foodAmount = 100;

    void Start()
    {
        for (int i = 0; i < foodAmount; i++)
        {
            SpawnFood();
        }
    }

    void SpawnFood()
    {
        Vector2 spawnPosition = new Vector2(
            Random.Range(-spawnAreaSize, spawnAreaSize),
            Random.Range(-spawnAreaSize, spawnAreaSize)
        );
        Instantiate(foodPrefab, spawnPosition, Quaternion.identity);
    }
}
