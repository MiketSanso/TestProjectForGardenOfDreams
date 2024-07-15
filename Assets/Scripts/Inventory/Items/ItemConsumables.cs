using UnityEngine;

public class ItemConsumables : InventoryItem
{
    [SerializeField] private TMPro.TMP_Text textCount;
    public int countItemsInObject;

    public void Start()
    {
        PlayerPrefs.SetInt(id, countItemsInObject);
    }

    private void Update()
    {
        if (textCount.text != countItemsInObject.ToString() + "x")
            textCount.text = countItemsInObject.ToString() + "x";

        if (countItemsInObject <= 0)
            Destroy(gameObject);
    }
}
