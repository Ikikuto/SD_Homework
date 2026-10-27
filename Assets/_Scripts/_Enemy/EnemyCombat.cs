using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    [SerializeField] private float attackCooldown = 1f;
    private float nextAttackTime;

    // TAN CONG = VA CHAM:
    // private void OnCollisionStay2D(Collision2D collision)
    // {
    //     if(!collision.gameObject.CompareTag("Player"))
    //     {
    //         return;
    //     }
    //     if (Time.time < nextAttackTime)
    //     {
    //         return;
    //     }
    //     PlayerHealth playerHealth =
    //         collision.gameObject.GetComponent<PlayerHealth>();
    //     if (playerHealth != null)
    //     {
    //         playerHealth.TakeDamage(damage);
    //         nextAttackTime = Time.time + attackCooldown;
    //     }
    // }

    public void TryAttack(Transform target)
    {
        if (target == null) return;

        if (Time.time < nextAttackTime) return;

        if (!target.gameObject.
            TryGetComponent<PlayerHealth>(out var playerHealth))
        {
            Debug.Log("cannot find playerHealth");
            return;
        }
        // if (target.GetComponentInChildren<PlayerHealth>() 
        //         is not PlayerHealth playerHealth)
        // {
        //     return;
        // }

        playerHealth.TakeDamage(damage);
        nextAttackTime = Time.time + attackCooldown;
    }
}
