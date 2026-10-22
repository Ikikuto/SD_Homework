using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI inventoryText;

    public void Refesh(IReadOnlyList<Item> items)
    {
        StringBuilder builder = new();
        if (items.Count < 5)
        {
            builder.AppendLine(
                "INVENTORY: (Total: " + items.Count + ")");
            foreach (Item item in items)
            {
                builder.AppendLine(item.ItemName + " x" + item.Quantity);
            }

            inventoryText.SetText(builder);
        }
        else
        {
            builder.AppendLine("INVENTORY: (Full)");
            foreach (Item item in items)
            {
                builder.AppendLine(item.ItemName + " x" + item.Quantity);
            }

            inventoryText.SetText(builder);
        }        
    }
}
