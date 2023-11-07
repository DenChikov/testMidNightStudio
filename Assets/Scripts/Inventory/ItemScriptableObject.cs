using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory Item", menuName = "Inventory/Item")]
public class ItemScriptableObject : ScriptableObject
{
    public int itemID;
    public string itemName;
    public GameObject itemIcon;
}
