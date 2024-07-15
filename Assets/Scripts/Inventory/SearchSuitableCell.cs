using UnityEngine;

public class SearchSuitableCell : MonoBehaviour
{
    [SerializeField] private Inventory inventory;

    public MainCell SearchMainCellInInventory(string id)
    {
        for (int y = 0; y < inventory.sizeY; y++)
        {
            for (int x = 0; x < inventory.sizeX; x++)
            {
                if (id == null)
                {
                    if (inventory.cells[x, y].isFree)
                        return inventory.cells[x, y];
                }
                else
                {
                    if (inventory.cells[x, y].transform.childCount > 0 && inventory.cells[x, y].transform.GetChild(0).GetComponent<Item>().id == id)
                        return inventory.cells[x, y];
                }
            }
        }

        return null;
    }
}
