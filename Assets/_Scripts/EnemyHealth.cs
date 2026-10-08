using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 50;
    private int currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if(damage < 0)
        {
            return;
        }

        currentHealth = Mathf.Max(currentHealth - damage, 0);
        Debug.Log("Enemy Health: " + currentHealth);

        if(currentHealth == 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
