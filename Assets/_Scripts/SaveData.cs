using System;

[Serializable]
public class SaveData
{
    public float playerX;
    public float playerY;
    public int health;
    public int score;
    public ItemSaveData[] items;
    public int coinCount;
    public string sceneName;

    public string[] remainWorldItemIds;

    // SaveData data = new SaveData();
    // data.health = 80;
    // data.score = 500;
    // string json = JsonUtility.ToJson(data, true);
}
