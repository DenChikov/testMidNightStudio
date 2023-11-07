using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public PlayerInventoryScriptable playerInventory;
    private GameObject []inventoryPrefab;
    [SerializeField] private Transform spawnPoint;
    private int currentIndex =0;

    private void Start()
    {
        inventoryPrefab = new GameObject[playerInventory.items.Length];
        for(int i = 0; i < inventoryPrefab.Length; i++)
        {
           playerInventory.currentItemIndex = i;
            inventoryPrefab[i] = Instantiate(playerInventory.GetCurrentItem(), spawnPoint.position,Quaternion.identity);
            inventoryPrefab[i].transform.parent = spawnPoint;
            inventoryPrefab[i].SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchInventoryItem(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchInventoryItem(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchInventoryItem(2);
        }
    }

    private void SwitchInventoryItem(int index)
    {
        inventoryPrefab[currentIndex].SetActive(false);
        currentIndex = index;
        inventoryPrefab[currentIndex].SetActive(true);
    }
}
