using UnityEngine;

public class CursorAOE : MonoBehaviour
{
    public GameObject circlePrefab;
    public Camera mainCamera;

    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10f; 
            Vector3 worldPos = mainCamera.ScreenToWorldPoint(mousePos);

            GameObject newCircle = Instantiate(circlePrefab, worldPos, Quaternion.identity);

            Destroy(newCircle, 1f);
        }
    }
}
