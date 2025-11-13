using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;

    public int baseValue = 0;
    public bool Stone = false;
    public bool Iron = false;
    public bool Crystal = false;

    public int baseDamage = 5;
    public float resourceMultiplier = 1f;

    public bool noBushes = false;
    public bool crystalOnly = false;

    public float spawnInterval = 3f;
    public int resourcesPerSpawn = 1;

    private void Awake()
    {

        // Singleton pattern
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // Only one instance allowed
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject); // Makes it persist across scenes
    }
}





