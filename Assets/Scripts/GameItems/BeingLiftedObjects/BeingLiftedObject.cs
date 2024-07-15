using UnityEngine;
using Zenject;

public class BeingLiftedObject : Item
{
    private PrefabsManager _prefabManager;
    private SearchSuitableCell _searchSuitableCell;

    [SerializeField] private TMPro.TMP_Text textCountItems;
    private int countItemsInObject;


    [Inject] private DiContainer diContainer;
    [Inject]
    public void Construct(PrefabsManager prefabManager, SearchSuitableCell searchFreeCell)
    {
        _prefabManager = prefabManager;
        _searchSuitableCell = searchFreeCell;
    }

    public void Start()
    {
        int countItems = Random.Range(10, 31);
        countItemsInObject = countItems;
        textCountItems.text = countItemsInObject.ToString() + "x";

    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.GetComponent<Player>())
        {
            SpawnInventoryObject();
            Destroy(gameObject);
        }
    }

    private void SpawnInventoryObject()
    {
        if (_searchSuitableCell.SearchMainCellInInventory(id) == null)
        {
            MainCell mainCell = _searchSuitableCell.SearchMainCellInInventory(null);
            GameObject inventoryItem = diContainer.InstantiatePrefab(SearchObject(), mainCell.transform);
            inventoryItem.GetComponent<ItemConsumables>().countItemsInObject = countItemsInObject;
            mainCell.isFree = false;
        }
        else
            _searchSuitableCell.SearchMainCellInInventory(id).transform.GetChild(0).GetComponent<ItemConsumables>().countItemsInObject += countItemsInObject;
    }

    private GameObject SearchObject()
    {
        for(int i = 0; i < _prefabManager.inventoryObjects.Length; i++)
        {
            if (_prefabManager.inventoryObjects[i].GetComponent<Item>().id == id)
                return _prefabManager.inventoryObjects[i];
        }
        return null;
    }
}
