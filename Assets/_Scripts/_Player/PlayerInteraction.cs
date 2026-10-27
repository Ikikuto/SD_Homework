using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     // Debug.Log("Collision detected!!");
    //     Debug.Log("You hit: " + collision.gameObject.name);
    // }

    // [SerializeField] public int attackDamage = 10;

    private PlayerInventory playerInventory;
    [SerializeField] private GameScore gameScore;

    private void Awake()
    {
        playerInventory = GetComponent<PlayerInventory>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Hit: " + collision.gameObject.name);
        }
        // else if(collision.gameObject.CompareTag("Enemy"))
        // {
        //     EnemyHealth enemyHealth =
        //         collision.gameObject.GetComponent<EnemyHealth>();
        //     if (enemyHealth != null)
        //     {
        //         enemyHealth.TakeDamage(attackDamage);
        //     }
        // }
    }
    //     void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if(collision.gameObject.name == "Coin")
    //     {
    //         // Debug.Log("Enter trigger area.");
    //         Debug.Log("You picked up a coin");
    //     }

    //     if(collision.CompareTag("Coin") && playerInventory != null)
    //     {
    //         playerInventory.AddCoin(1);
    //         Destroy(collision.gameObject);
    //         Debug.Log(
    //         "You received a " + collision.gameObject.name + " !"
    //         );
    //     }
    // }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            if (playerInventory == null || gameScore == null)
            {
                return;
            }

            string coinName = collision.gameObject.name.Trim();
            var points = coinName switch
            {
                "BronzeCoin" => 1,
                "SilverCoin" => 5,
                "GoldenCoin" => 10,
                _ => 1,
            };
            playerInventory.AddCoin(1);
            gameScore.AddScore(points);

            Destroy(collision.gameObject);
        }

        // Xu li item
        ItemPickup itemPickup = collision.GetComponent<ItemPickup>();
        if(itemPickup != null)
        {
            Item item = itemPickup.CreateItem();
            playerInventory.AddItem(item);
            Debug.Log("Picked up: " + item.ItemName);
            Destroy(collision.gameObject);
        }
    }

    
}
