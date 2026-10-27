using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] private float respawnDelay = 2f;
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;

    private void Start()
    {
        SpawnEnemyImmediately();
    }

    // public void SpawnEnemy()
    // {
    //     GameObject enemy = Instantiate(
    //                             enemyPrefab, 
    //                             transform.position, 
    //                             Quaternion.identity);
        
        
    //     if (enemy.TryGetComponent<EnemyHealth>(out var enemyHealth))
    //     {
    //         enemyHealth.SetSpawner(this);
    //     }
    // }

    public void SpawnEnemyImmediately()
    {
        GameObject enemy = Instantiate(
            enemyPrefab, 
            transform.position, 
            Quaternion.identity);

        EnemyHealth enemyHealth =
            enemy.GetComponentInChildren<EnemyHealth>();

        if (enemyHealth != null)
        {
            enemyHealth.SetSpawner(this);
        }

        if (enemy.TryGetComponent<EnemyAI>(out var enemyAI))
        {
            enemyAI.SetPatrolPoints(pointA, pointB);
        }
    }

    private IEnumerator SpawnEnemyWithDelay()
    {
        yield return new WaitForSeconds(respawnDelay);

        SpawnEnemyImmediately();
    }

    public void SpawnEnemy()
    {
        StartCoroutine(SpawnEnemyWithDelay());
    }

}
