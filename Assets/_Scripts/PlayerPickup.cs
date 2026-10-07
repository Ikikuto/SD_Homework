using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.CompareTag("Hazard"))
        {
            Destroy(collision.gameObject);
            Debug.Log(collision.gameObject.name + " collected!!");
        }
    }
}
