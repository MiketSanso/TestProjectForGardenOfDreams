using UnityEngine;

public class Player : Entity
{
    public Inventory inventory;
    [SerializeField] private GameObject parentSecondaryObjects;

    protected override void DestroyObject()
    {
        Destroy(parentSecondaryObjects);
    }
}
