using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TextMeshProUGUI healthText;

    public void SetMaxHealth(int maxHealth)
    {
        healthSlider.maxValue = maxHealth;
        // gioi han mau
        healthSlider.value = maxHealth;
        // neu ko gan cai nay thi sao??
        healthText.text = maxHealth + "/" + maxHealth;
    }

    public void SetHealth(int currentHealth, int maxHealth)
    {
        healthSlider.value = currentHealth;
        healthText.text = currentHealth + "/" + maxHealth;
    }
}
