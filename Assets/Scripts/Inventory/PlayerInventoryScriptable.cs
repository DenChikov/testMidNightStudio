using UnityEngine;


[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/PlayerInventory")]
public class PlayerInventoryScriptable : ScriptableObject
{
    public ItemScriptableObject[] items = new ItemScriptableObject[3];
    public int currentItemIndex = 0;

    public GameObject GetCurrentItem()
    {
        return  items[currentItemIndex].itemIcon;
    }
}
