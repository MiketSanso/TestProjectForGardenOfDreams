using UnityEngine;

public class MainCell : MonoBehaviour
{
    [HideInInspector] public int x, y;

    [HideInInspector] public bool isFree;
    public Inventory inventory; 

    public void CellOccupation(MainCell _cell, bool _isOrdered)
    {
         _cell.isFree = _isOrdered;
    }
}
