using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("Prefabs (Buske, Stone, Iron, Crystal)")]
    public GameObject[] prefabs;           // assign 4 prefabs in Inspector
    public bool[] canSpawn = { true, false, false, false }; // only Buske true by default

    public float spawnInterval = 6f;
    private float timer = 0f;

    // Safe spawn boundaries
    public float minX = -4.5f;
    public float maxX = 4.5f;
    public float minY = -4.5f;
    public float maxY = 4.5f;

    void Start()
    {
        timer = spawnInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SpawnRandomPrefab();
            timer = spawnInterval;
        }
    }

    void SpawnRandomPrefab()
    {
        // Build a list of enabled prefabs
        int[] enabledIndices = new int[prefabs.Length];
        int count = 0;

        for (int i = 0; i < prefabs.Length; i++)
        {
            if (canSpawn[i] && prefabs[i] != null)
            {
                enabledIndices[count] = i;
                count++;
            }
        }

        if (count == 0) return; // nothing to spawn

        // Pick a random enabled prefab
        int randomIndex = enabledIndices[Random.Range(0, count)];
        GameObject prefabToSpawn = prefabs[randomIndex];

        // Pick a random position inside safe boundaries
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);
        Vector3 spawnPos = new Vector3(x, y, 0f);

        // Spawn
        Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);
    }
}