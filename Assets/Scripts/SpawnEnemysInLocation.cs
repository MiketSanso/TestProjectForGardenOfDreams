using UnityEngine;
using Zenject;

public class SpawnEnemysInLocation : MonoBehaviour
{
    private PrefabsManager _prefabManager;
    [Inject] private DiContainer diContainer;

    [Inject]
    public void Construct(PrefabsManager prefabManager)
    {
        _prefabManager = prefabManager;
    }

    private void Start()
    {
        SpawnEnemys(3);
    }

    private void SpawnEnemys(int countEnemys)
    {
        for (int a = 0; a < countEnemys; a++)
        {
            int countRepeats = 0;
            int numberPointSpawn = 0;
            do
            {
                numberPointSpawn = Random.Range(0, _prefabManager.enemySpawnPoints.Length);
                countRepeats++;
                if (countRepeats > 1000)
                {
                    Debug.Log("SpawnEnemyInLocaton Багает");
                    return;
                }
            } while (_prefabManager.enemySpawnPoints[numberPointSpawn].transform.childCount > 0);

            diContainer.InstantiatePrefab(_prefabManager.enemys[Random.Range(0, _prefabManager.enemys.Length)], _prefabManager.enemySpawnPoints[numberPointSpawn].transform);
        }
    }
}

