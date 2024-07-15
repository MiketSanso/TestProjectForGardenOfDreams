using UnityEngine;

public class ItemPanelSettings : MonoBehaviour
{
    [HideInInspector] public InventoryItem itemInPanel;

    public void InputDeleteObject()
    {
        Destroy(itemInPanel.gameObject);
        this.gameObject.SetActive(false);
    }

    public void InputClosePanel()
    {
        this.gameObject.SetActive(false);
    }
}
