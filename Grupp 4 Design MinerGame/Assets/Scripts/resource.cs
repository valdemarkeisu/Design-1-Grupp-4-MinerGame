using UnityEngine;
using UnityEngine.UIElements;

public class resource : MonoBehaviour
{
    [SerializeField] Sprite sprite1;
    [SerializeField] Sprite sprite2;
    [SerializeField] Sprite sprite3;
    [SerializeField] Sprite sprite4;


    [SerializeField] float Health = 100f;
    [SerializeField] float MaxHealth = 100f;


    SpriteRenderer spriteRenderer;
    private void Awake()
    {
        Health = MaxHealth;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.sprite = sprite1;



    }

    private void Update()
    {
        SpriteChoser();
        HealthCalc();
    }

    private void FixedUpdate()
    {

    }

    void HealthCalc()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DmgReciver();
            Debug.Log("Dmg");
            if (Health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }


    void DmgReciver()
    {
        Health -= 5;
        Health = Mathf.Max(Health, 0);
    }

    void SpriteChoser()
    {
        float healthPercent = HealthPercentage();

        switch (healthPercent)
        {
            
            case > 90f:
                spriteRenderer.sprite = sprite1;
                break;

            case > 50f and <= 90f:
                spriteRenderer.sprite = sprite2;
                break;
            case > 25f and <= 50f:
                spriteRenderer.sprite = sprite3;
                break;

            case <= 25f:
                spriteRenderer.sprite = sprite4;
                break;
        }

    }

    public float HealthPercentage()
    {
        float percentage = (Health / MaxHealth) * 100f;
        return percentage;
    }








}
