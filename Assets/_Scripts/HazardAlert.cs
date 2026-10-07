using UnityEngine;

public class HazardAlert : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            Debug.Log("Player entered hazard.");
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            Debug.Log("Player left hazard.");
    }
}
