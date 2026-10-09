using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    public void SpawnEnemy()
    {
        Instantiate(
            enemyPrefab, 
            transform.position, 
            Quaternion.identity);
    }
}
