using UnityEngine;
using UnityEngine.Animations;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 20;
    [SerializeField] private float knockbackForce = 5f;
    [SerializeField] private float knockbackDuration = 0.2f;
    [SerializeField] private int scoreValue = 20;
    [SerializeField] private GameScore gameScore;
    private EnemyMovement enemyMovement;
    private int currentHealth;
    private EnemySpawner enemySpawner;
    private Rigidbody2D rb;
    [System.Obsolete]
    private void Awake()
    {
        currentHealth = maxHealth;
        // enemySpawner =
        //     FindFirstObjectByType<EnemySpawner>();
        gameScore = FindFirstObjectByType<GameScore>();
        rb = GetComponentInParent<Rigidbody2D>();
        enemyMovement = GetComponentInParent<EnemyMovement>();
    }

    public void TakeDamage(int damage, Vector2 attackerPosition)
    {
        if(damage <= 0)
        {
            return;
        }

        currentHealth =
            Mathf.Max(currentHealth - damage, 0);
        Debug.Log(transform.parent.name + ": " + currentHealth);

        if (currentHealth == 0)
        {
            Die();
        }
        ApplyKnockback(attackerPosition);
    }

    private void Die()
    {
        if (gameScore != null)
        {
            gameScore.AddScore(scoreValue);
        }

        if(enemySpawner != null)
        {
            enemySpawner.SpawnEnemy();
        }

        Destroy(transform.parent.gameObject);
    }

    private void ApplyKnockback(Vector2 attackerPosision)
    {
        // if (rb == null)
        // {
        //     return;
        // }

        Vector2 direction =
            (rb.position - attackerPosision).normalized;

        if (enemyMovement != null)
        {
            enemyMovement.ApplyKnockbackDelay(knockbackDuration);
        }

        rb.linearVelocity = Vector2.zero;
        
        rb.AddForce(
            direction * knockbackForce, 
            ForceMode2D.Impulse);
    }

    public void SetSpawner(EnemySpawner spawner)
    {
        enemySpawner = spawner;
    }

}
