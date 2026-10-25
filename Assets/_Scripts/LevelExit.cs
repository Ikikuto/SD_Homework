using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] private string nextSceneName = "Level2Scene";
    private bool isLoading;
    // [SerializeField] private PlayerInventory playerInventory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.CompareTag("Player")) return;
        if(isLoading) return;

        PlayerInventory playerInventory = collision.GetComponentInParent<PlayerInventory>();
        if(playerInventory == null)
        {
            Debug.Log("null");
            return;
        }
        else if (playerInventory.HasItem(1, 2))
        {
            isLoading = true;
            Time.timeScale = 1f;
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.Log("You need 2 Potion.");
            return;
        }
    }
}
