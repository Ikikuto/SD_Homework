using UnityEngine;

public class Item : MonoBehaviour
{
    string itemName = "Health Potion";
    int healAmount = 50;
    int price = 20;
    void Start()
    {
        Debug.Log("Item: " + itemName);
        Debug.Log("Heal Amount: " + healAmount);
        Debug.Log("Price: " + price);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
