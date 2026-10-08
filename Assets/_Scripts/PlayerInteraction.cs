using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log("Collision detected!!");
        Debug.Log("You hit: " + collision.gameObject.name);
        
        EnemyHealth enemyHealth =
            collision.gameObject.GetComponent<EnemyHealth>();
        if(enemyHealth != null)
        {
            enemyHealth.TakeDamage(50);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // if(collision.gameObject.name == "Coin")
        // {
        //     // Debug.Log("Enter trigger area.");
        //     Debug.Log("You picked up a coin");
        // }

        if(collision.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            Debug.Log(
            "You received a " + collision.gameObject.name + " !"
            );
        }
    }
}
