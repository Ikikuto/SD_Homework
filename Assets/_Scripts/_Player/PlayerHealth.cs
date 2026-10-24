using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private HealthBarUI healthBarUI;
    [SerializeField] private GameManager gameManager;
    private int currentHealth;
    public int CurrentHealth
    {
        get{return currentHealth;}
    }
    // private void Awake()
    // {
    //     currentHealth = maxHealth;
    // }



    private void Start()
    {
        if (GameSession.Instance != null &&
        GameSession.Instance.HasSavedHealth)
        {
            currentHealth = Mathf.Clamp(
            GameSession.Instance.CurrentHealth,
            0,
            maxHealth
            );
        }
        else
        {
            currentHealth = maxHealth;
            SaveHealth();
        }

        if (healthBarUI != null)
        {
            // healthBarUI.SetMaxHealth(maxHealth);
            healthBarUI.SetHealth(currentHealth,maxHealth);
        }
    }

    public void TakeDamage(int damage)
    {
        if (damage <= 0 || currentHealth == 0)
        {
            return;
        }

        currentHealth =
            Mathf.Max(currentHealth - damage, 0);

        // Debug.Log("Player Health: " + currentHealth);

        UpdateHealth();

        if (healthBarUI != null)
        {
            healthBarUI.SetHealth(currentHealth, maxHealth);
        }

        if (currentHealth == 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Debug.Log("Player died");
        if (gameManager != null)
        {
            gameManager.GameOver();
        }

        gameObject.SetActive(false);
    }

    public void Heal(int amount)
    {
        if (amount <= 0 || currentHealth == 0)
        {
            return;
        }

        currentHealth =
            Mathf.Min(currentHealth + amount, maxHealth);

        UpdateHealth();

        if (healthBarUI != null)
        {
            healthBarUI.SetHealth(currentHealth, maxHealth);
        }
    }

    private void UpdateHealth()
    {
        SaveHealth();

        if (healthBarUI != null)
        {
            healthBarUI.SetHealth(currentHealth, maxHealth);
        }
    }

    private void SaveHealth()
    {
        if (GameSession.Instance != null)
        {
            GameSession.Instance.SaveHealth(currentHealth);
        }
    }

    //CHECK LAI PHAN NAY
    public void SetHealth(int health)
    {
        currentHealth = Mathf.Clamp(health, 0, maxHealth);
        SaveHealth();
        if (healthBarUI != null)
        {
            healthBarUI.SetHealth(currentHealth, maxHealth);
        }

        if (currentHealth == 0)
        {
            Die();
        }
    }
}
