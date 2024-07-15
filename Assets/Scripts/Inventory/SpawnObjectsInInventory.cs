using UnityEngine;
using Zenject;

public class SpawnObjectsInInventory : MonoBehaviour
{
    public GameObject[] ammunitionCells;
    private PrefabsManager _prefabManager;

    [Inject]
    public void Construct(PrefabsManager prefabManager)
    {
        _prefabManager = prefabManager;
    }

    private void Start()
    {
        /*if ( )
        {

            SaveManager.saveMg.activeSave.xCellIndexItems.Add(1);
            SaveManager.saveMg.activeSave.yCellIndexItems.Add(1);
            SaveManager.saveMg.activeSave.idInventoryItems.Add("stg-44");
            SaveManager.saveMg.Save();
        } */
#warning Ну пофикси уже, не?

        SpawnItemsInInventory();
    }

    public void SpawnItemsInInventory()
    {

    }
}
