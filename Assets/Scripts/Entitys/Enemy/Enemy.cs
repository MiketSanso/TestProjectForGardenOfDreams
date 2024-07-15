using UnityEngine;
using Zenject;

public class Enemy : Entity
{
    private PrefabsManager _prefabManager;
    [SerializeField] private int _damageEnemy;

    public bool stopAndPush = true;
    public bool isAgressive = false;
    public bool isAttack = false;

    public int damageEnemy
    {
        get { return _damageEnemy; }
        protected set { _damageEnemy = value; }
    }

    [Inject] private DiContainer diContainer;

    [Inject]
    public void Construct(PrefabsManager prefabManager)
    {
        _prefabManager = prefabManager;
    }

    protected override void DestroyObject()
    {
        SpawnObject();
        Destroy(gameObject);
    }

    private void SpawnObject()
    {
        diContainer.InstantiatePrefab(_prefabManager.beingLiftedObjects[Random.Range(0, _prefabManager.beingLiftedObjects.Length)], transform.position, Quaternion.identity, null);
    }
}
