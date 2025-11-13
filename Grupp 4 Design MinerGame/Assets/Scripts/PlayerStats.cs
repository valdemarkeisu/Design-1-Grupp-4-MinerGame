using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;

    public TMP_Text Recourcetext;



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

    public int resourceAmount = 0;

    private void Awake()
    {

        
        if (instance != null && instance != this)
        {
            Destroy(gameObject); 
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject); 
    }

    private void Update()
    {
        if (Recourcetext != null)
            Recourcetext.text = resourceAmount.ToString();
    }
}





