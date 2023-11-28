using UnityEngine;

[CreateAssetMenu(menuName = "InventoryItemShip", fileName = "NewShip")]
public class InventoryItem : ScriptableObject
{
    public int id;

    public new string name;
    public Sprite icon;

    public int cost;
}
