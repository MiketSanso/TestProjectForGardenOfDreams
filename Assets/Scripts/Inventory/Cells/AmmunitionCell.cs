using UnityEngine;

public class AmmunitionCell : MonoBehaviour
{
    [SerializeField] private AmmunType localCellAmmunType;
    [HideInInspector] public AmmunType cellAmmunType { get { return localCellAmmunType; }  }

    [HideInInspector] public bool isFree;

    public void Start()
    {
        isFree = true;
    }
}