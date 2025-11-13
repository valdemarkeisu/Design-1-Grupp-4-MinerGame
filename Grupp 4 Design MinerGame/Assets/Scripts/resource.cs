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


    [SerializeField] public float Value = 1f;
    public float AcctualValue;
    private GameObject circleAOE;

    public float extraValue;
    public float Multiplier;

    public float Leaf;

    SpriteRenderer spriteRenderer;
    private void Awake()
    {
        Health = MaxHealth;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.sprite = sprite1;

        extraValue = PlayerStats.instance.baseValue;
        Multiplier = PlayerStats.instance.resourceMultiplier;
        ValueCalc();
        
    }

    private void Update()
    {
        SpriteChooser();

    }

    private void FixedUpdate()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("CircleAOE"))
        {
            circleAOE = collision.gameObject;

            Debug.Log("Touched me");
            DmgReciever();
            if (Health <= 0)
            {
               
                Destroy(gameObject);
                PlayerStats.instance.resourceAmount += Mathf.RoundToInt(AcctualValue);
            }
        }
    }

    void DmgReciever()
    {
        Health -= 5;
        Health = Mathf.Max(Health, 0);
    }

    void SpriteChooser()
    {
        float healthPercent = HealthPercentage();

        switch (healthPercent)
        {
            
            case > 95f:
                spriteRenderer.sprite = sprite1;
                break;

            case > 50f and <= 95f:
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

    void ValueCalc()
    {
        AcctualValue = (Value + extraValue) * Multiplier;
    }






}
