using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Transform transformCell;
    [SerializeField] private MainCell cellInventory;

    [SerializeField] private GridLayoutGroup grid;

    private MainCell[,] _cells;

    [SerializeField] private int _sizeX, _sizeY;

    public MainCell[,] cells
    {
        get { return _cells; }
        private set { _cells = value; }
    }

    public int sizeX 
    { 
        get { return _sizeX; } 
        private set { _sizeX = value; } 
    }

    public int sizeY
    {
        get { return _sizeY; }
        private set { _sizeY = value; }
    }

    public void Start()
    {
        NewInvPanel();
        gameObject.SetActive(false);
    }

    public void NewInvPanel()
    {
        cells = new MainCell[sizeX, sizeY];

        for (int y = 0; y < sizeY; y++)
        {
            for (int x = 0; x < sizeX; x++)
            {
                var newCell = Instantiate(cellInventory, transformCell);
                newCell.name = x + " " + y;
                newCell.x = x;
                newCell.y = y;
                newCell.isFree = true;
                newCell.inventory = this;
                cells[x, y] = newCell;
            }
        }

        grid.CalculateLayoutInputHorizontal();
        grid.CalculateLayoutInputVertical();
        grid.SetLayoutHorizontal();
        grid.SetLayoutVertical();
    }
}
