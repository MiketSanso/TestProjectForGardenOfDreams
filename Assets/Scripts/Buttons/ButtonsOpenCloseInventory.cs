using UnityEngine;

public class ButtonsOpenCloseInventory : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel, mainUIPanel;

    public void OpenInventory()
    {
        inventoryPanel.SetActive(true);
        mainUIPanel.SetActive(false);
    }

    public void CloseInventory()
    {
        inventoryPanel.SetActive(false);
        mainUIPanel.SetActive(true);
    }
}
