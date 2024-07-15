using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public abstract class InventoryItem : Item, IPointerClickHandler
{
    [HideInInspector] public MainCell prevMainCell;
    [HideInInspector] public AmmunitionCell prevAmmunitionCell;

    [HideInInspector] public float postIndex = 31.25f;

    [SerializeField] private ItemPanelSettings _itemPanel;

    [Inject]
    public void Construct(ItemPanelSettings itemPanel)
    {
        _itemPanel = itemPanel;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _itemPanel.GetComponent<ItemPanelSettings>().itemInPanel = this;
        _itemPanel.transform.parent = transform;
        _itemPanel.gameObject.transform.localPosition = new Vector3((_itemPanel.transform.GetChild(0).transform.localScale.x/2) * -1, GetComponent<RectTransform>().sizeDelta.y / 2 * -1, 0);
        _itemPanel.transform.parent = transform.parent.transform.parent.transform.parent;
        _itemPanel.gameObject.SetActive(true);
    } 
}