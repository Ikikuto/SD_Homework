using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 20;
    private int currentHealth;
    private EnemySpawner enemySpawner;
    private void Awake()
    {
        currentHealth = maxHealth;
        enemySpawner =
            FindFirstObjectByType<EnemySpawner>();
    }
    public void TakeDamage(int damage)
    {
        if(damage <= 0)
        {
            return;
        }

        currentHealth =
            Mathf.Max(currentHealth - damage, 0);
        Debug.Log("Enemy Health: " + currentHealth);

        if (currentHealth == 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
        enemySpawner.SpawnEnemy();
    }
}
