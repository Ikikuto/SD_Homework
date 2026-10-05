using UnityEngine;

public class Player : MonoBehaviour
{
    public int level = 2;
    public int gold = 250;
    void Start()
    {
        Debug.Log("Player Stated.");
        Debug.Log("Player Level: " + level);
        Debug.Log("Player gold: " + gold);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
