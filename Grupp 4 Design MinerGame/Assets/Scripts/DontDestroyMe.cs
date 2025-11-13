using UnityEngine;

public class DontDestroyMe : MonoBehaviour
{
    [Tooltip("Check this if you want only one instance to exist (singleton).")]
    public bool isSingleton = true;

    private void Awake()
    {
        if (isSingleton)
        {
            // Use the new FindObjectsByType API
            DontDestroyMe[] existing = Object.FindObjectsByType<DontDestroyMe>(FindObjectsSortMode.None);
            if (existing.Length > 1)
            {
                Destroy(gameObject);
                return;
            }
        }

        DontDestroyOnLoad(gameObject);
    }
}
