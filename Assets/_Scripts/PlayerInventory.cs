using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private CoinCounterUI coinCounterUI;
    [SerializeField] private InventoryUI inventoryUI;
    [SerializeField, Min(1)] private int maxSlots = 5;
    private int coinCount;

    public int CoinCount
    {
        get
        {
            return coinCount;
        }
    }

    private void Start()
    {
        LoadInventory();

        if (coinCounterUI != null)
        {
            coinCounterUI.SetCointCount(coinCount);
        }

        RefeshUI();
    }

    public void AddCoin(int amount)
    {
        if (amount <= 0)
        {
            return;
        }

        coinCount += amount;

        SaveInventory();

        if (coinCounterUI != null)
        {
            coinCounterUI.SetCointCount(coinCount);
        }
    }

    private List<Item> items = new();

    //Cung cap danh sach item
    public IReadOnlyList<Item> Items
    {
        get { return items; }
    }

    public Item FindItem(int id)
    {
        foreach (Item item in items)
        {
            if (item.Id == id)
            {
                return item;
            }
        }

        return null;
    }

    public void AddItem(Item newItem)
    {
        // VALID CHECK
        if (newItem == null || newItem.Quantity <= 0) return;

        Item existingItem = FindItem(newItem.Id);

        if (existingItem != null)
        {
            existingItem.Quantity += newItem.Quantity;
            // return;
        }
        else if (items.Count < maxSlots)
        {
            items.Add(newItem);
        }
        else
        {
            Debug.Log($"Cannot Add Item_Id: {newItem.Id}");
            return;
        }


        SaveInventory();
        RefeshUI();
    }

    public bool RemoveItem(int id, int amount)
    {
        if (amount <= 0) return false;

        Item item = FindItem(id);

        if (item == null) return false;

        if (item.Quantity < amount) return false;

        item.Quantity -= amount;

        if (item.Quantity == 0)
        {
            items.Remove(item);
        }

        SaveInventory();
        RefeshUI();
        return true;
    }

    public void UseHealthPotion(PlayerHealth playerHealth)
    {
        const int healthPotionId = 1;
        bool removed = RemoveItem(healthPotionId, 1);
        if (!removed) return;

        playerHealth.Heal(25);
    }

    public void UseLargeHealthPotion(PlayerHealth playerHealth)
    {
        const int ItemId = 4;
        bool removed = RemoveItem(ItemId, 1);
        if (!removed) return;

        playerHealth.Heal(50);
    }

    private void RefeshUI()
    {
        if (inventoryUI != null)
        {
            inventoryUI.Refesh(items);
        }
    }

    //REMOVE BY QUANTITY
    public bool HasItem(int id, int amount)
    {
        //VALID CHECK
        if (amount <= 0) return false;

        Item existingItem = FindItem(id);

        return existingItem != null
            && existingItem.Quantity >= amount;
    }

    private void LoadInventory()
    {
        if (GameSession.Instance == null)
        {
            return;
        }

        coinCount = GameSession.Instance.CoinCount;
        items = GameSession.Instance.LoadItems();
    }

    private void SaveInventory()
    {
        if (GameSession.Instance == null)
        {
            return;
        }

        GameSession.Instance.CoinCount = coinCount;
        GameSession.Instance.SaveItems(items);
    }

    public ItemSaveData[] ExportItems()
    {
        ItemSaveData[] result =
        new ItemSaveData[items.Count];

        for (int i = 0; i < items.Count; i++)
        {
            ItemSaveData itemData =
            new()
            {
                id = items[i].Id,
                itemName = items[i].ItemName,
                quantity = items[i].Quantity
            };

            result[i] = itemData;
        }
        return result;
    }

    public void ImportItems(ItemSaveData[] savedItems)
    {
        items.Clear();

        if (savedItems == null)
        {
            RefeshUI();
            return;
        }

        foreach (ItemSaveData savedItem in savedItems)
        {
            if (savedItem.quantity <= 0) continue;

            Item item = new(
            savedItem.id,
            savedItem.itemName,
            savedItem.quantity
            );

            items.Add(item);
        }
        SaveInventory();
        RefeshUI();
    }

    public void SetCoinCount(int amount)
    {
        coinCount = Mathf.Max(amount, 0);

        SaveInventory();

        if (coinCounterUI != null)
        {
            coinCounterUI.SetCointCount(coinCount);
        }
    }

}
