using UnityEngine;

public class ItemAmmunition : InventoryItem
{
    public AmmunType itemAmmunType { get { return localItemAmmunType; } }
    [SerializeField] private AmmunType localItemAmmunType;

}
