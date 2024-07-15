using UnityEngine;
using Zenject;

public class ItemPanelInInventoryInstaller : MonoInstaller
{
    [SerializeField] private ItemPanelSettings itemPanel;

    public override void InstallBindings()
    {
        Container.Bind<ItemPanelSettings>().FromInstance(itemPanel).AsSingle();
    }
}
