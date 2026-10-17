using UnityEngine;
using TMPro;

public class CoinCounterUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;

    public void SetCointCount(int coinCount)
    {
        coinText.text = "Coins: " + coinCount;
    }
}
