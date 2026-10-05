using UnityEngine;

public class Item : MonoBehaviour
{
    string itemName = "Health Potion";
    int healAmount = 50;
    void Start()
    {
        Debug.Log("Item: " + itemName);
        Debug.Log("Heal Amount: " + healAmount);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
